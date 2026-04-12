using BettingSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingSystemsTests;

/// <summary>
/// Tests core market generation and value sanity checks for OddsGenerator.
/// </summary>
[TestClass]
public class OddsGeneratorTests
{
    private readonly OddsGenerator _generator = new OddsGenerator();

    /// <summary>
    /// Stronger home team should generally produce shorter (lower) home win odds.
    /// </summary>
    [TestMethod]
    public void CalculateOutcomeOdds_StrongerHomeTeam_HomeOddsLowerThanAwayOdds()
    {
        var homeRatings = new TeamRatings(85, 75, 70, 6.0m);
        var awayRatings = new TeamRatings(55, 55, 70, 4.0m);

        OutcomeOdds odds = _generator.CalculateOutcomeOdds(homeRatings, awayRatings);

        Assert.IsTrue(odds.Home < odds.Away);
        Assert.IsTrue(odds.Home > 0m && odds.Draw > 0m && odds.Away > 0m);
    }

    /// <summary>
    /// Double chance market should always return the three standard selections.
    /// </summary>
    [TestMethod]
    public void GenerateDoubleChanceOdds_ReturnsThreeExpectedSelections()
    {
        IReadOnlyList<GeneratedOdd> odds = _generator.GenerateDoubleChanceOdds(10, 2.10m, 3.40m, 3.20m);

        Assert.AreEqual(3, odds.Count);
        CollectionAssert.AreEquivalent(
            new[] { "1X", "12", "X2" },
            odds.Select(x => x.Selection).ToArray());
        Assert.IsTrue(odds.All(x => x.BetTypeId == 2));
    }

    /// <summary>
    /// Correct-score odd includes expected identifiers and bounded odd value.
    /// </summary>
    [TestMethod]
    public void GenerateCorrectScoreOdd_ReturnsCorrectSelectionAndBetTypeId()
    {
        var homeRatings = new TeamRatings(75, 70, 70, 5.0m);
        var awayRatings = new TeamRatings(70, 72, 70, 5.0m);

        GeneratedOdd odd = _generator.GenerateCorrectScoreOdd(99, 2, 1, homeRatings, awayRatings);

        Assert.AreEqual(99, odd.GameId);
        Assert.AreEqual(3, odd.BetTypeId);
        Assert.AreEqual("2-1", odd.Selection);
        Assert.IsTrue(odd.OddValue >= 6.0m && odd.OddValue <= 100.0m);
    }

    /// <summary>
    /// Wrapper method should delegate consistently to the core correct-score generator.
    /// </summary>
    [TestMethod]
    public void GenerateCorrectScoreOdds_WrapperMatchesGenerateCorrectScoreOddValue()
    {
        var homeRatings = new TeamRatings(74, 69, 70, 5.1m);
        var awayRatings = new TeamRatings(71, 73, 70, 4.9m);

        decimal fromWrapper = _generator.GenerateCorrectScoreOdds(11, 1, 0, homeRatings, awayRatings);
        GeneratedOdd fromCore = _generator.GenerateCorrectScoreOdd(11, 1, 0, homeRatings, awayRatings);

        Assert.AreEqual(fromCore.OddValue, fromWrapper);
    }

    /// <summary>
    /// First-goal-scorer market should be omitted when no players are supplied.
    /// </summary>
    [TestMethod]
    public void BuildAllOddsForGame_NoPlayers_DoesNotIncludeFirstGoalScorerOdds()
    {
        var homeRatings = new TeamRatings(75, 70, 70, 5.0m);
        var awayRatings = new TeamRatings(65, 68, 70, 4.5m);

        IReadOnlyList<GeneratedOdd> odds = _generator.BuildAllOddsForGame(1, homeRatings, awayRatings);

        Assert.IsTrue(odds.Count > 0);
        Assert.IsFalse(odds.Any(x => x.BetTypeId == 6));
    }

    /// <summary>
    /// First-goal-scorer market should include one odd per provided player.
    /// </summary>
    [TestMethod]
    public void BuildAllOddsForGame_WithPlayers_IncludesFirstGoalScorerOddsPerPlayer()
    {
        var ratings = new TeamRatings(70, 70, 70, 5.0m);
        var players = new List<PlayerInfo>
        {
            new PlayerInfo(1, "Alice", "ATT", 80, 10),
            new PlayerInfo(2, "Bob", "MID", 60, 20)
        };

        IReadOnlyList<GeneratedOdd> odds = _generator.BuildAllOddsForGame(1, ratings, ratings, players);
        List<GeneratedOdd> firstScorerOdds = odds.Where(x => x.BetTypeId == 6).ToList();

        Assert.AreEqual(players.Count, firstScorerOdds.Count);
        CollectionAssert.AreEquivalent(players.Select(x => x.PlayerId.ToString()).ToArray(), firstScorerOdds.Select(x => x.Selection).ToArray());
    }

    /// <summary>
    /// Ensures all required core markets are present and generated values are usable.
    /// </summary>
    [TestMethod]
    public void BuildAllOddsForGame_ContainsCoreMarketBetTypeIds()
    {
        var ratings = new TeamRatings(70, 70, 70, 5.0m);
        IReadOnlyList<GeneratedOdd> odds = _generator.BuildAllOddsForGame(42, ratings, ratings);

        int[] requiredBetTypeIds = { 1, 2, 4, 5, 7, 8, 9 };
        foreach (int betTypeId in requiredBetTypeIds)
        {
            Assert.IsTrue(odds.Any(x => x.BetTypeId == betTypeId), $"Expected bet type id {betTypeId} not found.");
        }

        Assert.IsTrue(odds.All(x => x.GameId == 42));
        Assert.IsTrue(odds.All(x => x.OddValue > 0m));
    }
}
