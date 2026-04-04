using BettingSystem.Data;
using BettingSystem.Forms.CustomControls;
using BettingSystem.Models;
using BettingSystem.Services;
using BettingSystem.Data_Structures;

namespace BettingSystem.Forms
{
    public partial class BetSlipPage : BaseForm
    {
        private AppUser _currentUser;
        private SessionManager _currentSession;
        private BetSlip _userSlip;
        private FootballMatchCollection _matchesCollection;
        private MyDictionary<int, Team> _teamsDict;
        private MyDictionary<int, MyList<Player>> _players;
        private League[] _leagues;

        private readonly DatabaseManager _dbManager = new DatabaseManager();

        private Dictionary<int, string> _betTypeNames;

        public BetSlipPage(AppUser user, SessionManager session)
        {
            InitializeComponent();
            _currentUser = user;
            _currentSession = session;
            _userSlip = session.UserSlip;
            _matchesCollection = session.MatchesCollection;
            _teamsDict = session.TeamsDict;
            _players = session.Players;
            _leagues = session.Leagues;

            navBar1.SetCurrentUser(_currentUser);
            navBar1.MatchesClicked += NavBar1_MatchesClicked;
            navBar1.AccountClicked += NavBar1_AccountClicked;
            navBar1.LogoutClicked += NavBar1_LogoutClicked;

            txtStake.TextChanged += txtStake_TextChanged;
            btnPlaceBet.Click += btnPlaceBet_Click;

            this.Load += BetSlipPage_Load;
            this.FormClosing += BetSlipPage_FormClosing;

            _currentSession.AppSimulator.BetSlipUpdated += AppSimulator_BetSlipUpdated;
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
            if (!_currentSession.IsLoggingOut && !_currentSession.IsExiting)
            {
                logOutPopup closingPopup = new logOutPopup(false, true);
                if (closingPopup.ShowDialog() == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _currentSession.IsExiting = true;
                    Application.Exit();
                }
            }
        }

        private void NavBar1_LogoutClicked(object? sender, EventArgs e)
        {
            if (!_currentSession.IsLoggingOut)
            {
                logOutPopup closingPopup = new logOutPopup(true);
                if (closingPopup.ShowDialog() == DialogResult.Yes)
                    _currentSession.LogOut(this);
            }
        }

        private async void BetSlipPage_Load(object sender, EventArgs e)
        {
            _betTypeNames = await _dbManager.FetchBetTypesAsync();
            CaptureBaseLayout();
            LoadBetSlips();
        }

        public void ReloadSlip()
        {
            _userSlip = _currentSession.UserSlip;
            LoadBetSlips();
        }

        private void LoadBetSlips()
        {
            //clear stake
            txtStake.Clear();
            pnlSlipList.Controls.Clear();
            pnlSummaryContainer.Hide();

            if (!_userSlip.Bets.Any())
            {
                Label emptyLbl = new Label();
                emptyLbl.Text = "Your bet slip is empty.";
                emptyLbl.Font = new Font("Times New Roman", 22, FontStyle.Bold);
                emptyLbl.ForeColor = Color.FromArgb(241, 241, 241);
                emptyLbl.Height = 300;
                emptyLbl.TextAlign = ContentAlignment.MiddleCenter;
                emptyLbl.Dock = DockStyle.Fill;
                pnlSlipList.Controls.Add(emptyLbl);
                return;
            }

            foreach (Bet bet in _userSlip.Bets)
            {
                FootballMatch? match = _matchesCollection.AllMatches
                    .FirstOrDefault(m => m.GameID == bet.GameID);

                if (match is null)
                {
                    continue;
                }

                Team homeTeam = _teamsDict[match.HomeTeamID];
                Team awayTeam = _teamsDict[match.AwayTeamID];
                string leagueName = _leagues.First(l => l.LeagueId == match.LeagueID).Name;
                string betTypeName = _betTypeNames.TryGetValue(bet.BetTypeID, out string? name) ? name : "Unknown";
                string userSelection;

                // get player's name
                if (bet.BetTypeID == 6)
                {
                    MyList<Player> playerList = GetPlayers(homeTeam.TeamId, awayTeam.TeamId);
                    userSelection = playerList.FirstOrDefault(p => p.PlayerId == int.Parse(bet.Selection))?.Name ?? "Unknown";
                }
                else
                {
                    userSelection = bet.Selection;
                }
                var card = new BetCard();
                card.SetData(
                    leagueName,
                    homeTeam.TeamName,
                    awayTeam.TeamName,
                    betTypeName,
                    userSelection,
                    bet.OddValue.ToString("F2"),
                    match.GameDate
                );
                card.OnRemove += () =>
                {
                    _userSlip.RemoveBet(bet);
                    pnlSlipList.Controls.Remove(card);
                    card.Dispose();

                    // show empty message if no bets left
                    if (!_userSlip.Bets.Any())
                        LoadBetSlips();
                };
                AddCard(card);
            }

            UpdateSummary();
        }

        private MyList<Player> GetPlayers(int homeId, int awayId)
        {
            MyList<Player> gamePlayers = new MyList<Player>();

            if (_players.TryGetValue(homeId, out var homePlayers))
            {
                gamePlayers.AddRange(homePlayers);
            }
            if (_players.TryGetValue(awayId, out var awayPlayers))
            {
                gamePlayers.AddRange(awayPlayers);
            }
            return gamePlayers;
        }
        private void UpdateSummary()
        {
            lblTotalOdds.Text = _userSlip.TotalOdds.ToString("F2");
            lblPayout.Text = $"${_userSlip.CalculatePayout():F2}";
            pnlSummaryContainer.Show();
        }

        private void txtStake_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtStake.Text, out decimal stake))
            {
                _userSlip.Stake = stake;
                lblPayout.Text = $"${_userSlip.CalculatePayout():F2}";
            }
            else
            {
                _userSlip.Stake = 0;
                lblPayout.Text = "$0.00";
            }
        }

        private async void btnPlaceBet_Click(object sender, EventArgs e)
        {
            // validate slip is not empty
            if (!_userSlip.Bets.Any())
            {
                new Notification("Your bet slip is empty.", NotificationType.Error, this);
                return;
            }

            var startedBets = _userSlip.Bets.Where(b => b.Date <= DateTime.Now).ToList();

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
            if (stake > _currentUser.WalletBalance)
            {
                new Notification("Insufficient balance.", NotificationType.Error, this);
                return;
            }

            _userSlip.Stake = stake;

            btnPlaceBet.Enabled = false;

            // save bet slip to database
            (bool success, string message) = await _dbManager.SaveBetSlipAsync(_userSlip);

            if (!success)
            {
                new Notification(message, NotificationType.Error, this);
                btnPlaceBet.Enabled = true;
                return;
            }

            // deduct stake from wallet
            decimal newBalance = _currentUser.WalletBalance - stake;
            bool walletUpdated = await _dbManager.ProcessWalletTransactionAsync(
                _currentUser.UserID,
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
            _currentUser.WalletBalance = newBalance;
            navBar1.DisplayInfo();

            // reset slip
            _userSlip.Bets.Clear();
            _userSlip.Stake = 0;

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

            pnlSlipList.Controls.Add(card);
            pnlSlipList.Controls.Add(spacer);
        }

        private void NavBar1_MatchesClicked(object? sender, EventArgs e)
        {
            _currentSession.OpenMainPage(this);
        }

        private void NavBar1_AccountClicked(object? sender, EventArgs e)
        {
            _currentSession.OpenProfilePage(this);
        }
    }
}