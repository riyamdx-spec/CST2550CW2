using BettingSystem.Models;

namespace BettingSystem.Forms.CustomControls
{
    public partial class AdminNavBar : UserControl
    {
        private AppUser _connectedAdmin;

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
            _connectedAdmin = loggedInUser;
            DisplayInfo();
        }

        public void DisplayInfo()
        {
            navDropdownBtn.Text = $"{_connectedAdmin.FirstName} {_connectedAdmin.LastName}";
        }

        private void ChangedPassword_Click(object sender, EventArgs e)
        {
            ChangePasswordPopup passwordPopup = new ChangePasswordPopup(_connectedAdmin);
            passwordPopup.ShowDialog();
        }

        private void EditProfile_Click(object sender, EventArgs e)
        {
            EditFormPopup editFormPopup = new EditFormPopup(_connectedAdmin);

            //update details displayed when admin edit details
            if (editFormPopup.ShowDialog() == DialogResult.OK)
            {
                DisplayInfo();
            }
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

        // to open dropwdown menu
        private void navDropdownBtn_Click_1(object sender, EventArgs e)
        {
            dropdownList.Show(navDropdownBtn, 0, navDropdownBtn.Height + 10);
            dropdownList.Width = navDropdownBtn.Width;
            changePasswordToolStripMenuItem.Width = navDropdownBtn.Width;
            editProfileToolStripMenuItem.Width = navDropdownBtn.Width;
            logOutToolStripMenuItem.Width = navDropdownBtn.Width;
        }
    }
}
