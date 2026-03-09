using BettingSystem.Models;

namespace BettingSystem.Forms
{
    public partial class AccountPage : Form
    {
        private readonly AppUser CurrentUser;
        public AccountPage(AppUser loggedInUser)
        {
            CurrentUser = loggedInUser;
            InitializeComponent();
            navBar1.SetCurrentUser(CurrentUser);

            //event from navbar
            navBar1.MatchesClicked += NavBar1_MatchesClicked;
            navBar1.BetSlipClicked += NavBar1_BetSlipClicked;
            LoadAccountPage();
        }

        // to open bet slip page
        private void NavBar1_BetSlipClicked(object? sender, EventArgs e)
        {

        }

        private void NavBar1_MatchesClicked(object? sender, EventArgs e)
        {
            MainPage matchPage = new MainPage(CurrentUser);
            matchPage.Size = this.Size;
            matchPage.Location = this.Location;
            matchPage.WindowState = this.WindowState;
            this.Hide();
            matchPage.Show();
        }

        private void LoadAccountPage()
        {
            //display user details
            DisplayDetails();

            //display user's wallet balance
            DisplayBalance();
        }

        private void DisplayDetails()
        {
            FNameLbl.Text = $"First Name: {CurrentUser.FirstName}";
            LNameLbl.Text = $"Last Name: {CurrentUser.LastName}";
            EmailLbl.Text = $"Email: {CurrentUser.Email}";
            dobLbl.Text = $"Date of Birth: {CurrentUser.Dob.ToString("dd/MM/yyyy")}";
        }

        public void DisplayBalance()
        {
            amountLbl.Text = $"$ {CurrentUser.WalletBalance}";
        }

        //open popup to edit details
        private void editBtn_Click(object sender, EventArgs e)
        {
            EditFormPopup editPopup = new EditFormPopup(CurrentUser);

            //update details displayed when user makes changes
            if (editPopup.ShowDialog() == DialogResult.OK)
            {
                DisplayDetails();
            }
        }

        //open popup to change password
        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            ChangePasswordPopup changePasswordPopup = new ChangePasswordPopup(CurrentUser);
            changePasswordPopup.ShowDialog();
        }

        //open popup to make a deposit
        private void depositBtn_Click(object sender, EventArgs e)
        {
            WalletPopup walletTransactionPopup = new WalletPopup("Deposit", CurrentUser);
            if (walletTransactionPopup.ShowDialog() == DialogResult.OK)
            {
                navBar1.DisplayInfo(); //open label in navbar to update balance displayed
            }
        }

        //open popup to withdraw money
        private void withdrawBtn_Click(object sender, EventArgs e)
        {
            WalletPopup walletTransactionPopup = new WalletPopup("Withdraw", CurrentUser);
            if (walletTransactionPopup.ShowDialog() == DialogResult.OK)
            {
                navBar1.DisplayInfo();
            }
        }
    }
}
