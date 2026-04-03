using BettingSystem.Data;
using BettingSystem.Forms.CustomControls;
using BettingSystem.Models;
using BettingSystem.Services;
using BettingSystem.Data_Structures;

namespace BettingSystem.Forms
{
    public partial class BetSlipPage : BaseForm
    {
        private AppUser CurrentUser;
        private SessionManager CurrentSession;
        private BetSlip UserSlip;
        private FootballMatchCollection MatchesCollection;
        private MyDictionary<int, Team> TeamsDict;
        private League[] Leagues;

        private readonly DatabaseManager DBManager = new DatabaseManager();

        private Dictionary<int, string> BetTypeNames;

        public BetSlipPage(AppUser user, SessionManager session)
        {
            InitializeComponent();
            CurrentUser = user;
            CurrentSession = session;
            UserSlip = session.UserSlip;
            MatchesCollection = session.MatchesCollection;
            TeamsDict = session.TeamsDict;
            Leagues = session.Leagues;

            navBar1.SetCurrentUser(CurrentUser);
            navBar1.MatchesClicked += NavBar1_MatchesClicked;
            navBar1.AccountClicked += NavBar1_AccountClicked;
            navBar1.LogoutClicked += NavBar1_LogoutClicked;

            this.Load += BetSlipPage_Load;
            this.FormClosing += BetSlipPage_FormClosing;

            CurrentSession.AppSimulator.BetSlipUpdated += AppSimulator_BetSlipUpdated;
        }

        private void AppSimulator_BetSlipUpdated()
        {
            //checks if it is on UI thread
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(AppSimulator_BetSlipUpdated));
                return;
            }

            ReloadSlip();
        }

        private void BetSlipPage_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!CurrentSession.IsLoggingOut && !CurrentSession.IsExiting)
            {
                logOutPopup closingPopup = new logOutPopup(false, true);
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

        private async void BetSlipPage_Load(object sender, EventArgs e)
        {
            BetTypeNames = await DBManager.FetchBetTypesAsync();
            CaptureBaseLayout();
            LoadBetSlips();
        }

        public void ReloadSlip()
        {
            UserSlip = CurrentSession.UserSlip;
            LoadBetSlips();
            UpdateSummary();
        }

        private void LoadBetSlips()
        {
            pnlSlipList.Controls.Clear();
            if (!UserSlip.Bets.Any())
            {
                Label emptyLbl = new Label();
                emptyLbl.Text = "Your bet slip is empty.";
                emptyLbl.Font = new Font("Times New Roman", 22, FontStyle.Bold);
                emptyLbl.ForeColor = Color.FromArgb(241, 241, 241);
                emptyLbl.Height = 300;
                emptyLbl.TextAlign = ContentAlignment.MiddleCenter;
                emptyLbl.Dock = DockStyle.Fill;
                pnlSlipList.Controls.Add(emptyLbl);
                pnlSummaryContainer.Hide();
                return;

            }

            foreach (Bet bet in UserSlip.Bets)
            {
                FootballMatch match = MatchesCollection.AllMatches
                    .First(m => m.GameID == bet.GameID);

                Team homeTeam = TeamsDict[match.HomeTeamID];
                Team awayTeam = TeamsDict[match.AwayTeamID];
                string leagueName = Leagues.First(l => l.LeagueId == match.LeagueID).Name;
                string betTypeName = BetTypeNames.TryGetValue(bet.BetTypeID, out string? name) ? name : "Unknown";

                var card = new BetCard();
                card.SetData(
                    leagueName,
                    homeTeam.TeamName,
                    awayTeam.TeamName,
                    betTypeName,
                    bet.Selection,
                    bet.OddValue.ToString("F2"),
                    match.GameDate
                );
                card.OnRemove += () =>
                {
                    UserSlip.RemoveBet(bet);
                    pnlSlipList.Controls.Remove(card);
                    card.Dispose();

                    // show empty message if no bets left
                    if (!UserSlip.Bets.Any())
                        LoadBetSlips();
                };
                AddCard(card);
            }

            UpdateSummary();
        }

        private void UpdateSummary()
        {
            lblTotalOdds.Text = UserSlip.TotalOdds.ToString("F2");
            lblPayout.Text = $"${UserSlip.CalculatePayout():F2}";
            pnlSummaryContainer.Show();
        }

        private void txtStake_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtStake.Text, out decimal stake))
            {
                UserSlip.Stake = stake;
                lblPayout.Text = $"${UserSlip.CalculatePayout():F2}";
            }
            else
            {
                UserSlip.Stake = 0;
                lblPayout.Text = "$0.00";
            }
        }

        private async void btnPlaceBet_Click(object sender, EventArgs e)
        {
            // validate slip is not empty
            if (!UserSlip.Bets.Any())
            {
                new Notification("Your bet slip is empty.", NotificationType.Error, this);
                return;
            }

            var startedBets = UserSlip.Bets.Where(b => b.Date <= DateTime.Now).ToList();

            // check if match has already started before confirming bet slip
            if (startedBets.Any())
            {
                new Notification("Cannot place bet. One or more matches have already started.", NotificationType.Error, this);
                return;
            }

            // validate stake
            if (!decimal.TryParse(txtStake.Text, out decimal stake) || stake <= 0)
            {
                new Notification("Please enter a valid stake.", NotificationType.Error, this);
                return;
            }

            // check user has enough balance
            if (stake > CurrentUser.WalletBalance)
            {
                new Notification("Insufficient balance.", NotificationType.Error, this);
                return;
            }

            UserSlip.Stake = stake;

            btnPlaceBet.Enabled = false;

            // save bet slip to database
            (bool success, string message) = await DBManager.SaveBetSlipAsync(UserSlip);

            if (!success)
            {
                new Notification(message, NotificationType.Error, this);
                btnPlaceBet.Enabled = true;
                return;
            }

            // deduct stake from wallet
            decimal newBalance = CurrentUser.WalletBalance - stake;
            bool walletUpdated = await DBManager.ProcessWalletTransactionAsync(
                CurrentUser.UserID,
                "bet",
                newBalance,
                stake
            );

            if (!walletUpdated)
            {
                new Notification("Bet placed but wallet update failed. Please contact support.", NotificationType.Error, this);
                btnPlaceBet.Enabled = true;
                return;
            }

            // update balance in memory
            CurrentUser.WalletBalance = newBalance;
            navBar1.DisplayInfo();

            // reset slip
            UserSlip.Bets.Clear();
            UserSlip.Stake = 0;

            // show confirmation
            new Notification("Bet placed successfully!", NotificationType.Success, this);

            // reload to show empty state
            LoadBetSlips();
            txtStake.Clear();
            btnPlaceBet.Enabled = true;
        }

        private void AddCard(BetCard card)
        {
            card.Dock = DockStyle.Top;
            card.Margin = new Padding(0);

            // spacer panel for gap between cards
            Panel spacer = new Panel();
            spacer.Dock = DockStyle.Top;
            spacer.Height = 15;
            spacer.BackColor = Color.Transparent;

            // add spacer first, then card 
            pnlSlipList.Controls.Add(spacer);
            pnlSlipList.Controls.Add(card);
        }

        private void NavBar1_MatchesClicked(object? sender, EventArgs e)
        {
            CurrentSession.OpenMainPage(this);
        }

        private void NavBar1_AccountClicked(object? sender, EventArgs e)
        {
            CurrentSession.OpenProfilePage(this);
        }
    }
}