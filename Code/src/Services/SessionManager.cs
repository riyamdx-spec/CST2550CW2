using BettingSystem.Data;
using BettingSystem.Data_Structures;
using BettingSystem.Forms;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    public class SessionManager
    {
        private readonly DatabaseManager DbManager = new DatabaseManager();

        public FootballMatchCollection MatchesCollection { set; get; }

        public MyDictionary<int, GameResult> GameResults { set; get; }
        
        public MyList<BetHistorySlip> HistoryBetSlips { set; get; }
        public BetSlip UserSlip { set; get;}

        private AppUser CurrentUser { set; get; }

        public League[] Leagues { set; get; }
        public MyDictionary<int, Team> TeamsDict { set; get; }
        public MyDictionary<int, MyList<Player>> Players { set; get; }
        public bool IsLoggingOut { get; private set; }
        public bool IsExiting { get; set; }

        public Simulator AppSimulator;

        public SessionManager(AppUser currentUser)
        {
            CurrentUser = currentUser;
            IsLoggingOut = false;
            IsExiting = false;

            if (CurrentUser.Role == "user")
            {
                UserSlip = new BetSlip(currentUser.UserID);
                GameResults = new MyDictionary<int, GameResult>();
            }
            //start timer for simulator
            AppSimulator = new Simulator(CurrentUser, this);
        }
        
        public async Task FetchUserData()
        {
            MatchesCollection = await DbManager.FetchMatchesAsync();
            HistoryBetSlips = await DbManager.FetchBetHistoryAsync(CurrentUser.UserID);
            Players = await DbManager.FetchPlayersAsync();
        }

        public async Task FetchAdminData()
        {
            MatchesCollection = await DbManager.FetchMatchesAsync(true);
            GameResults = await DbManager.FetchGameResultsAsync(null, true);
            Leagues = await DbManager.FetchLeaguesAsync();
            TeamsDict = await DbManager.FetchTeamsAsync(true);
            Players = await DbManager.FetchPlayersAsync();
        }

        public void OpenProfilePage(Form currentForm)
        {
            AccountPage? profilePage = Application.OpenForms.OfType<AccountPage>().FirstOrDefault();
            //check if profile page is already opened
            if (profilePage is null)
            {
                profilePage = new AccountPage(CurrentUser, this);
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
                mainPage = new MainPage(CurrentUser, this);
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
                betHistoryPage = new HistoryPage(CurrentUser, this);
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
                betSlipPage = new BetSlipPage(CurrentUser, this);
            }
            else
            {
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
                usersPage = new AdminUsersPage(CurrentUser, this);
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
                matchPage = new AdminMatchPage(CurrentUser, this);
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
                addMatchPage = new AdminAddMatchPage(CurrentUser, this);
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
                financialPage = new AdminFinancialPage(CurrentUser, this);
            }

            financialPage.Size = currentForm.Size;
            financialPage.Location = currentForm.Location;
            financialPage.WindowState = currentForm.WindowState;
            currentForm.Hide();
            financialPage.Show();
        }
        public async Task LogOut(Form currentForm)
        {
            IsLoggingOut = true;
            var openForms = Application.OpenForms.Cast<Form>().ToList();
            foreach (Form activeForm in openForms)
            {
                if (!(activeForm is landingPage))
                    activeForm.Close();
            }

            //stop timer for simulation
            await AppSimulator.DisposeAsync();

            IsLoggingOut = false;
            landingPage? appLandingPage = Application.OpenForms.OfType<landingPage>().FirstOrDefault();
            if (appLandingPage is null)
            {
                appLandingPage = new landingPage();
            }
            appLandingPage.Size = currentForm.Size;
            appLandingPage.Location = currentForm.Location;
            appLandingPage.WindowState = currentForm.WindowState;
            appLandingPage.Show();
        }
    }
}