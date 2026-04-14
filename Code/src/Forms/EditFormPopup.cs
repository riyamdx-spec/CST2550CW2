using BettingSystem.Data;
using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class EditFormPopup : Form
    {
        private AppUser _currentUser;
        private readonly DatabaseManager _dbManager;
        private readonly Validation _validator;
        public EditFormPopup(AppUser loggedInUser)
        {
            _dbManager = new DatabaseManager();
            _validator = new Validation();
            _currentUser = loggedInUser;

            InitializeComponent();
            ClearForm();
            displayInitialDetails();
        }

        //remove error messages
        private void ClearForm()
        {
            emailErrorMsg.Text = "";
            fNameErrorMsg.Text = "";
            lNameErrorMsg.Text = "";
        }
        private void displayInitialDetails()
        {
            fNameTextbox.Text = _currentUser.FirstName;
            lNameTextbox.Text = _currentUser.LastName;
            emailTextbox.Text = _currentUser.Email;
        }

        private bool ValidateEntries(string firstName, string lastName, string email)
        {
            //check for empty fields
            if (string.IsNullOrEmpty(firstName.Trim()) || string.IsNullOrEmpty(lastName.Trim()) || string.IsNullOrEmpty(email.Trim()))
            {
                DisplayErrorMessage(emailErrorMsg, "Please fill all fields");
                return false;
            }

            // validate names
            bool valid = true;
            valid = ValidateName(firstName, fNameErrorMsg, "First Name");
            valid = ValidateName(lastName, lNameErrorMsg, "Last Name") && valid;

            //validate email
            (bool emailValid, string message) = _validator.CheckEmail(email);
            if (!emailValid)
            {
                valid = false;
                DisplayErrorMessage(emailErrorMsg, message);
            }

            return valid;
        }

        private bool ValidateName(string name, Label errorLbl, string fieldName)
        {
            //check number of characters
            if (!_validator.CheckNameLength(name))
            {
                DisplayErrorMessage(errorLbl, $"{fieldName} must be between 3 and 50 characters");
                return false;
            }

            //check if name contains numbers
            if (_validator.CheckNumber(name))
            {
                DisplayErrorMessage(errorLbl, $"{fieldName} cannot contain numbers");
                return false;
            }
            
            return true;
        }

        private void DisplayErrorMessage(Label errorLbl, string message)
        {
            errorLbl.Text = message;
        }

        //confirm changes and update database
        private async void confirmEditBtn_Click(object sender, EventArgs e)
        {
            ClearForm();

            string firstName = fNameTextbox.Text.Trim();
            string lastName = lNameTextbox.Text.Trim();
            string email = emailTextbox.Text.Trim();

            //validate fields
            if (!ValidateEntries(firstName, lastName, email))
                return;
            
            (bool valid, string message) = await _dbManager.UpdateUserDetailsAsync(_currentUser.UserID, firstName, lastName, email);
            if (valid)
            {
                //update user object
                _currentUser.FirstName = firstName;
                _currentUser.LastName = lastName;
                _currentUser.Email = email;

                new Notification(message, NotificationType.Success, this);
                await Task.Delay(1500); 
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DisplayErrorMessage(emailErrorMsg, message);
            }
        }

        //refresh fields
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            ClearForm();
            displayInitialDetails();
        }

        //cancel edit
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
