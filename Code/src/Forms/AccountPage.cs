using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class AccountPage : Form
    {
        private readonly AppUser _currentUser;
        private SessionManager _currentSession;
        public AccountPage(AppUser loggedInUser, SessionManager sessionManager)
        {
            _currentUser = loggedInUser;
            _currentSession = sessionManager;

            InitializeComponent();

            //event from navbar
            navBar1.MatchesClicked += NavBar1_MatchesClicked;
            navBar1.BetSlipClicked += NavBar1_BetSlipClicked;
            navBar1.LogoutClicked += NavBar1_LogoutClicked;
            LoadAccountPage();

            this.FormClosing += AccountPage_FormClosing;
        }

        private void AccountPage_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_currentSession.IsLoggingOut && !_currentSession.IsExiting)
            {
                logOutPopup closingPopup = new logOutPopup(false);

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

        private void NavBar1_LogoutClicked(object? sender, EventArgs e)
        {
            if (!_currentSession.IsLoggingOut)
            {
                logOutPopup closingPopup = new logOutPopup(true);
                if (closingPopup.ShowDialog() == DialogResult.Yes)
                    _currentSession.LogOut(this);
            }
        }

        // to open bet slip page
        private void NavBar1_BetSlipClicked(object? sender, EventArgs e)
        {
            _currentSession.OpenBetSlipPage(this);
        }

        private void NavBar1_MatchesClicked(object? sender, EventArgs e)
        {
            _currentSession.OpenMainPage(this);
        }

        private async void historyBtn_Click(object sender, EventArgs e)
        {
           await _currentSession.OpenHistoryPage(this);
        }

        public void LoadAccountPage()
        {
            //display user details
            DisplayDetails();

            //display user's wallet balance
            DisplayBalance();
            navBar1.SetCurrentUser(_currentUser);
        }

        private void DisplayDetails()
        {
            FNameLbl.Text = $"First Name: {_currentUser.FirstName}";
            LNameLbl.Text = $"Last Name: {_currentUser.LastName}";
            EmailLbl.Text = $"Email: {_currentUser.Email}";
            dobLbl.Text = $"Date of Birth: {_currentUser.Dob.ToString("dd/MM/yyyy")}";
        }

        public void DisplayBalance()
        {
            amountLbl.Text = $"$ {_currentUser.WalletBalance}";
        }

        //open popup to edit details
        private void editBtn_Click(object sender, EventArgs e)
        {
            EditFormPopup editPopup = new EditFormPopup(_currentUser);

            //update details displayed when user makes changes
            if (editPopup.ShowDialog() == DialogResult.OK)
            {
                DisplayDetails();
            }
        }

        //open popup to change password
        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            ChangePasswordPopup changePasswordPopup = new ChangePasswordPopup(_currentUser);
            changePasswordPopup.ShowDialog();
        }

        //open popup to make a deposit
        private void depositBtn_Click(object sender, EventArgs e)
        {
            WalletPopup walletTransactionPopup = new WalletPopup("Deposit", _currentUser);
            if (walletTransactionPopup.ShowDialog() == DialogResult.OK)
            {
                navBar1.DisplayInfo(); //open label in navbar to update balance displayed
            }
        }

        //open popup to withdraw money
        private void withdrawBtn_Click(object sender, EventArgs e)
        {
            WalletPopup walletTransactionPopup = new WalletPopup("Withdraw", _currentUser);
            if (walletTransactionPopup.ShowDialog() == DialogResult.OK)
            {
                navBar1.DisplayInfo();
            }
        }
    }
}
