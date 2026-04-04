using BettingSystem.Models;
using BettingSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingSystemsTests;

/// <summary>
/// Tests WalletService validation paths and balance boundary behavior.
/// </summary>
[TestClass]
public class WalletServiceTests
{
    // Helper produces a consistent user object with a configurable starting balance.
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

    /// <summary>
    /// Deposit and payout reject zero amount before any persistence call.
    /// </summary>
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

    /// <summary>
    /// Deposit and payout reject negative amount before any persistence call.
    /// </summary>
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

    /// <summary>
    /// Withdrawal and bet placement reject zero amount.
    /// </summary>
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

    /// <summary>
    /// Withdrawal and bet placement reject negative amount.
    /// </summary>
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

    /// <summary>
    /// Withdrawal fails when requested amount is greater than available balance.
    /// </summary>
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

    /// <summary>
    /// Payout requests must include a slip id to be considered valid.
    /// </summary>
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

    /// <summary>
    /// Verifies the exact-balance boundary is allowed by validation (amount > balance check).
    /// </summary>
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

    /// <summary>
    /// Verifies values just above the balance are rejected.
    /// </summary>
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
