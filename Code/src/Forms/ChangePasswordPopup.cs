using BettingSystem.Data;
using BettingSystem.Models;
using BettingSystem.Services;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BettingSystem.Forms
{
    public partial class ChangePasswordPopup : Form
    {

        private DatabaseManager _dbManager = new DatabaseManager();
        private Validation _validator = new Validation();
        private AppUser _currentUser;

        public ChangePasswordPopup(AppUser currentUser)
        {
            InitializeComponent();
            confirmChangeBtn.Click += confirmChangeBtn_Click;
            cancelBtn.Click += (s, e) => this.Close();
            _currentUser = currentUser;

            currentPasswordTextbox.TextChanged += (s, e) => HideError();
            newPasswordTextbox.TextChanged += (s, e) => HideError();
        }
        private void txtPassword_TextChanged(object? sender, EventArgs e)
        {
            string password = newPasswordTextbox.Text;

            characterNumLbl.ForeColor = password.Length >= 8 ? Color.LimeGreen : Color.Firebrick;
            upperCaseLbl.ForeColor = password.Any(char.IsUpper) ? Color.LimeGreen : Color.Firebrick;
            numberLbl.ForeColor = password.Any(char.IsDigit) ? Color.LimeGreen : Color.Firebrick;
            specialCharLbl.ForeColor = password.Any(c => !char.IsLetterOrDigit(c)) ? Color.LimeGreen : Color.Firebrick;
        }

        private void ShowMessage(string message, Control targetControl)
        {
            errorLbl.Text = message;
            errorLbl.Location = new Point(targetControl.Left, targetControl.Bottom + 5);
            errorLbl.Visible = true;
        }

        private void HideError()
        {
            errorLbl.Visible = false;
        }

        private async void confirmChangeBtn_Click(object? sender, EventArgs e)
        {
            string currentPassword = currentPasswordTextbox.Text;
            string newPassword = newPasswordTextbox.Text;

            // check empty fields
            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                ShowMessage("Please fill in all fields.", newPasswordTextbox);
                return;
            }

            // check new password validity
            if (!_validator.CheckPasswordValidity(newPassword))
            {
                ShowMessage("New password is in incorrect format.", newPasswordTextbox);
                return;
            }

            confirmChangeBtn.Enabled = false;

            var (success, message) = await _dbManager.ChangePasswordAsync(currentPassword, newPassword, _currentUser.UserID);
            confirmChangeBtn.Enabled = true;

            if (success)
            {
                ShowMessage(message, newPasswordTextbox); 
                errorLbl.ForeColor = Color.LimeGreen;
                await Task.Delay(1500);
                this.Close();
            }
            else
            {
                ShowMessage(message, currentPasswordTextbox);
            }
        }
    }
}