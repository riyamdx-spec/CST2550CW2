using BettingSystem.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace BettingSystem.Forms
{
    public partial class MainPage : Form
    {
        private AppUser CurrentUser;
        public MainPage(AppUser loggedInUser)
        {
            CurrentUser = loggedInUser;
            InitializeComponent();
            matchesFlowLayoutPanel.SizeChanged += updateMatchesPanelWidth;
            updateMatchesPanelWidth(null, null);
            navBar1.SetCurrentUser(CurrentUser);
            navBar1.AccountClicked += NavBar1_AccountClicked;
            navBar1.BetSlipClicked += NavBar1_BetSlipClicked;
        }

        //open profile page
        private void NavBar1_AccountClicked(object? sender, EventArgs e)
        {
            AccountPage profilePage = new AccountPage(CurrentUser);
            profilePage.Size = this.Size;
            profilePage.WindowState = this.WindowState;
            profilePage.Location = this.Location;
            this.Hide();
            profilePage.Show();
        }

        //open bet slip page
        private void NavBar1_BetSlipClicked(object? sender, EventArgs e)
        {
           
        }

        private void seeBetBtn_Click(object sender, EventArgs e)
        {
            noMatchSelectedPanel.Hide();
        }

        //update width of matchesPanel dynamically
        private void updateMatchesPanelWidth(object sender, EventArgs e)
        {
            foreach (Control matchPanel in matchesFlowLayoutPanel.Controls)
            {
                matchPanel.Width = matchesFlowLayoutPanel.ClientSize.Width - matchesFlowLayoutPanel.Padding.Horizontal;
            }
        }
    }
}
