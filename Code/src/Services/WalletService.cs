using BettingSystem.Data;
using BettingSystem.Models;

namespace BettingSystem.Services
{
    //handle adding and retrieving money from digital wallet
    public class WalletService
    {
        private readonly DatabaseManager DBManager;

        public WalletService()
        {
            DBManager = new DatabaseManager();
        }

        //add money to wallet during deposit or payout
        public async Task<(bool updated, string message)> DepositOrPayoutAsync(AppUser currentUser, decimal amount, string transactionType)
        {
            //check if user is adding more than 0
            if (amount <= 0)
                return (false, "Amount must be greater than 0");
            
            //calculate new wallet amount
            decimal newAmount = currentUser.WalletBalance + amount;

            //update user's wallet and record transaction in database 
            bool success = await DBManager.ProcessWalletTransactionAsync(currentUser.UserID, transactionType, newAmount, amount);

            if (!success)
                return (false, "Failed to process your transaction. Please try again.");

            currentUser.WalletBalance = newAmount;
            string message;
            if (transactionType == "deposit")
            {
                message = "Deposit completed successfully";
            }
            else
            {
                message = "Payout added to your wallet";
            }
            return (true, message);
        }

        //retrieve money from wallet during withdrawal or when placing bet
        public async Task<(bool updated, string message)> WithdrawalOrPlaceBetAsync(AppUser currentUser, decimal amount, string transactionType)
        {
            if (amount <= 0)
                return (false, "Amount must be greater than 0");

            //check if there is enough fund in wallet
            if (amount > currentUser.WalletBalance)
            {
                return (false, "Withdrawal Failed: Insufficient wallet balance");
            }

            decimal newAmount = currentUser.WalletBalance - amount;

            //update user's wallet and record transaction in database 
            bool success = await DBManager.ProcessWalletTransactionAsync(currentUser.UserID, transactionType, newAmount, amount);

            if (!success)
                return (false, "Failed to process your transaction. Please try again.");

            currentUser.WalletBalance = newAmount;
            string message;
            if (transactionType == "withdrawal")
            {
                message = "Withdrawal completed successfully";
            }
            else
            {
                message = "Stake placed successfully";
            }
            return (true, message);
        }
    }
}
