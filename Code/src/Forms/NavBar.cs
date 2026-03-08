using BettingSystem.Models;

namespace BettingSystem.Forms
{
    public partial class NavBar : UserControl
    {
        private AppUser CurrentUser;

        //add click events
        public event EventHandler MatchesClicked;
        public event EventHandler BetSlipClicked;
        public event EventHandler AccountClicked;
        public event EventHandler DepositClicked;

        public NavBar()
        {
            InitializeComponent();
        }

        //display user's name and ballance
        public void SetCurrentUser(AppUser loggedInUser)
        {
            CurrentUser = loggedInUser;
            DisplayInfo();
        }

        private void DisplayInfo()
        {
            navDropdownBtn.Text = $"{CurrentUser.FirstName} {CurrentUser.LastName} \n${Math.Round(CurrentUser.WalletBalance, 2)}";
        }

        //open popup for deposit
        private void navDepositBtn_Click(object sender, EventArgs e)
        {
            WalletPopup walletTransactionPopup = new WalletPopup("Deposit", CurrentUser);
            if (walletTransactionPopup.ShowDialog() == DialogResult.OK)
            {
                DisplayInfo();
                DepositClicked?.Invoke(this, new EventArgs());
            }
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            MatchesClicked?.Invoke(this, new EventArgs());
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountClicked?.Invoke(this, new EventArgs());
        }
        private void betSlipsPageBtn_Click(object sender, EventArgs e)
        {

        }

        private void navDropdownBtn_Click(object sender, EventArgs e)
        {
            dropdownList.Show(navDropdownBtn, 0, navDropdownBtn.Height + 10);
            dropdownList.Width = navDropdownBtn.Width;
            viewProfileToolStripMenuItem.Width = navDropdownBtn.Width;
            logOutToolStripMenuItem.Width = navDropdownBtn.Width;
        }
    }
}
