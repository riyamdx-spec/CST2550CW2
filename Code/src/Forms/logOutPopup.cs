using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class logOutPopup : Form
    {
        private bool LoggingOut;
        private bool ForAdmin;

        public logOutPopup(bool loggingOut, bool admin=false)
        {
            InitializeComponent();
            LoggingOut = loggingOut;
            ForAdmin = admin;
            if (LoggingOut)
            {
                DisplayLogOutLabels();
            }
            else
            {
                DisplayClosingLabels();
            }
        }

        private void DisplayLogOutLabels()
        {
            popupLbl.Text = "Confirm Logout";
            messageLbl.Text = $"Are you sure you want to log out?";
            if (!ForAdmin)
                messageLbl.Text += "\nAll unpaid bets will be lost and cannot be recovered.";
        }

        private void DisplayClosingLabels()
        {
            popupLbl.Text = "Confirm Exit";
            messageLbl.Text = "Are you sure you want to exit the app?";
            if (!ForAdmin)
                messageLbl.Text += "\nAll unpaid bets will be lost and cannot be recovered.";
        }

        private void leaveBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}