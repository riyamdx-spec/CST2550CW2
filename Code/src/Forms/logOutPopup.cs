using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class logOutPopup : Form
    {
        private bool _loggingOut;
        private bool _forAdmin;

        public logOutPopup(bool loggingOut, bool admin=false)
        {
            InitializeComponent();
            _loggingOut = loggingOut;
            _forAdmin = admin;
            if (_loggingOut)
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
            if (!_forAdmin)
                messageLbl.Text += "\nAll unpaid bets will be lost and cannot be recovered.";
        }

        private void DisplayClosingLabels()
        {
            popupLbl.Text = "Confirm Exit";
            messageLbl.Text = "Are you sure you want to exit the app?";
            if (!_forAdmin)
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