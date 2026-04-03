using BettingSystem.Data;
using BettingSystem.Data_Structures;
using BettingSystem.Forms;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class SessionManager
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();

        public FootballMatchCollection MatchesCollection { set; get; }

        public MyDictionary<int, GameResult> GameResults { set; get; }
        
        public MyList<BetHistorySlip> HistoryBetSlips { set; get; }
        public BetSlip UserSlip { set; get;}

        private AppUser _currentUser { set; get; }

        public League[] Leagues { set; get; }
        public MyDictionary<int, Team> TeamsDict { set; get; }
        public MyDictionary<int, MyList<Player>> Players { set; get; }
        public bool IsLoggingOut { get; private set; }
        public bool IsExiting { get; set; }
        public bool IsAdmin { get; set; }

        public Simulator AppSimulator;

        public SessionManager(AppUser currentUser, Simulator appSimulator)
        {
            _currentUser = currentUser;
            IsLoggingOut = false;
            IsExiting = false;
            AppSimulator = appSimulator;
            if (_currentUser.Role == "user")
            {
                UserSlip = new BetSlip(currentUser.UserID);
                GameResults = new MyDictionary<int, GameResult>();
                HistoryBetSlips = new MyList<BetHistorySlip>();
                IsAdmin = false;
                return;
            }
            IsAdmin = true;
        }
        
        //load data for uer's side
        public async Task FetchUserData()
        {
            Leagues = await _dbManager.FetchLeaguesAsync();
            MatchesCollection = await _dbManager.FetchMatchesAsync();
            HistoryBetSlips = await _dbManager.FetchBetHistoryAsync(_currentUser.UserID);
            Players = await _dbManager.FetchPlayersAsync();
            TeamsDict = await _dbManager.FetchTeamsAsync();
        }

        //load data for admin panel
        public async Task FetchAdminData()
        {
            MatchesCollection = await _dbManager.FetchMatchesAsync(true);
            GameResults = await _dbManager.FetchGameResultsAsync(null, true);
            Leagues = await _dbManager.FetchLeaguesAsync();
            TeamsDict = await _dbManager.FetchTeamsAsync(true);
            Players = await _dbManager.FetchPlayersAsync();
        }

        public void OpenProfilePage(Form currentForm)
        {
            AccountPage? profilePage = Application.OpenForms.OfType<AccountPage>().FirstOrDefault();
            //check if profile page is already opened
            if (profilePage is null)
            {
                profilePage = new AccountPage(_currentUser, this);
            }
            else
            {
                // reinitialise content on profile page
                profilePage.LoadAccountPage();
            }

            profilePage.Size = currentForm.Size;
            profilePage.Location = currentForm.Location;
            profilePage.WindowState = currentForm.WindowState;
            currentForm.Hide();
            profilePage.Show();
        }

        public void OpenMainPage(Form currentForm)
        {
            MainPage? mainPage = Application.OpenForms.OfType<MainPage>().FirstOrDefault();
            //check if main page is already opened
            if (mainPage is null)
            {
                mainPage = new MainPage(_currentUser, this);
            }
            else
            {
                // reinitialise content on main page
                mainPage.ReInitialise();
            }

            mainPage.Size = currentForm.Size;
            mainPage.Location = currentForm.Location;
            mainPage.WindowState = currentForm.WindowState;
            mainPage.Show();
            currentForm.Hide();
        }

        public async Task OpenHistoryPage(Form currentForm) 
        {
            HistoryPage? betHistoryPage = Application.OpenForms.OfType<HistoryPage>().FirstOrDefault();
            //check if histoty page is already opened
            if (betHistoryPage is null)
            {
                betHistoryPage = new HistoryPage(_currentUser, this);
            }
            else
            {
                // reinitialise content on page
                await betHistoryPage.ReInitialisePage();
            }

            betHistoryPage.Size = currentForm.Size;
            betHistoryPage.Location = currentForm.Location;
            betHistoryPage.WindowState = currentForm.WindowState;
            currentForm.Hide();
            betHistoryPage.Show();
        }

        public void OpenBetSlipPage(Form currentForm)
        {
            BetSlipPage? betSlipPage = Application.OpenForms.OfType<BetSlipPage>().FirstOrDefault();
            if (betSlipPage is null)
            {
                betSlipPage = new BetSlipPage(_currentUser, this);
            }
            else
            {
                // reinitialise content on page
                betSlipPage.ReloadSlip();
            }

            betSlipPage.Size = currentForm.Size;
            betSlipPage.Location = currentForm.Location;
            betSlipPage.WindowState = currentForm.WindowState;
            currentForm.Hide();
            betSlipPage.Show();
        }

        // forms on admin side
        public async Task OpenAdminViewUsersPage(Form currentForm)
        {
            AdminUsersPage? usersPage = Application.OpenForms.OfType<AdminUsersPage>().FirstOrDefault();
            if (usersPage is null)
            {
                usersPage = new AdminUsersPage(_currentUser, this);
            }
            else
            {
                // reinitialise content on page
                await usersPage.ReloadPage();
            }

            usersPage.Size = currentForm.Size;
            usersPage.Location = currentForm.Location;
            usersPage.WindowState = currentForm.WindowState;
            currentForm.Hide();
            usersPage.Show();
        }
        public async Task OpenAdminMatchPage(Form currentForm)
        {
            AdminMatchPage? matchPage = Application.OpenForms.OfType<AdminMatchPage>().FirstOrDefault();

            if (matchPage is null)
            {
                matchPage = new AdminMatchPage(_currentUser, this);
            }
            else
            {
                // reinitialise content on page
                await matchPage.Reset();
            }

            matchPage.Size = currentForm.Size;
            matchPage.Location = currentForm.Location;
            matchPage.WindowState = currentForm.WindowState;
            currentForm.Hide();
            matchPage.Show();
        }
        public void OpenAdminAddMatchPage(Form currentForm)
        {
            AdminAddMatchPage? addMatchPage = Application.OpenForms.OfType<AdminAddMatchPage>().FirstOrDefault();

            if (addMatchPage is null)
            {
                addMatchPage = new AdminAddMatchPage(_currentUser, this);
            }
            else
            {
                // reinitialise content on page
                addMatchPage.Reset();
            }

            addMatchPage.Size = currentForm.Size;
            addMatchPage.Location = currentForm.Location;
            addMatchPage.WindowState = currentForm.WindowState;
            currentForm.Hide();
            addMatchPage.Show();
        }

        public async Task OpenAdminFinancialPage(Form currentForm)
        {
            AdminFinancialPage? financialPage = Application.OpenForms.OfType<AdminFinancialPage>().FirstOrDefault();
            if (financialPage is null)
            {
                financialPage = new AdminFinancialPage(_currentUser, this);
            }
            else
            {
                // reinitialise content on page
                await financialPage.ReloadPage();
            }

            financialPage.Size = currentForm.Size;
            financialPage.Location = currentForm.Location;
            financialPage.WindowState = currentForm.WindowState;
            currentForm.Hide();
            financialPage.Show();
        }
        public void LogOut(Form currentForm)
        {
            IsLoggingOut = true;
            var openForms = Application.OpenForms.Cast<Form>().ToList();
            foreach (Form activeForm in openForms)
            {
                if (!(activeForm is landingPage))
                    activeForm.Close();
            }

            //clear session in simulator
            AppSimulator.SetSession(null);

            IsLoggingOut = false;
            landingPage? appLandingPage = Application.OpenForms.OfType<landingPage>().FirstOrDefault();
            if (appLandingPage is null)
            {
                appLandingPage = new landingPage(AppSimulator);
            }
            appLandingPage.Size = currentForm.Size;
            appLandingPage.Location = currentForm.Location;
            appLandingPage.WindowState = currentForm.WindowState;
            appLandingPage.Show();
        }
    }
}