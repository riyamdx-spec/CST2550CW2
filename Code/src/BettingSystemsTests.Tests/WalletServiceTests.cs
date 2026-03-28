using BettingSystem.Models;
using BettingSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingSystemsTests;

[TestClass]
public class WalletServiceTests
{
    private static AppUser CreateUser(decimal walletBalance = 100m)
    {
        return new AppUser(
            id: 1,
            fName: "Test",
            lName: "User",
            DOB: new DateTime(2000, 1, 1),
            mail: "test@example.com",
            balance: walletBalance,
            userRole: "customer");
    }

    [TestMethod]
    public async Task DepositOrPayoutAsync_AmountZero_ReturnsFalseAndMessage()
    {
        var service = new WalletService();
        var user = CreateUser(100m);

        var (updated, message) = await service.DepositOrPayoutAsync(user, 0m, "deposit");

        Assert.IsFalse(updated);
        Assert.AreEqual("Amount must be greater than 0", message);
        Assert.AreEqual(100m, user.WalletBalance);
    }

    [TestMethod]
    public async Task DepositOrPayoutAsync_AmountNegative_ReturnsFalseAndMessage()
    {
        var service = new WalletService();
        var user = CreateUser(100m);

        var (updated, message) = await service.DepositOrPayoutAsync(user, -20m, "deposit");

        Assert.IsFalse(updated);
        Assert.AreEqual("Amount must be greater than 0", message);
        Assert.AreEqual(100m, user.WalletBalance);
    }

    [TestMethod]
    public async Task WithdrawalOrPlaceBetAsync_AmountZero_ReturnsFalseAndMessage()
    {
        var service = new WalletService();
        var user = CreateUser(100m);

        var (updated, message) = await service.WithdrawalOrPlaceBetAsync(user, 0m, "withdrawal");

        Assert.IsFalse(updated);
        Assert.AreEqual("Amount must be greater than 0", message);
        Assert.AreEqual(100m, user.WalletBalance);
    }

    [TestMethod]
    public async Task WithdrawalOrPlaceBetAsync_AmountNegative_ReturnsFalseAndMessage()
    {
        var service = new WalletService();
        var user = CreateUser(100m);

        var (updated, message) = await service.WithdrawalOrPlaceBetAsync(user, -10m, "withdrawal");

        Assert.IsFalse(updated);
        Assert.AreEqual("Amount must be greater than 0", message);
        Assert.AreEqual(100m, user.WalletBalance);
    }

    [TestMethod]
    public async Task WithdrawalOrPlaceBetAsync_InsufficientBalance_ReturnsFalseAndMessage()
    {
        var service = new WalletService();
        var user = CreateUser(50m);

        var (updated, message) = await service.WithdrawalOrPlaceBetAsync(user, 60m, "withdrawal");

        Assert.IsFalse(updated);
        Assert.AreEqual("Withdrawal Failed: Insufficient wallet balance", message);
        Assert.AreEqual(50m, user.WalletBalance);
    }

    [TestMethod]
    public async Task DepositOrPayoutAsync_PayoutWithoutSlipId_ReturnsFalseAndMessage()
    {
        var service = new WalletService();
        var user = CreateUser(100m);

        var (updated, message) = await service.DepositOrPayoutAsync(user, 50m, "payout", slipId: null);

        Assert.IsFalse(updated);
        Assert.AreEqual("Invalid payout request", message);
        Assert.AreEqual(100m, user.WalletBalance);
    }

    [TestMethod]
    public async Task WithdrawalOrPlaceBetAsync_ExactBalance_ReturnsFalseWhenExceeds()
    {
        // Withdrawing exactly the balance should NOT fail the balance check
        // because the check is amount > balance, not amount >= balance.
        // This verifies the boundary: equal amounts are allowed.
        var service = new WalletService();
        var user = CreateUser(100m);

        // amount == balance should pass the balance check (100 > 100 is false)
        // It will hit the DB call which returns false in test context,
        // so we only verify the balance was not rejected for being too high.
        var (updated, message) = await service.WithdrawalOrPlaceBetAsync(user, 100m, "withdrawal");

        // The balance check passes; the only reason it could fail is the DB call
        Assert.AreNotEqual("Withdrawal Failed: Insufficient wallet balance", message);
    }

    [TestMethod]
    public async Task WithdrawalOrPlaceBetAsync_AmountExceedsBalance_ReturnsFalseAndMessage()
    {
        var service = new WalletService();
        var user = CreateUser(30m);

        var (updated, message) = await service.WithdrawalOrPlaceBetAsync(user, 30.01m, "withdrawal");

        Assert.IsFalse(updated);
        Assert.AreEqual("Withdrawal Failed: Insufficient wallet balance", message);
        Assert.AreEqual(30m, user.WalletBalance);
    }
}
