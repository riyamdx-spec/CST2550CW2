using BettingSystem.Models;

namespace BettingSystemsTests;

/// <summary>
/// Test class for the BetSlip model.
/// Covers AddBet, RemoveBet, CalculateTotalOdds, CalculatePayout and RemoveBetsByGameIds.
/// </summary>
[TestClass]
public class BetSlipTests
{
    // ==================== HELPER ====================

    /// <summary>
    /// Creates a minimal valid bet for slip behavior tests with overridable game/type/odd values.
    /// </summary>
    private static Bet MakeBet(int gameId = 1, int betTypeId = 1, decimal oddValue = 2.0m)
        => new Bet(10, "Home Win", oddValue, betTypeId, gameId);

    // ==================== CONSTRUCTOR TESTS ====================

    /// <summary>
    /// Test: Constructor initialises the slip with an empty bet list and TotalOdds = 1.
    /// </summary>
    [TestMethod]
    public void Constructor_InitialisesEmptySlip()
    {
        // ARRANGE & ACT
        var slip = new BetSlip(userID: 7);

        // ASSERT
        Assert.AreEqual(7, slip.UserID);
        Assert.AreEqual(0, slip.Bets.Count);
        Assert.AreEqual(1m, slip.TotalOdds);
        Assert.AreEqual(0m, slip.Stake);
    }

    // ==================== ADDBET TESTS ====================

    /// <summary>
    /// Test: Adding a new bet to an empty slip returns "Bet added" and increments count.
    /// </summary>
    [TestMethod]
    public void AddBet_NewBet_ReturnsBetAddedAndIncreasesCount()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        var bet = MakeBet(gameId: 1, betTypeId: 1, oddValue: 2.5m);

        // ACT
        string result = slip.AddBet(bet);

        // ASSERT
        Assert.AreEqual("Bet added", result);
        Assert.AreEqual(1, slip.Bets.Count);
    }

    /// <summary>
    /// Test: Adding a bet for a game/betType that already exists updates instead of duplicating.
    /// </summary>
    [TestMethod]
    public void AddBet_DuplicateGameAndBetType_ReturnsBetUpdated()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        var originalBet = new Bet(1, "Home Win", 2.0m, 1, 1);
        var updatedBet  = new Bet(2, "Away Win", 3.5m, 1, 1);

        slip.AddBet(originalBet);

        // ACT
        string result = slip.AddBet(updatedBet);

        // ASSERT
        Assert.AreEqual("Bet updated", result);
        Assert.AreEqual(1, slip.Bets.Count, "Slip should still contain only one bet for this game/type");
        Assert.AreEqual(3.5m, slip.Bets.First!.Value.OddValue, "Odd value should be updated to new bet");
    }

    /// <summary>
    /// Test: Adding two bets for different games keeps both in the slip.
    /// </summary>
    [TestMethod]
    public void AddBet_TwoDifferentGames_BothRetained()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        var bet1 = MakeBet(gameId: 1, betTypeId: 1, oddValue: 2.0m);
        var bet2 = MakeBet(gameId: 2, betTypeId: 1, oddValue: 1.5m);

        // ACT
        slip.AddBet(bet1);
        slip.AddBet(bet2);

        // ASSERT
        Assert.AreEqual(2, slip.Bets.Count);
    }

    // ==================== REMOVEBET TESTS ====================

    /// <summary>
    /// Test: Removing a bet that has a valid node succeeds.
    /// </summary>
    [TestMethod]
    public void RemoveBet_ExistingBet_ReturnsTrueAndDecreasesCount()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        var bet = MakeBet();
        slip.AddBet(bet);

        // ACT
        var (success, message) = slip.RemoveBet(bet);

        // ASSERT
        Assert.IsTrue(success);
        Assert.AreEqual("Bet removed", message);
        Assert.AreEqual(0, slip.Bets.Count);
    }

    /// <summary>
    /// Test: Removing a bet with no node reference returns false and an error message.
    /// </summary>
    [TestMethod]
    public void RemoveBet_BetWithNoNode_ReturnsFalseAndMessage()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        var bet = MakeBet(); // Node is null – never added to the slip

        // ACT
        var (success, message) = slip.RemoveBet(bet);

        // ASSERT
        Assert.IsFalse(success);
        Assert.AreEqual("Bet not found in slip", message);
    }

    // ==================== CALCULATETOTALODDS TESTS ====================

    /// <summary>
    /// Test: TotalOdds is 1 when slip is empty.
    /// </summary>
    [TestMethod]
    public void TotalOdds_EmptySlip_IsOne()
    {
        var slip = new BetSlip(userID: 1);
        Assert.AreEqual(1m, slip.TotalOdds);
    }

    /// <summary>
    /// Test: TotalOdds is the product of all bet odds.
    /// </summary>
    [TestMethod]
    public void TotalOdds_MultipleBeats_IsProduct()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        slip.AddBet(MakeBet(gameId: 1, betTypeId: 1, oddValue: 2.0m));
        slip.AddBet(MakeBet(gameId: 2, betTypeId: 1, oddValue: 3.0m));
        slip.AddBet(MakeBet(gameId: 3, betTypeId: 1, oddValue: 1.5m));

        // ACT & ASSERT
        Assert.AreEqual(2.0m * 3.0m * 1.5m, slip.TotalOdds, "TotalOdds should equal the product of all individual odds");
    }

    /// <summary>
    /// Test: TotalOdds resets to 1 after all bets are removed.
    /// </summary>
    [TestMethod]
    public void TotalOdds_AfterRemovingAllBets_ResetsToOne()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        var bet = MakeBet(oddValue: 3.0m);
        slip.AddBet(bet);

        // ACT
        slip.RemoveBet(bet);

        // ASSERT
        Assert.AreEqual(1m, slip.TotalOdds, "TotalOdds should reset to 1 when all bets are removed");
    }

    // ==================== CALCULATEPAYOUT TESTS ====================

    /// <summary>
    /// Test: CalculatePayout returns Stake × TotalOdds rounded to 2 decimal places.
    /// </summary>
    [TestMethod]
    public void CalculatePayout_ReturnsStakeMultipliedByTotalOdds()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        slip.AddBet(MakeBet(gameId: 1, betTypeId: 1, oddValue: 2.5m));
        slip.Stake = 20m;

        // ACT
        decimal payout = slip.CalculatePayout();

        // ASSERT
        Assert.AreEqual(50.00m, payout, "Payout should be Stake × TotalOdds = 20 × 2.5 = 50");
    }

    /// <summary>
    /// Test: CalculatePayout with zero stake returns 0.
    /// </summary>
    [TestMethod]
    public void CalculatePayout_ZeroStake_ReturnsZero()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        slip.AddBet(MakeBet(oddValue: 3.0m));
        slip.Stake = 0m;

        // ACT
        decimal payout = slip.CalculatePayout();

        // ASSERT
        Assert.AreEqual(0m, payout);
    }

    // ==================== REMOVEBETSBYGAMEIDS TESTS ====================

    /// <summary>
    /// Test: RemoveBetsByGameIds removes only bets belonging to the supplied game IDs.
    /// </summary>
    [TestMethod]
    public void RemoveBetsByGameIds_RemovesMatchingBets()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        var bet1 = MakeBet(gameId: 10, betTypeId: 1, oddValue: 2.0m);
        var bet2 = MakeBet(gameId: 20, betTypeId: 1, oddValue: 1.5m);
        var bet3 = MakeBet(gameId: 30, betTypeId: 1, oddValue: 3.0m);
        slip.AddBet(bet1);
        slip.AddBet(bet2);
        slip.AddBet(bet3);

        // ACT
        bool changed = slip.RemoveBetsByGameIds(new List<int> { 10, 30 });

        // ASSERT
        Assert.IsTrue(changed, "Should report that bets were removed");
        Assert.AreEqual(1, slip.Bets.Count, "Only the bet for game 20 should remain");
        Assert.AreEqual(20, slip.Bets.First!.Value.GameID);
    }

    /// <summary>
    /// Test: RemoveBetsByGameIds returns false when no supplied game IDs match.
    /// </summary>
    [TestMethod]
    public void RemoveBetsByGameIds_NoMatchingIds_ReturnsFalse()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        slip.AddBet(MakeBet(gameId: 5));

        // ACT
        bool changed = slip.RemoveBetsByGameIds(new List<int> { 99 });

        // ASSERT
        Assert.IsFalse(changed, "Should return false when no bets were removed");
        Assert.AreEqual(1, slip.Bets.Count);
    }

    /// <summary>
    /// Test: RemoveBetsByGameIds on an empty slip returns false.
    /// </summary>
    [TestMethod]
    public void RemoveBetsByGameIds_EmptySlip_ReturnsFalse()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);

        // ACT
        bool changed = slip.RemoveBetsByGameIds(new List<int> { 1, 2, 3 });

        // ASSERT
        Assert.IsFalse(changed);
    }

    /// <summary>
    /// Test: TotalOdds recalculates correctly after RemoveBetsByGameIds.
    /// </summary>
    [TestMethod]
    public void RemoveBetsByGameIds_TotalOddsRecalculatedAfterRemoval()
    {
        // ARRANGE
        var slip = new BetSlip(userID: 1);
        slip.AddBet(MakeBet(gameId: 1, betTypeId: 1, oddValue: 2.0m));
        slip.AddBet(MakeBet(gameId: 2, betTypeId: 1, oddValue: 3.0m));

        // ACT – remove game 1 (odds 2.0), leaving game 2 (odds 3.0)
        slip.RemoveBetsByGameIds(new List<int> { 1 });

        // ASSERT
        Assert.AreEqual(3.0m, slip.TotalOdds, "TotalOdds should reflect only the remaining bet");
    }
}


