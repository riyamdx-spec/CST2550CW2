using BettingSystem.Data;
using BettingSystem.Models;
using BettingSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BettingSystem.Forms
{
    public enum ViewPanel { Login, SignUp }
    public partial class RegisterLoginForm : BaseForm
    {
        private Validation validator = new Validation();
        private DatabaseManager db = new DatabaseManager();

        public bool NavigatingBack = false;

        public RegisterLoginForm(ViewPanel view = ViewPanel.SignUp)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetupForm(view);
            CaptureBaseLayout();
        }

        private void SetupForm(ViewPanel view)
        {
            pnlContainer.Location = new Point(
                (ClientSize.Width - pnlContainer.Width) / 2,
                (ClientSize.Height - pnlContainer.Height) / 2);

            if (view == ViewPanel.SignUp)
            {
                pnlLoginLeft.Visible = false;
                pnlLoginRight.Visible = false;
                pnlSignupLeft.Visible = true;
                pnlSignUpRight.Visible = true;
                pnlSignupLeft.BringToFront();
                pnlSignUpRight.BringToFront();
                backButton.BackColor = Color.FromArgb(84, 139, 66);
            }
            else
            {
                pnlSignupLeft.Visible = false;
                pnlSignUpRight.Visible = false;
                pnlLoginLeft.Visible = true;
                pnlLoginRight.Visible = true;
                pnlLoginLeft.BringToFront();
                pnlLoginRight.BringToFront();
                backButton.BackColor = Color.FromArgb(48, 48, 48);
            }

            txtSignUpPassword.TextChanged += txtPassword_TextChanged;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_NOCLOSE;
                return cp;
            }
        }

        protected override void AfterScaling()
        {
            CentreHorizontally(lblSignupJoin);
            CentreHorizontally(lblReady);
            CentreHorizontally(lblCreate);
        }

        private async void lnkGoToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkToLogin.Enabled = false;

            // Fade out signup 
            for (int i = 100; i >= 0; i -= 5)
            {
                pnlSignupLeft.BackColor = Color.FromArgb(
                    48 + (84 - 48) * i / 100,
                    48 + (139 - 48) * i / 100,
                    48 + (66 - 48) * i / 100);
                await Task.Delay(10);
            }

            backButton.BackColor = Color.FromArgb(48, 48, 48);

            pnlContainer.SuspendLayout();
            pnlLoginLeft.Visible = true;
            pnlLoginRight.Visible = true;
            pnlSignUpRight.Visible = false;
            pnlSignupLeft.Visible = false;
            pnlLoginRight.BackColor = Color.FromArgb(48, 48, 48); // start dark

            pnlLoginLeft.BringToFront();
            pnlLoginRight.BringToFront();
            pnlContainer.ResumeLayout();

            // Fade in login 
            for (int i = 0; i <= 100; i += 5)
            {
                pnlLoginRight.BackColor = Color.FromArgb(
                    48 + (84 - 48) * i / 100,
                    48 + (139 - 48) * i / 100,
                    48 + (66 - 48) * i / 100);
                await Task.Delay(10);
            }

            // Restore colours
            pnlLoginLeft.BackColor = Color.FromArgb(48, 48, 48);
            pnlLoginRight.BackColor = Color.FromArgb(84, 139, 66);

            lnkToLogin.Enabled = true;
        }

        private async void lnkGoToSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkToSignUp.Enabled = false;

            // Fade out login
            for (int i = 100; i >= 0; i -= 5)
            {
                pnlLoginRight.BackColor = Color.FromArgb(
                    48 + (84 - 48) * i / 100,
                    48 + (139 - 48) * i / 100,
                    48 + (66 - 48) * i / 100);
                await Task.Delay(10);
            }

            backButton.BackColor = Color.FromArgb(84, 139, 66);

            pnlLoginLeft.BackColor = Color.FromArgb(48, 48, 48); //reset
            pnlContainer.SuspendLayout();
            pnlSignupLeft.Visible = true;
            pnlSignUpRight.Visible = true;
            pnlLoginLeft.Visible = false;
            pnlLoginRight.Visible = false;

            pnlSignupLeft.BackColor = Color.FromArgb(48, 48, 48); // start dark

            pnlSignupLeft.BringToFront();
            pnlSignUpRight.BringToFront();
            pnlContainer.ResumeLayout();

            // Fade in signup
            for (int i = 0; i <= 100; i += 5)
            {
                pnlSignupLeft.BackColor = Color.FromArgb(
                    48 + (84 - 48) * i / 100,
                    48 + (139 - 48) * i / 100,
                    48 + (66 - 48) * i / 100);

                await Task.Delay(10);
            }

            pnlSignupLeft.BackColor = Color.FromArgb(84, 139, 66);
            pnlSignUpRight.BackColor = Color.FromArgb(48, 48, 48);

            lnkToSignUp.Enabled = true;
        }

        // Password validation colour changes
        private void txtPassword_TextChanged(object? sender, EventArgs e)
        {
            string password = txtSignUpPassword.Text;

            lblCritLen.ForeColor = password.Length >= 8 ? Color.LimeGreen : Color.Firebrick;
            lblCritUpper.ForeColor = password.Any(char.IsUpper) ? Color.LimeGreen : Color.Firebrick;
            lblCritNum.ForeColor = password.Any(char.IsDigit) ? Color.LimeGreen : Color.Firebrick;
            lblCritSpec.ForeColor = password.Any(c => !char.IsLetterOrDigit(c)) ? Color.LimeGreen : Color.Firebrick;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            var landing = new landingPage();
            landing.Size = this.Size;
            landing.WindowState = this.WindowState;
            landing.Location = this.Location;
            NavigatingBack = true;
            this.Close();
        }

        // Button login 
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPassword.Text;

            // check empty fields
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                new Notification("Please fill in all fields.", NotificationType.Warning, this);
                return;
            }

            btnLogin.Enabled = false;
            var (user, message) = await db.LoginAsync(email, password);
            btnLogin.Enabled = true;

            if (user == null)
            {
                new Notification(message, NotificationType.Error, this);
                return;
            }

            new Notification(message, NotificationType.Success, this);

            //AppUser user = new AppUser(1, "Megane", "Rayan", DateTime.Now, "test@test.com", 0, "user");

            //Main page
            var mainForm = new MainPage(user);
            mainForm.Size = this.Size;
            mainForm.WindowState = this.WindowState;
            mainForm.Location = this.Location;
            mainForm.Show();
            this.Close();
        }

        // Sign up button
        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtSignUpEmail.Text.Trim();
            string password = txtSignUpPassword.Text;
            DateTime dob = dtpDOB.Value;

            // check empty fields
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                new Notification("Please fill in all fields", NotificationType.Warning, this);
                return;
            }

            // check name length
            if (!validator.CheckNameLength(firstName) || !validator.CheckNameLength(lastName))
            {
                new Notification("Name must be between 3 and 50 characters.", NotificationType.Warning, this);
                return;
            }

            // check name doesn't contain numbers
            if (validator.CheckNumber(firstName) || validator.CheckNumber(lastName))
            {
                new Notification("Name should not contain numbers.", NotificationType.Warning, this);
                return;
            }

            // check password validity
            if (!validator.CheckPasswordValidity(password))
            {
                new Notification("Password is in incorrect format.", NotificationType.Warning, this);
                return;
            }

            // check age
            var (ageValid, ageMsg) = validator.CheckAge(dob);
            if (!ageValid)
            {
                new Notification(ageMsg, NotificationType.Error, this);
                return;
            }

            // check 18 checkbox
            if (!chk18.Checked)
            {
                new Notification("Please confirm that you are 18 years old or older.", NotificationType.Error, this);
                return;
            }

            btnSignUp.Enabled = false;
            var (user, message) = await db.RegisterAsync(firstName, lastName, dob, email, password);
            btnSignUp.Enabled = true;

            if (user == null)
            {
                new Notification(message, NotificationType.Error, this);
                return;
            }

            new Notification(message, NotificationType.Success, this);

            //AppUser user = new AppUser(1, "Melanie", "Riya", DateTime.Now, "test@test.com", 0, "user");

            // main form
            var mainForm = new MainPage(user);
            mainForm.Size = this.Size;
            mainForm.WindowState = this.WindowState;
            mainForm.Location = this.Location;
            mainForm.Show();
            this.Close();
        }
    }
}

