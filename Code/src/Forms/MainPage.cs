using BettingSystem.Data;
using BettingSystem.Data_Structures;
using BettingSystem.Forms.CustomControls;
using BettingSystem.Models;
using BettingSystem.Services;
using System.Drawing.Drawing2D;

namespace BettingSystem.Forms
{
    public partial class MainPage : Form
    {
        private AppUser CurrentUser;

        private readonly DatabaseManager DBManager = new DatabaseManager();
        private readonly ImageLoader ImgLoader = new ImageLoader();
        private readonly Validation validator = new Validation();

        private League[] Leagues;
        private MyDictionary<int, Team> TeamsDict;
        private MyDictionary<int, MyList<Odd>> Odds;
        private MyDictionary<int, MyList<Player>> Players;
        private FootballMatchCollection MatchesCollection;

        private MatchManager MatchFilter;
        private SessionManager CurrentSession;

        private BetSlip UserSlip;
        private int CurrentMatchId;
        private int CurrentLeague;
        private string CurrentSearchTerm="";

        private readonly MyList<TableLayoutPanel> BtnParentPanel = new MyList<TableLayoutPanel>();
        private MyList<RoundedButton> BetButtons = new MyList<RoundedButton>();

        public MainPage(AppUser loggedInUser, SessionManager sessionManager)
        {
            CurrentUser = loggedInUser;
            CurrentSession = sessionManager;
            InitializeComponent();

            navBar1.SetCurrentUser(CurrentUser);
            UserSlip = CurrentSession.UserSlip;
            Players = CurrentSession.Players;
            MatchesCollection = CurrentSession.MatchesCollection;

            // list of panels that contain bet buttons
            BtnParentPanel = new MyList<TableLayoutPanel> 
            {   
                OutcomeTableLayout, 
                chanceTableLayout, 
                overUnderTableLayout, 
                bttsTableLayoutPanel, 
                cornersTableLayoutPanel, 
                yellowCardsTableLayoutPanel, 
                redCardsTableLayoutPanel 
            };

            //resize match panels
            matchesFlowLayoutPanel.SizeChanged += updateMatchesPanelWidth;
            updateMatchesPanelWidth(null, null);

            //round corners of banner
            bannerImg.SizeChanged += RoundBannerPictureBox;
            RoundBannerPictureBox(null, null);

            //navbar events
            navBar1.AccountClicked += NavBar1_AccountClicked;
            navBar1.BetSlipClicked += NavBar1_BetSlipClicked;
            navBar1.LogoutClicked += NavBar1_LogoutClicked;

            //make a search
            searchbarTextBox.KeyDown += Searchbar_KeyDown;

            //click to expand or collapse sections in bet panel
            matchResultDropdown.Click += MatchResultDropdown_Click;
            goalScorerDropdown.Click += GoalScorersDropdown_Click;
            statsDropdown.Click += StatsDropdown_Click;

            //when user selects a player from the dropdown in bet panel
            playersComboBox.SelectedIndexChanged += PlayersComboBox_SelectedIndexChanged;

            this.Load += MainPage_Load;
            this.FormClosing += MainPage_FormClosing;
        }

        private async void MainPage_Load(object sender, EventArgs e)
        {
            CurrentLeague = 0;

            Leagues = await DBManager.FetchLeaguesAsync();

            await FetchData();
            Odds = await DBManager.FetchOddsAsync();

            DisplayLeagueButtons();

            //display matches
            LoadMatches(MatchesCollection.AllMatches);

            SetButtonTags();
        }

        private async void MainPage_FormClosing(object? sender, FormClosingEventArgs e)
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

        private async void NavBar1_LogoutClicked(object? sender, EventArgs e)
        {
            if (!CurrentSession.IsLoggingOut)
            {
                logOutPopup closingPopup = new logOutPopup(true);
                if (closingPopup.ShowDialog() == DialogResult.Yes)
                {
                    CurrentSession.LogOut(this);
                }

            }
        }

        //fetch teams, matches and players initially
        private async Task FetchData()
        {
            TeamsDict = await DBManager.FetchTeamsAsync();

            //MatchesCollection = await DBManager.FetchMatchesAsync();

            // initialize match filter to filter matches by league or teams
            MatchFilter = new MatchManager(MatchesCollection, TeamsDict);

            //Players = await DBManager.FetchPlayersAsync();
        }

        //display league buttons
        private async void DisplayLeagueButtons()
        {
            //button for viewing all matches
            leagueButton allMatchBtn = new leagueButton();

            await allMatchBtn.setImage(@"..\..\..\..\Assets\globe.png");
            allMatchBtn.Dock = DockStyle.Fill;
            allMatchBtn.Margin = new Padding(12, 0, 12, 4);
            allMatchBtn.Cursor = Cursors.Hand;
            allMatchBtn.Click += AllMatchesClicked;

            leaguePanel.Controls.Add(allMatchBtn);

            foreach (League league in Leagues)
            {
                leagueButton leagueBtn = new leagueButton();
                
                await leagueBtn.setImage(league.LogoPath);

                leagueBtn.Tag = league;
                leagueBtn.Dock = DockStyle.Fill;
                leagueBtn.Margin = new Padding(12, 0, 12, 4);
                leagueBtn.Cursor = Cursors.Hand;
                leagueBtn.Click += LeagueButtonClicked;

                leaguePanel.Controls.Add(leagueBtn);
            }
        }

        // display matches on the main page
        private void LoadMatches(MyList<FootballMatch> footballMatches)
        {
            ClearMatches();

            // check if there are no matches
            if (footballMatches.Count == 0)
            {
                Label noMatchLbl = new Label();
                noMatchLbl.Text = "No Matches Found.";
                noMatchLbl.Font = new Font("Times New Roman", 22, FontStyle.Bold);
                noMatchLbl.ForeColor = Color.FromArgb(241, 241, 241);
                noMatchLbl.Width = matchesFlowLayoutPanel.ClientSize.Width - matchesFlowLayoutPanel.Padding.Horizontal;
                noMatchLbl.Height = 300;
                noMatchLbl.TextAlign = ContentAlignment.MiddleCenter;
                matchesFlowLayoutPanel.Controls.Add(noMatchLbl);
                matchesFlowLayoutPanel.Show();
                return;
            }

            foreach (FootballMatch match in footballMatches)
            {
                // get info to be displayed on the match panel
                Team homeTeam = TeamsDict[match.HomeTeamID];
                Team awayTeam = TeamsDict[match.AwayTeamID];
                string leagueName = Leagues.First(l => l.LeagueId == match.LeagueID).Name;

                MatchDisplayInfo displayInfo = new MatchDisplayInfo(match, homeTeam, awayTeam, leagueName);
                MatchPanel matchPanel = new MatchPanel(displayInfo);

                matchPanel.Margin = new Padding(0, 0, 0, 30);
                matchPanel.SeeBetsClicked += SeeBetsBtnClicked;

                // adding to flow layout panel
                matchesFlowLayoutPanel.Controls.Add(matchPanel);
            }
            updateMatchesPanelWidth(null, null);
            matchesFlowLayoutPanel.Show();
        }

        //display matches filtered by leagues
        private void FilterByLeagues(int leagueId)
        {
            MyList<FootballMatch> matchLeagueFiltered = MatchFilter.FilterMatchByLeague(leagueId);
            LoadMatches(matchLeagueFiltered);
        }

        //display matches filtered by teams 
        private void FilterByTeams(string searchedTeam)
        {
            MyList<FootballMatch> matchTeamFiltered = MatchFilter.FilterMatchByTeams(searchedTeam);
            bannerPanel.Hide();
            CurrentLeague = -1;
            LoadMatches(matchTeamFiltered);
        }

        //display all upcoming matches
        private void AllMatchesClicked(object sender, EventArgs e)
        {
            //avoid reloading if user is already viewing all matches
            if (CurrentLeague == 0)
                return;

            CurrentLeague = 0;
            leagueLbl.Text = "All Matches";
            bannerImg.Image = Image.FromFile(@"..\..\..\..\Assets\allMatchBaner.jpg");
            LoadMatches(MatchesCollection.AllMatches);
        }

        //display matches of league selected
        private void LeagueButtonClicked(object sender, EventArgs e)
        {
            Control clickedControl = (Control)sender;
            League leagueSelected = (League)(clickedControl).Tag!;
            int leagueId = leagueSelected.LeagueId;

            if (CurrentLeague == leagueId)
                return;

            CurrentLeague = leagueId;
            string leagueName = leagueSelected.Name;
            leagueLbl.Text = "";
            bannerImg.Image = Image.FromFile(Path.Combine("..", "..", "..", "..", "Assets", leagueSelected.BannerPath));
            FilterByLeagues(leagueId);
        }

        // when user makes a search
        private void Searchbar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string searchedTerm = searchbarTextBox.Text.Trim();
                if (!String.IsNullOrEmpty(searchedTerm))
                {
                    //avoid reloading if user is already viewing matches of the team searched
                    if (string.Equals(searchedTerm, CurrentSearchTerm, StringComparison.OrdinalIgnoreCase))
                        return;
                    
                    CurrentSearchTerm = searchedTerm;
                    FilterByTeams(searchbarTextBox.Text.Trim());
                }
            }
        }

        //clear search and show all matches
        private void clearSearchIcon_Click(object sender, EventArgs e)
        {
            searchbarTextBox.Clear();
            CurrentSearchTerm = "";
            matchesFlowLayoutPanel.Hide();
            bannerPanel.Show();
            AllMatchesClicked(sender, e);
        }
        
        //show bets for match selected
        private async void SeeBetsBtnClicked(MatchDisplayInfo MatchDetails)
        {
            //avoid reloading if user is already viewing bets of the match selected
            if (CurrentMatchId == MatchDetails.CurrentMatch.GameID)
                return;

            CurrentMatchId = MatchDetails.CurrentMatch.GameID;
            noMatchSelectedPanel.Hide();
            await DisplayBetSelections(MatchDetails);
        }

        //display panel with the bets that can be placed
        private async Task DisplayBetSelections(MatchDisplayInfo MatchDetails)
        {
            if (!await EnsureOddsLoadedForMatch(CurrentMatchId))
            {
                new Notification("Odds are not available for this match yet. Please refresh shortly.", NotificationType.Warning, this);
                MatchSelectedBetsPanel.Visible = false;
                noMatchSelectedPanel.Show();
                return;
            }

            scoreOddLbl.Visible = false;
            DisplayButtonText();
            DisplayPlayersName(MatchDetails.HomeTeam.TeamId, MatchDetails.AwayTeam.TeamId);
            await DisplayMatchBetDetails(MatchDetails);
            MatchSelectedBetsPanel.Visible = true;
        }

        private async Task DisplayMatchBetDetails(MatchDisplayInfo MatchDetails)
        {
            betHomeTeamLbl.Text = MatchDetails.HomeTeam.TeamName;
            betAwayTeamLbl.Text = MatchDetails.AwayTeam.TeamName;
            betHomeTeamImg.Image = await ImgLoader.GetImageAsync(MatchDetails.HomeTeam.LogoPath);
            betAwayTeamImg.Image = await ImgLoader.GetImageAsync(MatchDetails.AwayTeam.LogoPath);

            betLeagueLbl.Text = MatchDetails.LeagueName;
            betMatchDateLbl.Text = MatchDetails.CurrentMatch.GameDate.ToString("dd/MM/yyyy");
            betMatchTimeLbl.Text = MatchDetails.CurrentMatch.GameDate.ToString("HH:mm");
        }

        //expand and collapse sections in bet panel
        public void ToggleBetSection(int collapseHeight, int expandHeight, Panel mainPanel, Panel contentPanel)
        {
            if (contentPanel.Visible)
            {
                contentPanel.Visible = false;
                mainPanel.Height = collapseHeight;
                return;
            }
            contentPanel.Visible = true;
            mainPanel.Height = expandHeight;
        }
        public void MatchResultDropdown_Click(object sender, EventArgs e)
        {
            ToggleBetSection(matchResultTopPanel.Height, 359, MatchResultPanel, MatchResultContent);
        }

        public void GoalScorersDropdown_Click(object sender, EventArgs e)
        {
            ToggleBetSection(goalScorerTopPanel.Height, 313, goalScorerPanel, goalScorerContent);
        }

        public void StatsDropdown_Click(object sender, EventArgs e)
        {
            ToggleBetSection(matchResultTopPanel.Height, 546, statsPanel, statsContent);
        }
        
        //set tag of buttons with betTypeId and Selection
        private void SetButtonTags()
        {
            homeWinBtn.Tag = new BetButtonTag(1, "Home Win");
            drawBtn.Tag = new BetButtonTag(1, "Draw");
            awayWinBtn.Tag = new BetButtonTag(1, "Away Win");

            chance1Btn.Tag = new BetButtonTag(2, "1X");
            chance2Btn.Tag = new BetButtonTag(2, "12");
            chance3Btn.Tag = new BetButtonTag(2, "X2");

            overBtn.Tag = new BetButtonTag(4, "Over 2.5");
            underBtn.Tag = new BetButtonTag(4, "Under 2.5");

            bttsYesBtn.Tag = new BetButtonTag(5, "Yes");
            bttsNoBtn.Tag = new BetButtonTag(5, "No");

            corner1Btn.Tag = new BetButtonTag(7, "Over 8.5");
            corner2Btn.Tag = new BetButtonTag(7, "Under 8.5");
            corner3Btn.Tag = new BetButtonTag(7, "Over 9.5");
            corner4Btn.Tag = new BetButtonTag(7, "Under 9.5");
            corner5Btn.Tag = new BetButtonTag(7, "Over 10.5");
            corner6Btn.Tag = new BetButtonTag(7, "Under 10.5");

            yellowBtn1.Tag = new BetButtonTag(8, "Over 3.5");
            yellowBtn2.Tag = new BetButtonTag(8, "Under 3.5");
            yellowBtn3.Tag = new BetButtonTag(8, "Over 4.5");
            yellowBtn4.Tag = new BetButtonTag(8, "Under 4.5");

            redBtn1.Tag = new BetButtonTag(9, "Over 0.5");
            redBtn2.Tag = new BetButtonTag(9, "Under 0.5");
            redBtn3.Tag = new BetButtonTag(9, "Over 1.5");
            redBtn4.Tag = new BetButtonTag(9, "Under 1.5");

            foreach (var panel in BtnParentPanel)
            {
                foreach (var button in panel.Controls.OfType<RoundedButton>())
                {
                    if (button.Tag is BetButtonTag)
                    {
                        BetButtons.Add(button);
                        button.Click += BetBtnClicked;

                    }
                }
            }
        }

        //display odds
        private void DisplayButtonText()
        {
            foreach (RoundedButton btn in BetButtons)
            {
                BetButtonTag btnTagInfo = (BetButtonTag)(btn).Tag!;
                int betTypeId = btnTagInfo.BetTypeId;
                string selection = btnTagInfo.Selection;

                Odd? btnOdd = FindOddInstanceOrNull(betTypeId, selection);

                if ( btnOdd is null)
                {
                    btn.Text = $"{selection} (N/A)";
                    btn.Enabled = false;
                }
                else
                {
                    btn.Text = $"{selection} ({Math.Round(btnOdd.OddValue, 2)})";
                    btn.Enabled = true;
                }
            }
        }

        //add name of players to combobox
        private void DisplayPlayersName(int homeTeamID, int awayTeamID)
        {
            playersComboBox.Items.Clear();

            MyList<Player> currentPlayers = new MyList<Player>();

            if (Players.TryGetValue(homeTeamID, out var homePlayers))
            {
                currentPlayers.AddRange(homePlayers);
            }

            if (Players.TryGetValue(awayTeamID, out var awayPlayers))
            {
                currentPlayers.AddRange(awayPlayers);
            }

            foreach (Player player in currentPlayers)
            {
                var playerOdd = FindOddInstanceOrNull(6, player.Name);
                if (playerOdd is null)
                {
                    continue;
                }

                PlayerComboItem playerComboItem = new PlayerComboItem(player.PlayerId, player.Name, player.Position, playerOdd);
                playersComboBox.Items.Add(playerComboItem); 
            }

            playersComboBox.SelectedIndex = -1;
        }

        private void PlayersComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (playersComboBox.SelectedIndex == -1)
               return;

            PlayerComboItem selectedPlayer = (PlayerComboItem)playersComboBox.SelectedItem!;
            AddToBetSlip(selectedPlayer.PlayerOdd);
        }

        //when user clicks on a bet button
        private void BetBtnClicked(object sender, EventArgs e)
        {
            RoundedButton btn = sender as RoundedButton;

            BetButtonTag btnTagInfo = (BetButtonTag)(btn).Tag!;

            int betTypeId = btnTagInfo.BetTypeId;
            string selection = btnTagInfo.Selection;

            Odd btnOdd = FindOddInstance(betTypeId, selection);
            AddToBetSlip(btnOdd);
        }

        private void AddToBetSlip(Odd oddObj)
        {
            //create bet instance
            Bet newBet = new Bet(
                oddObj.OddID,
                oddObj.Selection,
                oddObj.OddValue,
                oddObj.BetTypeID,
                CurrentMatchId
            );

            //add to bet slip
            string message = UserSlip.AddBet(newBet);
            new Notification(message, NotificationType.Success, this);
        }

        //find odd
        private Odd FindOddInstance(int betTypeId, string selection)
        {
            return FindOddInstanceOrNull(betTypeId, selection)
                   ?? throw new InvalidOperationException($"No odd found for match {CurrentMatchId}, bet type {betTypeId}, selection '{selection}'.");
        }

        private Odd? FindOddInstanceOrNull(int betTypeId, string selection)
        {
            if (!Odds.TryGetValue(CurrentMatchId, out var matchOdds))
            {
                return null;
            }

            return matchOdds.FirstOrDefault(o => o.BetTypeID == betTypeId && o.Selection == selection);
        }

        private async Task<bool> EnsureOddsLoadedForMatch(int gameId)
        {
            if (Odds.ContainsKey(gameId))
            {
                return true;
            }

            Odds = await DBManager.FetchOddsAsync();
            return Odds.ContainsKey(gameId);
        }

        //open profile page
        private void NavBar1_AccountClicked(object? sender, EventArgs e)
        {
            CurrentSession.OpenProfilePage(this);
        }

        //open bet slip page
        private void NavBar1_BetSlipClicked(object? sender, EventArgs e)
        {
            CurrentSession.OpenBetSlipPage(this);
        }

        //update width of matchesPanel dynamically
        private void updateMatchesPanelWidth(object sender, EventArgs e)
        {
            foreach (Control matchPanel in matchesFlowLayoutPanel.Controls)
            {
                matchPanel.Width = matchesFlowLayoutPanel.ClientSize.Width - matchesFlowLayoutPanel.Padding.Horizontal;
            }
        }

        // clear flow layout panel before loading matches
        private void ClearMatches()
        {
            matchesFlowLayoutPanel.Hide();
            matchesFlowLayoutPanel.Controls.Clear();
            MatchSelectedBetsPanel.Hide();
            noMatchSelectedPanel.Show();
            CurrentMatchId = -1;
        }

        //fetch from database to refresh matches info
        private async void refreshIcon_Click(object sender, EventArgs e)
        {
            await FetchData();
            Odds = await DBManager.FetchOddsAsync();
            ReInitialise();
        }

        //reinitialse page
        public void ReInitialise()
        {
            searchbarTextBox.Text = "";
            CurrentSearchTerm = "";
            bannerPanel.Show();
            AllMatchesClicked(null, null);
            CurrentLeague = 0;
        }

        private async void confirmScoreBet_Click(object sender, EventArgs e)
        {
            string homeScore = homeScoreTxt.Text;
            string awayScore = awayScoreTxt.Text;

            scoreOddLbl.Visible = false;

            if (String.IsNullOrWhiteSpace(homeScore) || String.IsNullOrWhiteSpace(awayScore))
            {
                scoreOddLbl.Text = "Please enter both home and away scores";
                scoreOddLbl.ForeColor = Color.Firebrick;
                scoreOddLbl.Visible = true;
                return;
            }

            (bool valid, string? message) = validator.CheckScores(homeScore, awayScore);
            if (valid) 
            {
                if (CurrentMatchId <= 0)
                {
                    scoreOddLbl.Text = "Please select a match before adding a score bet";
                    scoreOddLbl.ForeColor = Color.Firebrick;
                    scoreOddLbl.Visible = true;
                    return;
                }

                FootballMatch? selectedMatch = MatchesCollection.AllMatches
                    .FirstOrDefault(match => match.GameID == CurrentMatchId);

                if (selectedMatch is null)
                {
                    scoreOddLbl.Text = "Selected match details could not be found";
                    scoreOddLbl.ForeColor = Color.Firebrick;
                    scoreOddLbl.Visible = true;
                    return;
                }

                int homeGoals = int.Parse(homeScore);
                int awayGoals = int.Parse(awayScore);

                Odd? scoreOdd = await DBManager.GetOrCreateCorrectScoreOddAsync(
                    CurrentMatchId,
                    homeGoals,
                    awayGoals,
                    selectedMatch.HomeTeamID,
                    selectedMatch.AwayTeamID,
                    selectedMatch.LeagueID);

                if (scoreOdd is null)
                {
                    scoreOddLbl.Text = "Could not load odds for this score. Please try again.";
                    scoreOddLbl.ForeColor = Color.Firebrick;
                    scoreOddLbl.Visible = true;
                    return;
                }

                if (!Odds.TryGetValue(CurrentMatchId, out var matchOdds))
                {
                    matchOdds = new MyList<Odd>();
                    Odds[CurrentMatchId] = matchOdds;
                }

                matchOdds.RemoveAll(odd => odd.BetTypeID == scoreOdd.BetTypeID && odd.Selection == scoreOdd.Selection);
                matchOdds.Add(scoreOdd);

                AddToBetSlip(scoreOdd);
            }
            else
            {
                scoreOddLbl.Text = message;
                scoreOddLbl.ForeColor = Color.Firebrick;
                scoreOddLbl.Visible = true;
            }
        }

        //round corners of banner picture box
        private void RoundBannerPictureBox(object sender, EventArgs e)
        {
            var path = new GraphicsPath();
            int d = 10 * 2;

            Rectangle rect = bannerImg.ClientRectangle;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            bannerImg.Region = new Region(path);
        }
    }
}
