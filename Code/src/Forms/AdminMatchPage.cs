using BettingSystem.Data;
using BettingSystem.Data_Structures;
using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class AdminMatchPage : Form
    {
        private readonly ImageLoader _imgLoader = new ImageLoader();
        private readonly DatabaseManager _dbManager = new DatabaseManager();
        private MatchManager _matchFilter;
        private SessionManager _currentSession;
        private League[] _leagues;
        private FootballMatchCollection _matchesCollection;
        private MyDictionary<int, Team> _teamsDict;
        private MyDictionary<int, GameResult> _gameResults;

        private int CurrentLeague = 0;
        private string CurrentSearchTerm = "";
        private AppUser _admin;

        public AdminMatchPage(AppUser admin, SessionManager currentSession)
        {
            InitializeComponent();

            _currentSession = currentSession;
            _leagues = _currentSession.Leagues;
            _matchesCollection = _currentSession.MatchesCollection;
            _teamsDict = _currentSession.TeamsDict;
            _gameResults = _currentSession.GameResults;

            _matchFilter = new MatchManager(_matchesCollection, _teamsDict);

            _admin = admin;
            adminNavBar1.SetAdmin(_admin);

            //navbar events
            adminNavBar1.UsersPageClicked += AdminNavBar1_UsersPageClicked;
            adminNavBar1.AddMatchesPageClicked += AdminNavBar1_AddMatchPageClicked;
            adminNavBar1.LogoutClicked += AdminNavBar1_LogoutClicked;
            adminNavBar1.FinancialPageClicked += AdminNavBar1_FinancialPageClicked;

            this.Load += LoadPage;
            this.FormClosing += AdminMatchPage_FormClosing;
            matchDataGridView.CellClick += MatchDataGridView_CellClick;

            //update status displayed
            _currentSession.AppSimulator.MatchStatusUpdated += _appSimulator_MatchStatusUpdated;

            searchbarTextBox.KeyDown += Searchbar_KeyDown;
        }

        private void _appSimulator_MatchStatusUpdated()
        {
            //checks if it is on UI thread
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(_appSimulator_MatchStatusUpdated));
                return;
            }

            //updates status displayed
            foreach(DataGridViewRow row in matchDataGridView.Rows)
            {
                if (row.Tag is FootballMatch match)
                {
                    row.Cells[6].Value = match.GameStatus;
                }
            }
        }

        public async Task OnShow()
        {
            //subscribe to simulator event
            _currentSession.AppSimulator.MatchStatusUpdated += _appSimulator_MatchStatusUpdated;
            await Reset();
        }
        public void OnHide()
        {
            //unsubscribe to simulator event
            _currentSession.AppSimulator.MatchStatusUpdated -= _appSimulator_MatchStatusUpdated;
        }

        private void MatchDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            //check if header was clicked
            if (e.RowIndex < 0)
                return;

            FootballMatch selectedMatch = (FootballMatch)matchDataGridView.Rows[e.RowIndex].Tag;

            if (selectedMatch.GameStatus != "Completed")
            {
                new Notification("Results will be available after match is completed", NotificationType.Info, this);
                return;
            }
            if (_gameResults.TryGetValue(selectedMatch.GameID, out var gameResults))
            {
                //open popup with match outcomes
                MatchResultPopup resultPopup = new MatchResultPopup(gameResults, _teamsDict[selectedMatch.HomeTeamID].TeamName, _teamsDict[selectedMatch.AwayTeamID].TeamName);
                resultPopup.ShowDialog();
            }
            else
            {
                new Notification("No Results available for this match", NotificationType.Info, this);
            }
        }

        private async void LoadPage(object? sender, EventArgs e)
        {
            SetLeaguesRadioBtnTag();
            allRadioBtn.Checked = true;
            AddColumnHeaders();
            await DisplayMatches(_matchesCollection.AllMatches);
        }

        private void AddColumnHeaders()
        {
            matchDataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Match Date",
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" },
                FillWeight = 15,
            });

            matchDataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "League",
                FillWeight = 12,
            });

            matchDataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Home Team",
                FillWeight = 15,
            });

            matchDataGridView.Columns.Add(new DataGridViewImageColumn()
            {
                HeaderText = "Home Team Logo",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                FillWeight = 20,
            });

            matchDataGridView.Columns.Add(new DataGridViewImageColumn()
            {
                HeaderText = "Away Team Logo",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                FillWeight = 20,
            });

            matchDataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Away Team",
                FillWeight = 15,
            });

            matchDataGridView.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Status",
                FillWeight = 10,
            });
        }

        private void SetLeaguesRadioBtnTag()
        {
            allRadioBtn.Tag = 0;
            premierRadioBtn.Tag = 1;
            championsLeagueRadioBtn.Tag = 2;
            liguaRadioBtn.Tag = 3;
            serieAradioButton.Tag = 4;
            ligue1RadioButton.Tag = 5;
        }

        //display matches on the DataGridView
        private async Task DisplayMatches(MyList<FootballMatch> footballMatches)
        {
            matchDataGridView.Hide();
            matchDataGridView.Rows.Clear();

            // check if there are no matches
            if (footballMatches.Count == 0)
            {
                noMatchLbl.Visible = true;
                return;
            }

            noMatchLbl.Visible = false;

            foreach (FootballMatch game in footballMatches)
            {
                Team homeTeam = _teamsDict[game.HomeTeamID];
                Team awayTeam = _teamsDict[game.AwayTeamID];
                var league = _leagues.FirstOrDefault(l => l.LeagueId == game.LeagueID);
                string leagueName = league?.Name ?? "Unknown";

                var homeTask = _imgLoader.GetImageAsync(homeTeam.LogoPath);
                var awayTask = _imgLoader.GetImageAsync(awayTeam.LogoPath);

                await Task.WhenAll(homeTask, awayTask);

                var homeLogo = homeTask.Result;
                var awayLogo = awayTask.Result;

                int rowIndex = matchDataGridView.Rows.Add(
                    game.GameDate,
                    leagueName,
                    homeTeam.TeamName,
                    homeLogo,
                    awayLogo,
                    awayTeam.TeamName,
                    game.GameStatus
                );

                matchDataGridView.Rows[rowIndex].Tag = game;
            }

            matchDataGridView.Show();
        }

        private void AdminMatchPage_FormClosing(object? sender, FormClosingEventArgs e)
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

        private void AdminNavBar1_LogoutClicked(object? sender, EventArgs e)
        {
            if (!_currentSession.IsLoggingOut)
            {
                logOutPopup closingPopup = new logOutPopup(true, true);
                if (closingPopup.ShowDialog() == DialogResult.Yes)
                    _currentSession.LogOut(this);
            }
        }

        //to open other pages
        private void AdminNavBar1_FinancialPageClicked(object? sender, EventArgs e)
        {
            OnHide();
            _currentSession.OpenAdminFinancialPage(this);
        }

        private void AdminNavBar1_AddMatchPageClicked(object? sender, EventArgs e)
        {
            OnHide();
            _currentSession.OpenAdminAddMatchPage(this);
        }

        private void AdminNavBar1_UsersPageClicked(object? sender, EventArgs e)
        {
            OnHide();
            _currentSession.OpenAdminViewUsersPage(this);
        }

        private async Task Reset()
        {
            adminNavBar1.SetAdmin(_admin);
            CurrentSearchTerm = "";
            CurrentLeague = 0;
            allRadioBtn.Checked = true;
            searchbarTextBox.Clear();
            await DisplayMatches(_matchesCollection.AllMatches);
        }

        private async Task RefetchData()
        {
            _matchesCollection = await _dbManager.FetchMatchesAsync(true);
            _gameResults = await _dbManager.FetchGameResultsAsync(null, true);
            _leagues = await _dbManager.FetchLeaguesAsync();
            _teamsDict = await _dbManager.FetchTeamsAsync(true);
            _matchFilter = new MatchManager(_matchesCollection, _teamsDict);
        }

        private async void refreshIcon_Click(object sender, EventArgs e)
        {
            await RefetchData();
            await Reset();
        }

        // when user makes a search
        private async void Searchbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string searchedTerm = searchbarTextBox.Text.Trim();
                if (!String.IsNullOrEmpty(searchedTerm))
                {
                    await FilterMatches();
                }
            }
        }

        //filter matches by league and by searched team's name
        private async Task FilterMatches()
        {
            string searchedTerm = searchbarTextBox.Text.Trim();

            var leagueChecked = filterLeagueBtnPanel.Controls
                            .OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked);

            int selectedLeagueId = (int)leagueChecked!.Tag!;

            if (string.Equals(searchedTerm, CurrentSearchTerm, StringComparison.OrdinalIgnoreCase) && selectedLeagueId == CurrentLeague)
                return;

            CurrentLeague = selectedLeagueId;
            CurrentSearchTerm = searchedTerm;
            MyList<FootballMatch> leageMatches = CurrentLeague == 0 ? _matchesCollection.AllMatches : _matchFilter.FilterMatchByLeague(CurrentLeague);

            if (!String.IsNullOrEmpty(CurrentSearchTerm))
            {
                MyList<FootballMatch>  matchDisplayed = _matchFilter.FilterMatchByTeams(searchedTerm, leageMatches);
                await DisplayMatches(matchDisplayed);
            }
            else
            {
                await DisplayMatches(leageMatches);
            }
        }

        //clear search and show all matches in selected league
        private async void clearSearchIcon_Click(object sender, EventArgs e)
        {
            searchbarTextBox.Clear();
            CurrentSearchTerm = "";
            if (CurrentLeague == 0)
            {
                await DisplayMatches(_matchesCollection.AllMatches);
            }
            else
            {
                await DisplayMatches(_matchFilter.FilterMatchByLeague(CurrentLeague));
            }
        }

        // click button to filter by league
        private async void applyFilterBtn_Click(object sender, EventArgs e)
        {
            await FilterMatches();
        }
    }
}
