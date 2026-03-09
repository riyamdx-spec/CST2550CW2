using BettingSystem.Models;

namespace BettingSystem.Forms
{
    public partial class NavBar : UserControl
    {
        private AppUser CurrentUser;

        //click events
        public event EventHandler MatchesClicked;
        public event EventHandler BetSlipClicked;
        public event EventHandler AccountClicked;

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

        public void DisplayInfo()
        {
            navDropdownBtn.Text = $"{CurrentUser.FirstName} {CurrentUser.LastName} \n${Math.Round(CurrentUser.WalletBalance, 2)}";
        }

        //open popup for deposit
        private void navDepositBtn_Click(object sender, EventArgs e)
        {
            WalletPopup walletTransactionPopup = new WalletPopup("Deposit", CurrentUser);
            if (walletTransactionPopup.ShowDialog() == DialogResult.OK)
            {
                DisplayInfo(); //update balance displayed in nav bar
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

        // to open dropwdown menu
        private void navDropdownBtn_Click(object sender, EventArgs e)
        {
            dropdownList.Show(navDropdownBtn, 0, navDropdownBtn.Height + 10);
            dropdownList.Width = navDropdownBtn.Width;
            viewProfileToolStripMenuItem.Width = navDropdownBtn.Width;
            logOutToolStripMenuItem.Width = navDropdownBtn.Width;
        }
    }
}
