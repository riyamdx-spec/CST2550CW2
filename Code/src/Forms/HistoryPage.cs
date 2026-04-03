using BettingSystem.Data;
using BettingSystem.Data_Structures;
using BettingSystem.Forms.CustomControls;
using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class HistoryPage : Form
    {
        private AppUser _currentUser;
        private readonly DatabaseManager _dbManager = new DatabaseManager();
        private SessionManager _currentSession;
        private Simulator _appSimulator;

        private MyList<BetHistorySlip> _betSlips;
        private BetSlipFilter _slipFilter = new BetSlipFilter();
        private MyDictionary<int, GameResult> _gameResults;
        private string _currentStatusFilter = "All";
        private bool _sortingDateAsc = false;

        public HistoryPage(AppUser loggedInUser, SessionManager sessionManager)
        {
            _currentUser = loggedInUser;
            _currentSession = sessionManager;
            _betSlips = _currentSession.HistoryBetSlips;
            _appSimulator = _currentSession.AppSimulator;

            InitializeComponent();

            navBar1.SetCurrentUser(_currentUser);
            SetRadioBtnTag();

            this.Load += LoadPage;

            //navbar events
            navBar1.MatchesClicked += NavBar1_MatchesClicked;
            navBar1.BetSlipClicked += NavBar1_BetSlipClicked;
            navBar1.AccountClicked += NavBar1_AccountClicked;
            navBar1.LogoutClicked += NavBar1_LogoutClicked;

            //memory updated event
            _appSimulator.HistoryUpdated += AppSimulator_HistoryUpdated;

            //resize bet slips panels
            slipsFlowLayoutPanel.SizeChanged += UpdateSlipPanel;

            this.FormClosing += HistoryPage_FormClosing;
        }

        private void AppSimulator_HistoryUpdated()
        {
            //checks if it is on UI thread
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(AppSimulator_HistoryUpdated));
                return;
            }

            //update slips
            foreach (Control ctr in slipsFlowLayoutPanel.Controls)
            {
                if (ctr is BetSlipPanel slipPanel && ctr.Tag is BetHistorySlip slip)
                {
                    slipPanel.UpdateStatusDisplayed();
                }
            }
        }

        private void HistoryPage_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_currentSession.IsLoggingOut && !_currentSession.IsExiting)
            {
                logOutPopup closingPopup = new logOutPopup(false);
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
            _betSlips = await _dbManager.FetchBetHistoryAsync(_currentUser.UserID);
            var gameIds = _betSlips
                .SelectMany(slip => slip.Bets)
                .Select(bet => bet.GameId)
                .Distinct();

            var gameIdsList = (MyList<int>)gameIds;

            //fetch game results
            _gameResults = await _dbManager.FetchGameResultsAsync(gameIdsList);
        }

        public async void LoadPage(object sender, EventArgs e)
        {
            await FetchData();

            DisplaySlips(_betSlips);
            UpdateSlipPanel(null, null);
        }

        private void DisplaySlips(MyList<BetHistorySlip> betSlips)
        {
            slipsFlowLayoutPanel.Hide();
            slipsFlowLayoutPanel.Controls.Clear();

            // check if user has no bet slips
            if (betSlips is null || betSlips.Count == 0)
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
            foreach (BetHistorySlip slip in betSlips)
            {
                BetSlipPanel slipPanel = new BetSlipPanel(slip, _currentUser);
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
            HistoryBetsPopup editPopup = new HistoryBetsPopup(slip.Bets, _gameResults, _currentSession.Players);
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
            if (selectedSortingDateAsc != _sortingDateAsc || selectedStatus != _currentStatusFilter)
            {
                _sortingDateAsc = selectedSortingDateAsc;
                _currentStatusFilter = selectedStatus;
                DisplaySlips(_slipFilter.FilterBetSlips(_betSlips, selectedStatus, selectedSortingDateAsc));
            }
        }

        private async Task FetchNewSlips()
        {
            int lastId = _betSlips.Any() ? _betSlips.Max(s => s.SlipID) : 0;
            MyList <BetHistorySlip> newSlips = await _dbManager.FetchBetHistoryAsync(_currentUser.UserID, lastId);

            if (!newSlips.IsEmpty())
            {
                newSlips.AddRange(_betSlips);
                _betSlips = newSlips;
            }
        }

        public async Task ReInitialisePage()
        {
            newestRadioBtn.Checked = true;
            allRadioBtn.Checked = true;

            _currentStatusFilter = "All";
            _sortingDateAsc = false;

            await FetchNewSlips();
            await FetchNewGameResults();

            applyFilterBtn_Click(null, null);
            DisplaySlips(_betSlips);
        }

        private async Task FetchNewGameResults()
        {
            var gameIds = _betSlips
               .SelectMany(slip => slip.Bets)
               .Select(bet => bet.GameId)
               .Distinct();

            var missingIds = gameIds
                .Where(id => !_gameResults.ContainsKey(id));

            if (missingIds.Count() == 0)
                return;

            var missingList = (MyList<int>)missingIds;

            //fetch game results
            var newResults = await _dbManager.FetchGameResultsAsync(missingList);

            //merge wih Game Resuls
            foreach (var result in newResults)
            {
                _gameResults[result.Key] = result.Value;
            }
        }

        //change pages
        private void NavBar1_MatchesClicked(object? sender, EventArgs e)
        {
            _currentSession.OpenMainPage(this);
        }
        private void NavBar1_BetSlipClicked(object? sender, EventArgs e)
        {
            _currentSession.OpenBetSlipPage(this);
        }
        private void NavBar1_AccountClicked(object? sender, EventArgs e)
        {
            _currentSession.OpenMainPage(this);
        }
    }
}
