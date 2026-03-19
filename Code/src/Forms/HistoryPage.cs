using BettingSystem.Data;
using BettingSystem.Forms.CustomControls;
using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class HistoryPage : Form
    {
        private AppUser CurrentUser;
        private readonly DatabaseManager DbManager = new DatabaseManager();
        private SessionManager CurrentSession;

        private List<BetHistorySlip> BetSlips;
        private BetSlipFilter SlipFilter;
        private Dictionary<int, GameResult> GameResults;
        private string CurrentStatusFilter = "All";
        private bool SortingDateAsc = false;


        public HistoryPage(AppUser loggedInUser, SessionManager sessionManager)
        {
            CurrentUser = loggedInUser;
            CurrentSession = sessionManager;
            BetSlips = CurrentSession.HistoryBetSlips;
            SlipFilter = new BetSlipFilter(BetSlips);

            //GameResults = sessionManager.GameResults;

            InitializeComponent();

            navBar1.SetCurrentUser(CurrentUser);
            SetRadioBtnTag();

            _ = LoadPage();

            //navbar events
            navBar1.MatchesClicked += NavBar1_MatchesClicked;
            navBar1.BetSlipClicked += NavBar1_BetSlipClicked;
            navBar1.AccountClicked += NavBar1_AccountClicked;
            navBar1.LogoutClicked += NavBar1_LogoutClicked;

            //resize bet slips panels
            slipsFlowLayoutPanel.SizeChanged += UpdateSlipPanel;

            this.FormClosing += HistoryPage_FormClosing;
        }

        private void HistoryPage_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!CurrentSession.IsLoggingOut && !CurrentSession.IsExiting)
            {
                logOutPopup closingPopup = new logOutPopup(false);
                if (closingPopup.ShowDialog() == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    CurrentSession.IsExiting = true;
                    Application.Exit();
                }
            }
        }

        private void NavBar1_LogoutClicked(object? sender, EventArgs e)
        {
            if (!CurrentSession.IsLoggingOut)
            {
                logOutPopup closingPopup = new logOutPopup(true);
                if (closingPopup.ShowDialog() == DialogResult.Yes)
                    CurrentSession.LogOut(this);
            }
        }
        private void SetRadioBtnTag()
        {
            newestRadioBtn.Tag = false;
            oldestRadioBtn.Tag = true;

            allRadioBtn.Tag = "All";
            wonRadioBtn.Tag = "Won";
            lostRadioBtn.Tag = "Lost";
            pendingRadioBtn.Tag = "Pending";

            newestRadioBtn.Checked = true;
            allRadioBtn.Checked = true;
        }

        private async Task FetchData()
        {
            var gameIds = BetSlips
                .SelectMany(slip => slip.Bets)
                .Select(bet => bet.GameId)
                .Distinct()
                .ToList();

            //fetch game results
            GameResults = await DbManager.FetchGameResultsAsync(gameIds);
        }

        public async Task LoadPage()
        {
            await FetchData();
            DisplaySlips();
            UpdateSlipPanel(null, null);
        }

        private void DisplaySlips()
        {
            slipsFlowLayoutPanel.Hide();
            slipsFlowLayoutPanel.Controls.Clear();

            // check if user has no bet slips
            if (BetSlips is null || BetSlips.Count == 0)
            {
                Label noSlipsLbl = new Label();
                noSlipsLbl.Text = "No Bet Slips Found.";
                noSlipsLbl.Font = new Font("Times New Roman", 22, FontStyle.Bold);
                noSlipsLbl.ForeColor = Color.FromArgb(241, 241, 241);
                noSlipsLbl.Width = slipsFlowLayoutPanel.ClientSize.Width - slipsFlowLayoutPanel.Padding.Horizontal;
                noSlipsLbl.Height = 300;
                noSlipsLbl.TextAlign = ContentAlignment.MiddleCenter;
                slipsFlowLayoutPanel.Controls.Add(noSlipsLbl);
                slipsFlowLayoutPanel.Show();
                return;
            }

            //display slips
            foreach (BetHistorySlip slip in BetSlips)
            {
                BetSlipPanel slipPanel = new BetSlipPanel(slip, CurrentUser);
                slipPanel.Margin = new Padding(0, 15, 0, 0);
                slipPanel.ClaimClicked += SlipPanel_ClaimClicked;
                slipPanel.Click += SlipPanel_Click;
                slipPanel.Tag = slip;
                slipsFlowLayoutPanel.Controls.Add(slipPanel);
            }
            UpdateSlipPanel(null, null);
            slipsFlowLayoutPanel.Show();
        }

        private void SlipPanel_Click(object sender, EventArgs e)
        {
            BetHistorySlip slip = (BetHistorySlip)((Control)sender).Tag!;
            HistoryBetsPopup editPopup = new HistoryBetsPopup(slip.Bets, GameResults);
            editPopup.ShowDialog();
        }

        private async void SlipPanel_ClaimClicked(BetHistorySlip claimedSlip, bool valid, string message)
        {
            if (valid)
            {
                new Notification(message, NotificationType.Success, this);
                
                //upate wallet balance in nav bar
                navBar1.DisplayInfo();
                return;
            }
            //display message
            new Notification(message, NotificationType.Error, this);
        }

        private void UpdateSlipPanel(object sender, EventArgs e)
        {
            foreach (Control slipPanel in slipsFlowLayoutPanel.Controls)
            {
                slipPanel.Width = slipsFlowLayoutPanel.ClientSize.Width - slipsFlowLayoutPanel.Padding.Horizontal;
            }
        }

        private void applyFilterBtn_Click(object sender, EventArgs e)
        {
            var dateSortChecked = SortDateBtnPanel.Controls
                            .OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked);

            var statusChecked = filterStatusBtnPanel.Controls
                            .OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked);

            bool selectedSortingDateAsc = (bool)dateSortChecked!.Tag!;
            string selectedStatus = (string)statusChecked!.Tag!;

            //filter and sort only if there is a change
            if (selectedSortingDateAsc != SortingDateAsc || selectedStatus != CurrentStatusFilter)
            {
                SortingDateAsc = selectedSortingDateAsc;
                CurrentStatusFilter = selectedStatus;

                BetSlips = SlipFilter.FilterBetSlips(selectedStatus, selectedSortingDateAsc);
                DisplaySlips();
            }
        }

        public async Task ReInitialisePage()
        {
            newestRadioBtn.Checked = true;
            allRadioBtn.Checked = true;

            CurrentStatusFilter = "All";
            SortingDateAsc = false;

            applyFilterBtn_Click(null, null);
            DisplaySlips();
        }

        //change pages
        private void NavBar1_MatchesClicked(object? sender, EventArgs e)
        {
            CurrentSession.OpenMainPage(this);
        }
        private void NavBar1_BetSlipClicked(object? sender, EventArgs e)
        {
            CurrentSession.OpenBetSlipPage(this);
        }
        private void NavBar1_AccountClicked(object? sender, EventArgs e)
        {
            CurrentSession.OpenMainPage(this);
        }
    }
}
