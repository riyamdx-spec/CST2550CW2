using BettingSystem.Data_Structures;
using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystemsTests;

/// <summary>
/// Tests status filtering and ordering behavior of BetSlipFilter.
/// </summary>
[TestClass]
public class BetSlipFilterTests
{
    // Helper keeps slip creation consistent across scenarios.
    private static BetHistorySlip MakeSlip(int slipId, DateTime date, string status)
    {
        return new BetHistorySlip(
            slipID: slipId,
            userID: 1,
            betDate: date,
            stake: 10m,
            totalOdds: 2m,
            payout: 20m,
            status: status,
            claimed: false);
    }

    /// <summary>
    /// Confirms "All" bypasses status filtering and preserves original order.
    /// </summary>
    [TestMethod]
    public void FilterBetSlips_StatusAll_ReturnsAllInOriginalOrder()
    {
        var slips = new MyList<BetHistorySlip>();
        slips.Add(MakeSlip(1, new DateTime(2026, 4, 3), "Won"));
        slips.Add(MakeSlip(2, new DateTime(2026, 4, 2), "Lost"));

        var filter = new BetSlipFilter();

        var result = filter.FilterBetSlips(slips, "All", ascending: false);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(1, result[0].SlipID);
        Assert.AreEqual(2, result[1].SlipID);
    }

    /// <summary>
    /// Confirms null status behaves like no filter.
    /// </summary>
    [TestMethod]
    public void FilterBetSlips_StatusNull_TreatedAsNoFilter()
    {
        var slips = new MyList<BetHistorySlip>();
        slips.Add(MakeSlip(10, new DateTime(2026, 4, 3), "Won"));
        slips.Add(MakeSlip(20, new DateTime(2026, 4, 2), "Lost"));

        var filter = new BetSlipFilter();

        var result = filter.FilterBetSlips(slips, null, ascending: false);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(10, result[0].SlipID);
        Assert.AreEqual(20, result[1].SlipID);
    }

    /// <summary>
    /// Verifies status matching is case-insensitive.
    /// </summary>
    [TestMethod]
    public void FilterBetSlips_ByStatus_ReturnsOnlyMatchingSlips_CaseInsensitive()
    {
        var slips = new MyList<BetHistorySlip>();
        slips.Add(MakeSlip(1, new DateTime(2026, 4, 3), "Won"));
        slips.Add(MakeSlip(2, new DateTime(2026, 4, 2), "Lost"));
        slips.Add(MakeSlip(3, new DateTime(2026, 4, 1), "won"));

        var filter = new BetSlipFilter();

        var result = filter.FilterBetSlips(slips, "WON", ascending: false);

        Assert.AreEqual(2, result.Count);
        Assert.IsTrue(result[0].Status.Equals("Won", StringComparison.OrdinalIgnoreCase));
        Assert.IsTrue(result[1].Status.Equals("Won", StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Verifies ascending mode reverses the filtered result order.
    /// </summary>
    [TestMethod]
    public void FilterBetSlips_AscendingTrue_ReversesFilteredOrder()
    {
        var slips = new MyList<BetHistorySlip>();
        slips.Add(MakeSlip(1, new DateTime(2026, 4, 3), "Won"));
        slips.Add(MakeSlip(2, new DateTime(2026, 4, 2), "Lost"));
        slips.Add(MakeSlip(3, new DateTime(2026, 4, 1), "Won"));

        var filter = new BetSlipFilter();

        var result = filter.FilterBetSlips(slips, "Won", ascending: true);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(3, result[0].SlipID);
        Assert.AreEqual(1, result[1].SlipID);
    }
}
