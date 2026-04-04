using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms.CustomControls
{
    public partial class BetSlipPanel : UserControl
    {
        public event Action<BetHistorySlip, bool, string> ClaimClicked;
        private readonly WalletService Payment = new WalletService();
        private AppUser CurrentUser;

        private BetHistorySlip CurrentSlip;
        public BetSlipPanel(BetHistorySlip currentSlip, AppUser loggedInUser)
        {
            CurrentUser = loggedInUser;
            CurrentSlip = currentSlip;
            InitializeComponent();
            slipTableLayoutBgPanel.CellPaint += tableLayoutAddBorders;
            DisplayDetails();
            SetClaimBtn();
            PropagateClickEvents(this);
        }

        public void DisplayDetails()
        {
            slipDateLbl.Text = $"Bet Placed: {CurrentSlip.BetDate.ToString("dd/MM/yyyy")}";
            totalBetsLbl.Text = $"Total Bets: {CurrentSlip.Bets.Count}";
            totalOddsLbl.Text = $"Total Odds: {Math.Round(CurrentSlip.TotalOdds, 2)}";
            statusLbl.Text = $"Status: {CurrentSlip.Status}";
            stakeLbl.Text = $"Stake: ${Math.Round(CurrentSlip.Stake, 2)}";
            payoutLbl.Text = $"Expected Payout: ${Math.Round(CurrentSlip.Payout, 2)}";

            // preview of bet from slip
            HistoryBet betPreview = CurrentSlip.Bets[0];
            previewedLeagueLbl.Text = betPreview.LeagueName;
            previewMatchDateLbl.Text = betPreview.MatchDate.ToString("dd/MM/yyyy") + betPreview.MatchDate.ToString("HH:mm");
            homeTeamLbl.Text = betPreview.HomeTeam;
            awayTeamLbl.Text = betPreview.AwayTeam;
        }

        //button to claim a bet slip
        private void SetClaimBtn()
        {
            //enalble claim button only for won and unclaimed slips
            if (CurrentSlip.Status == "Won" && !CurrentSlip.Claimed)
            {
                claimBtn.Enabled = true;
                claimBtn.Text = "Claim Now";
                claimBtn.Click += ClaimBtn_Click;
                return;
            }
            claimBtn.Enabled = false;
            if (CurrentSlip.Claimed)
            {
                claimBtn.Text = "Claimed";
                claimBtn.BackColor = Color.Teal;
                return;
            }

            claimBtn.BackColor = Color.FromArgb(169, 169, 169);
            claimBtn.Text = "Cannot Claim";
        }

        private async void ClaimBtn_Click(object? sender, EventArgs e)
        {
            claimBtn.Enabled = false;
            (bool valid, string message) = await Payment.DepositOrPayoutAsync(CurrentUser, CurrentSlip.Payout, "payout", CurrentSlip.SlipID);
            if (valid)
            {
                //update slip
                CurrentSlip.Claimed = true;
                SetClaimBtn();
            }
            ClaimClicked?.Invoke(CurrentSlip, valid, message);
        }

        //add borders to table layout panel
        private void tableLayoutAddBorders(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == 1 && e.Row == 0)
            {
                var rectangle = e.CellBounds;
                rectangle.Inflate(-1, -1);
               
                ControlPaint.DrawBorder(e.Graphics, rectangle, 
                    Color.FromArgb(36, 36, 36), 2, ButtonBorderStyle.Solid,
                    Color.FromArgb(36, 36, 36), 0, ButtonBorderStyle.Solid,
                    Color.FromArgb(36, 36, 36), 2, ButtonBorderStyle.Solid,
                    Color.FromArgb(36, 36, 36), 0, ButtonBorderStyle.Solid
                );
            }
        }

        //propagate click events
        private void PropagateClickEvents(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                // skip claim button and its panel to avoid opening popup when clicking claim button
                if (ctrl == claimBtn || ctrl == claimBtnPanel)
                    continue;
                
                ctrl.Click += SlipPanelClick;
                ctrl.Cursor = Cursors.Hand;
                if (ctrl.HasChildren)
                {
                    PropagateClickEvents(ctrl);
                }
            }
        }

        private void SlipPanelClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            this.OnClick(e);
        }

        //update bet status and claim button
        public void UpdateStatusDisplayed()
        {
            statusLbl.Text = $"Status: {CurrentSlip.Status}";
            SetClaimBtn();
        }
    }
}
