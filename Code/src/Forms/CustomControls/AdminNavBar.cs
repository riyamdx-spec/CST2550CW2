using BettingSystem.Models;

namespace BettingSystem.Forms.CustomControls
{
    public partial class AdminNavBar : UserControl
    {
        private AppUser ConnectedAdmin;

        //click events
        public event EventHandler UsersPageClicked;
        public event EventHandler SearchMatchesPageClicked;
        public event EventHandler AddMatchesPageClicked;
        public event EventHandler FinancialPageClicked;
        public event EventHandler LogoutClicked;

        public AdminNavBar()
        {
            InitializeComponent();
        }

        public void SetAdmin(AppUser loggedInUser)
        {
            ConnectedAdmin = loggedInUser;
            DisplayInfo();
        }

        public void DisplayInfo()
        {
            navDropdownBtn.Text = $"{ConnectedAdmin.FirstName} {ConnectedAdmin.LastName}";
        }

        // to open dropwdown menu
        private void navDropdownBtn_Click(object sender, EventArgs e)
        {
            dropdownList.Show(navDropdownBtn, 0, navDropdownBtn.Height + 10);
            dropdownList.Width = navDropdownBtn.Width;
            editProfileToolStripMenuItem.Width = navDropdownBtn.Width;
            changePasswordToolStripMenuItem.Width = navDropdownBtn.Width;
            logOutToolStripMenuItem.Width = navDropdownBtn.Width;
        }

        private void ChangedPassword_Click(object sender, EventArgs e)
        {
            ChangePasswordPopup passwordPopup = new ChangePasswordPopup(ConnectedAdmin);
            passwordPopup.ShowDialog();
        }

        private void EditProfile_Click(object sender, EventArgs e)
        {
            EditFormPopup editFormPopup = new EditFormPopup(ConnectedAdmin);
            editFormPopup.ShowDialog();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            LogoutClicked?.Invoke(this, new EventArgs());
        }

        private void usersPageBtn_Click(object sender, EventArgs e)
        {
            UsersPageClicked?.Invoke(this, new EventArgs());
        }

        private void matchSearchPageBtn_Click(object sender, EventArgs e)
        {
            SearchMatchesPageClicked?.Invoke(this, new EventArgs());
        }

        private void financialPageBtn_Click(object sender, EventArgs e)
        {
            FinancialPageClicked?.Invoke(this, new EventArgs());
        }

        private void addMatchPageBtn_Click(object sender, EventArgs e)
        {
            AddMatchesPageClicked?.Invoke(this, new EventArgs());
        }
    }
}
