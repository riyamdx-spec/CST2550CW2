using BettingSystem.Data;
using BettingSystem.Data_Structures;
using BettingSystem.Models;
using BettingSystem.Services;
using System.Data;

namespace BettingSystem.Forms
{
    public partial class AdminAddMatchPage : Form
    {
        private readonly Validation _validator = new Validation();
        private readonly DatabaseManager _dbManager = new DatabaseManager();
        private MyDictionary<int, MyList<int>> _leagueTeams;
        private League[] _leagues;
        private MyDictionary<int, Team> _teamsDict;
        private MyDictionary<int, MyList<Player>> _players;

        private int _currentLeagueID = -1;
        private SessionManager _currentSession;

        public AdminAddMatchPage(AppUser admin, SessionManager currentSession)
        {
            InitializeComponent();
        
            CenterPanel(null, null);
            contentPanel.Resize += CenterPanel;

            _currentSession = currentSession;
            _leagues = _currentSession.Leagues;
            _teamsDict = _currentSession.TeamsDict;
            _players = _currentSession.Players;

            adminNavBar1.SetAdmin(admin);

            //navbar events
            adminNavBar1.UsersPageClicked += AdminNavBar1_UsersPageClicked;
            adminNavBar1.SearchMatchesPageClicked += AdminNavBar1_SearchMatchesPageClicked;
            adminNavBar1.LogoutClicked += AdminNavBar1_LogoutClicked;
            adminNavBar1.FinancialPageClicked += AdminNavBar1_FinancialPageClicked;

            this.Load += LoadPage;
            this.FormClosing += AdminAddMatchPage_FormClosing;
            leagueComboBox.SelectedIndexChanged += LeagueComboBox_SelectedIndexChanged;
        }

        private void AdminAddMatchPage_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_currentSession.IsLoggingOut && !_currentSession.IsExiting)
            {
                logOutPopup closingPopup = new logOutPopup(false, true);

                DialogResult result = closingPopup.ShowDialog(); 

                if (result != DialogResult.Yes)
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
            _currentSession.OpenAdminFinancialPage(this);
        }


        private async void AdminNavBar1_SearchMatchesPageClicked(object? sender, EventArgs e)
        {
            await _currentSession.OpenAdminMatchPage(this);
        }

        private void AdminNavBar1_UsersPageClicked(object? sender, EventArgs e)
        {
            _currentSession.OpenAdminViewUsersPage(this);
        }

        private void LeagueComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {

            AddMatchComboItems selectedLeague = leagueComboBox.SelectedItem as AddMatchComboItems;
            if (selectedLeague == null)
            {
                _currentLeagueID = -1;
                homeTeamComboBox.Items.Clear();
                awayTeamComboBox.Items.Clear();
                return;
            }
            if (_currentLeagueID == selectedLeague.ID)
                return;

            _currentLeagueID = selectedLeague.ID;
            DisplayTeams();
        }

        private void CenterPanel(object? sender, EventArgs e)
        {
            addMatchFormBg.Top = (contentPanel.Height - addMatchFormBg.Height) / 2;
            addMatchFormBg.Left = (contentPanel.Width - addMatchFormBg.Width) / 2;
        }

        public async void LoadPage(object sender, EventArgs e)
        {
            _leagueTeams = await _dbManager.FetchLeagueTeamAsync();
            DisplayLeagueNames();
            selectedMatchDate.MinDate = DateTime.Now.AddMinutes(5);
            leagueComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            homeTeamComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            awayTeamComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void DisplayLeagueNames()
        {
            foreach (League league in _leagues)
            {
                AddMatchComboItems leagueComboItem = new AddMatchComboItems(league.LeagueId, league.Name);
                leagueComboBox.Items.Add(leagueComboItem);
            }

            leagueComboBox.SelectedIndex = -1;
        }

        public void DisplayTeams()
        {
            homeTeamComboBox.Text = "";
            awayTeamComboBox.Text = "";

            homeTeamComboBox.Items.Clear();
            awayTeamComboBox.Items.Clear();

            AddMatchComboItems selectedLeague = leagueComboBox.SelectedItem as AddMatchComboItems;
            var teams = _leagueTeams[selectedLeague.ID]
                .Select(id => _teamsDict[id])
                .ToList();

            foreach (var team in teams)
            {
                AddMatchComboItems teamComboItem = new AddMatchComboItems(team.TeamId, team.TeamName);
                homeTeamComboBox.Items.Add(teamComboItem);
                awayTeamComboBox.Items.Add(teamComboItem);
            }
            homeTeamComboBox.SelectedIndex = -1;
            awayTeamComboBox.SelectedIndex = -1;
        }

        private async void addMatchBtn_Click(object sender, EventArgs e)
        {
            if (leagueComboBox.SelectedIndex == -1 || homeTeamComboBox.SelectedIndex == -1 || awayTeamComboBox.SelectedIndex == -1)
            {
                new Notification("All fields must be filled", NotificationType.Warning, this);
                return;
            }
            AddMatchComboItems selectedHomeTeam = homeTeamComboBox.SelectedItem as AddMatchComboItems;
            AddMatchComboItems selectedAwayTeam = awayTeamComboBox.SelectedItem as AddMatchComboItems;

            if (selectedHomeTeam is null || selectedAwayTeam is null)
            {
                new Notification("Selections Invalid", NotificationType.Error, this);
                return;
            }

            DateTime matchDate = selectedMatchDate.Value;
            (bool valid, string? message) = _validator.CheckMatchEntries(selectedHomeTeam.ID, selectedAwayTeam.ID, matchDate);
            if (!valid)
            {
                new Notification(message, NotificationType.Warning, this);
                return;
            }

            AddMatchComboItems selectedLeague = leagueComboBox.SelectedItem as AddMatchComboItems;

            FootballMatch newMatch = new FootballMatch(0, selectedLeague.ID, selectedHomeTeam.ID, selectedAwayTeam.ID, matchDate);
            AddNewMatchService addNewMatch = new AddNewMatchService(newMatch, _players[selectedHomeTeam.ID], _players[selectedAwayTeam.ID], _currentSession);

            (valid, message, GameResult generatedResult) = await addNewMatch.AddMatchToDatabase();
            if (!valid)
            {
                new Notification(message, NotificationType.Error, this);
                return;
            }
            Reset();
            new Notification(message, NotificationType.Success, this);
        }

        public void Reset()
        {
            _currentLeagueID = -1;
            leagueComboBox.SelectedIndex = -1;
            homeTeamComboBox.Text = "";
            awayTeamComboBox.Text = "";
            homeTeamComboBox.Items.Clear();
            awayTeamComboBox.Items.Clear();
            homeTeamComboBox.SelectedIndex = -1;
            awayTeamComboBox.SelectedIndex = -1;
            selectedMatchDate.Value = DateTime.Now.AddMinutes(5);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
