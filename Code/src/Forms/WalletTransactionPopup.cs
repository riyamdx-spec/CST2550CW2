using BettingSystem.Models;
using System.Drawing.Drawing2D;
using BettingSystem.Forms.Properties;
using BettingSystem.Services;

namespace BettingSystem.Forms
{
    public partial class WalletPopup : Form
    {
        private AppUser CurrentUser;
        private string WalletAction;
        private readonly Validation Validator;
        private readonly WalletService WalletServices;


        public WalletPopup(string action, AppUser loggedInUser)
        {
            CurrentUser = loggedInUser;
            WalletAction = action;
            Validator = new Validation();
            WalletServices = new WalletService();

            InitializeComponent();

            LoadDetails();
        }

        private void LoadDetails()
        {
            lblBalance.Text = $"Current Balance: ${Math.Round(CurrentUser.WalletBalance, 2)}";
            confirmTransactionBtn.Text = WalletAction; ;
        }

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
            (fieldValid, message) = Validator.CheckAmount(amount);
            if (!fieldValid)
            {
                valid = false;
                DisplayErrorMessage(lblAmountError, message);
            }

            //validate cardNumber
            (fieldValid, message) = Validator.CheckCardNumber(cardNumber);
            if (!fieldValid)
            {
                valid = false;
                DisplayErrorMessage(lblCardNumError, message);
            }

            //validate expiryDate
            (fieldValid, message) = Validator.CheckExpiryDate(expiryDate);
            if (!fieldValid)
            {
                valid = false;
                DisplayErrorMessage(lblExpDateError, message);
            }

            //validate cvv
            (fieldValid, message) = Validator.CheckCVV(cvv);
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

        private async void confirmTransactionBtn_Click(object sender, EventArgs e)
        {

            ClearForm();

            string amount = amountTextbox.Text.Trim();
            string cardNumer = cardNumTextbox.Text.Trim();
            string cvv = cvvTextbox.Text.Trim();

            if (!ValidateEntries(amount, cardNumer, txtExpDate, cvv))
                return;

            decimal amountEntered = Math.Round(decimal.Parse(amount), 2);

            // do transaction
            if (WalletAction == "Deposit") // to deposit money
            {
                (bool valid, string message) = await WalletServices.DepositOrPayoutAsync(CurrentUser, amountEntered, "deposit");
                if (valid)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    DisplayErrorMessage(transactionErrorMsg, message);
                }

            }
            else //to withdraw money
            {
                (bool valid, string message) = await WalletServices.WithdrawalOrPlaceBetAsync(CurrentUser, amountEntered, "withdrawal");
                if (valid)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    DisplayErrorMessage(transactionErrorMsg, message);
                }

            }
        }
    }
}
