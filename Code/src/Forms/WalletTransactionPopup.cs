using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class WalletPopup : Form
    {
        private AppUser _currentUser;
        private string _walletAction;
        private readonly Validation _validator;
        private readonly WalletService _walletServices;

        public WalletPopup(string action, AppUser loggedInUser)
        {
            _currentUser = loggedInUser;
            _walletAction = action;
            _validator = new Validation();
            _walletServices = new WalletService();

            InitializeComponent();

            LoadDetails();
        }

        private void LoadDetails()
        {
            lblBalance.Text = $"Current Balance: ${Math.Round(_currentUser.WalletBalance, 2)}";
            confirmTransactionBtn.Text = _walletAction; ;
        }

        //remove error messages
        private void ClearForm()
        {
            transactionErrorMsg.Text = "";
            lblAmountError.Text = "";
            lblCardNumError.Text = "";
            lblExpDateError.Text = "";
            lblCvvError.Text = "";
        }

        private bool ValidateEntries(string amount, string cardNumber, MaskedTextBox expiryDateTextBox, string cvv)
        {
            string expiryDate = expiryDateTextBox.Text.Trim();

            //check for empty fields
            if (!expiryDateTextBox.MaskFull || string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(expiryDate) || string.IsNullOrEmpty(cvv))
            {
                DisplayErrorMessage(transactionErrorMsg, "Please fill all fields");
                return false;
            }

            bool fieldValid, valid = true;
            string? message;

            //validate amount
            (fieldValid, message) = _validator.CheckAmount(amount);
            if (!fieldValid)
            {
                valid = false;
                DisplayErrorMessage(lblAmountError, message);
            }

            //validate cardNumber
            (fieldValid, message) = _validator.CheckCardNumber(cardNumber);
            if (!fieldValid)
            {
                valid = false;
                DisplayErrorMessage(lblCardNumError, message);
            }

            //validate expiryDate
            (fieldValid, message) = _validator.CheckExpiryDate(expiryDate);
            if (!fieldValid)
            {
                valid = false;
                DisplayErrorMessage(lblExpDateError, message);
            }

            //validate cvv
            (fieldValid, message) = _validator.CheckCVV(cvv);
            if (!fieldValid)
            {
                valid = false;
                DisplayErrorMessage(lblCvvError, message);
            }

            return valid;
        }

        private void DisplayErrorMessage(Label errorLbl, string errorMsg)
        {
            errorLbl.Text = errorMsg;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ClosePopup()
        {
            //check if current form is profile page to update balance displayed on it
            if (Application.OpenForms.OfType<AccountPage>().FirstOrDefault() is AccountPage profilePage)
            {
                profilePage.DisplayBalance();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void confirmTransactionBtn_Click(object sender, EventArgs e)
        {

            ClearForm();

            string amount = amountTextbox.Text.Trim();
            string cardNumer = cardNumTextbox.Text.Trim();
            string cvv = cvvTextbox.Text.Trim();

            if (!ValidateEntries(amount, cardNumer, txtExpDate, cvv))
                return;

            decimal amountEntered = Math.Round(decimal.Parse(amount), 2);
            bool valid;
            string message;

            // do transaction
            if (_walletAction == "Deposit") // to deposit money
            {
                (valid, message) = await _walletServices.DepositOrPayoutAsync(_currentUser, amountEntered, "deposit");
            }
            else //to withdraw money
            {
                (valid, message) = await _walletServices.WithdrawalOrPlaceBetAsync(_currentUser, amountEntered, "withdrawal");
            }
            if (valid)
            {
                ClosePopup();
            }
            else
            {
                DisplayErrorMessage(transactionErrorMsg, message);
            }
        }
    }
}
