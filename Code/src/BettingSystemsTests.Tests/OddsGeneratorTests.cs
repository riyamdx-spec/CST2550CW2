using BettingSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingSystemsTests;

/// <summary>
/// Tests for OddsGenerator pure-calculation methods that require no database connection.
/// </summary>
[TestClass]
public class OddsGeneratorTests
{
    // Pass null so no DB connection is attempted
    private readonly OddsGenerator _generator = new OddsGenerator(connectionString: null);

    // ==================== CALCULATEOUTCOMEODDS TESTS ====================

    /// <summary>
    /// Test: Home team with higher attack rating should receive lower (more favourable) home-win odds
    /// than the away team's win odds.
    /// </summary>
    [TestMethod]
    public void CalculateOutcomeOdds_StrongerHomeTeam_HomeOddsLowerThanAwayOdds()
    {
        // ARRANGE
        var homeRatings = new TeamRatings(Attack: 85, Defense: 75, Discipline: 70, AvgCorners: 6.0m);
        var awayRatings = new TeamRatings(Attack: 55, Defense: 55, Discipline: 70, AvgCorners: 4.0m);

        // ACT
        OutcomeOdds odds = _generator.CalculateOutcomeOdds(homeRatings, awayRatings);

        // ASSERT
        Assert.IsTrue(odds.Home < odds.Away,
            $"Stronger home team should have lower odds (Home={odds.Home}, Away={odds.Away})");
    }

    /// <summary>
    /// Test: All three outcome odds (Home, Draw, Away) should be positive numbers.
    /// </summary>
    [TestMethod]
    public void CalculateOutcomeOdds_AllOddsArePositive()
    {
        // ARRANGE
        var homeRatings = new TeamRatings(70, 70, 70, 5.0m);
        var awayRatings = new TeamRatings(70, 70, 70, 5.0m);

        // ACT
        OutcomeOdds odds = _generator.CalculateOutcomeOdds(homeRatings, awayRatings);

        // ASSERT
        Assert.IsTrue(odds.Home > 0m, "Home odds must be positive");
        Assert.IsTrue(odds.Draw > 0m, "Draw odds must be positive");
        Assert.IsTrue(odds.Away > 0m, "Away odds must be positive");
    }

    /// <summary>
    /// Test: Equal teams should produce roughly symmetrical home/away odds.
    /// </summary>
    [TestMethod]
    public void CalculateOutcomeOdds_EqualTeams_HomeAndAwayOddsAreClose()
    {
        // ARRANGE – identical ratings, but home side gets +15 home advantage internally
        var ratings = new TeamRatings(70, 70, 70, 5.0m);

        // ACT
        OutcomeOdds odds = _generator.CalculateOutcomeOdds(ratings, ratings);

        // ASSERT: home advantage means home odds ≤ away odds
        Assert.IsTrue(odds.Home <= odds.Away,
            "With equal teams the home advantage should make home odds <= away odds");
    }

    /// <summary>
    /// Test: Outcome odds should be within a sensible betting range (1.05 – 15).
    /// </summary>
    [TestMethod]
    public void CalculateOutcomeOdds_OddsWithinExpectedRange()
    {
        // ARRANGE
        var homeRatings = new TeamRatings(80, 80, 80, 6.0m);
        var awayRatings = new TeamRatings(60, 60, 60, 4.0m);

        // ACT
        OutcomeOdds odds = _generator.CalculateOutcomeOdds(homeRatings, awayRatings);

        // ASSERT
        Assert.IsTrue(odds.Home  >= 1.20m && odds.Home  <= 15.00m, $"Home odds {odds.Home} out of range");
        Assert.IsTrue(odds.Draw  >= 2.00m && odds.Draw  <= 15.00m, $"Draw odds {odds.Draw} out of range");
        Assert.IsTrue(odds.Away  >= 1.20m && odds.Away  <= 15.00m, $"Away odds {odds.Away} out of range");
    }

    // ==================== GENERATECORRECTSCOREODD TESTS ====================

    /// <summary>
    /// Test: GenerateCorrectScoreOdd returns an odd with a value within the allowed range (6 – 100).
    /// </summary>
    [TestMethod]
    public void GenerateCorrectScoreOdd_ReturnsOddWithinRange()
    {
        // ARRANGE
        var homeRatings = new TeamRatings(75, 70, 70, 5.0m);
        var awayRatings = new TeamRatings(70, 72, 70, 5.0m);

        // ACT
        GeneratedOdd odd = _generator.GenerateCorrectScoreOdd(
            gameId: 1, homeGoals: 1, awayGoals: 0, homeRatings, awayRatings);

        // ASSERT
        Assert.IsTrue(odd.OddValue >= 6.0m && odd.OddValue <= 100.0m,
            $"Correct-score odd value {odd.OddValue} is outside the expected range 6–100");
    }

    /// <summary>
    /// Test: GenerateCorrectScoreOdd selection string matches the supplied score.
    /// </summary>
    [TestMethod]
    public void GenerateCorrectScoreOdd_SelectionMatchesSuppliedScore()
    {
        // ARRANGE
        var homeRatings = new TeamRatings(75, 70, 70, 5.0m);
        var awayRatings = new TeamRatings(70, 72, 70, 5.0m);

        // ACT
        GeneratedOdd odd = _generator.GenerateCorrectScoreOdd(
            gameId: 99, homeGoals: 2, awayGoals: 1, homeRatings, awayRatings);

        // ASSERT
        Assert.AreEqual("2-1", odd.Selection, "Selection should be in the format 'homeGoals-awayGoals'");
    }

    /// <summary>
    /// Test: GenerateCorrectScoreOdd uses the correct bet-type name.
    /// </summary>
    [TestMethod]
    public void GenerateCorrectScoreOdd_BetTypeNameIsCorrectScore()
    {
        // ARRANGE
        var ratings = new TeamRatings(70, 70, 70, 5.0m);

        // ACT
        GeneratedOdd odd = _generator.GenerateCorrectScoreOdd(1, 0, 0, ratings, ratings);

        // ASSERT
        Assert.AreEqual("Correct Score", odd.BetTypeName);
    }

    /// <summary>
    /// Test: A common result (1-0) should have lower odds (more probable) than a rare result (5-4).
    /// </summary>
    [TestMethod]
    public void GenerateCorrectScoreOdd_CommonResultHasLowerOddsThanRareResult()
    {
        // ARRANGE
        var homeRatings = new TeamRatings(75, 70, 70, 5.0m);
        var awayRatings = new TeamRatings(70, 72, 70, 5.0m);

        // ACT
        GeneratedOdd commonOdd = _generator.GenerateCorrectScoreOdd(1, 1, 0, homeRatings, awayRatings);
        GeneratedOdd rareOdd   = _generator.GenerateCorrectScoreOdd(1, 5, 4, homeRatings, awayRatings);

        // ASSERT
        Assert.IsTrue(commonOdd.OddValue < rareOdd.OddValue,
            $"1-0 ({commonOdd.OddValue}) should have lower odds than 5-4 ({rareOdd.OddValue})");
    }

    // ==================== BUILDALLODDSFORAGAME TESTS ====================

    /// <summary>
    /// Test: BuildAllOddsForGame without players generates a non-empty list of odds.
    /// </summary>
    [TestMethod]
    public void BuildAllOddsForGame_NoPlayers_ReturnsNonEmptyList()
    {
        // ARRANGE
        var homeRatings = new TeamRatings(75, 70, 70, 5.0m);
        var awayRatings = new TeamRatings(65, 68, 70, 4.5m);

        // ACT
        var odds = _generator.BuildAllOddsForGame(gameId: 1, homeRatings, awayRatings);

        // ASSERT
        Assert.IsTrue(odds.Count > 0, "BuildAllOddsForGame should return at least some odds");
    }

    /// <summary>
    /// Test: BuildAllOddsForGame includes the expected market names.
    /// </summary>
    [TestMethod]
    public void BuildAllOddsForGame_ContainsExpectedMarkets()
    {
        // ARRANGE
        var ratings = new TeamRatings(70, 70, 70, 5.0m);
        var expectedMarkets = new[]
        {
            "Match Outcome",
            "Double Chance",
            "Over/Under",
            "Both Teams to Score",
            "Total Corners",
            "Yellow Cards",
            "Red Cards"
        };

        // ACT
        var odds = _generator.BuildAllOddsForGame(gameId: 1, ratings, ratings);
        var returnedMarkets = odds.Select(o => o.BetTypeName).Distinct().ToHashSet();

        // ASSERT
        foreach (var market in expectedMarkets)
        {
            Assert.IsTrue(returnedMarkets.Contains(market),
                $"Expected market '{market}' was not found in generated odds");
        }
    }

    /// <summary>
    /// Test: BuildAllOddsForGame includes first-goal-scorer odds when players are provided.
    /// </summary>
    [TestMethod]
    public void BuildAllOddsForGame_WithPlayers_IncludesFirstGoalScorerOdds()
    {
        // ARRANGE
        var ratings = new TeamRatings(70, 70, 70, 5.0m);
        var players = new List<PlayerInfo>
        {
            new PlayerInfo(PlayerId: 1, PlayerName: "Alice",  Position: "ATT", ScoringRating: 80, TeamId: 10),
            new PlayerInfo(PlayerId: 2, PlayerName: "Bob",    Position: "MID", ScoringRating: 60, TeamId: 20)
        };

        // ACT
        var odds = _generator.BuildAllOddsForGame(gameId: 1, ratings, ratings, players);
        var hasFirstGoalScorer = odds.Any(o => o.BetTypeName == "First Goal Scorer");

        // ASSERT
        Assert.IsTrue(hasFirstGoalScorer, "First Goal Scorer odds should be included when players are provided");
    }

    /// <summary>
    /// Test: All generated odds values are positive.
    /// </summary>
    [TestMethod]
    public void BuildAllOddsForGame_AllOddValuesArePositive()
    {
        // ARRANGE
        var homeRatings = new TeamRatings(75, 68, 72, 5.5m);
        var awayRatings = new TeamRatings(65, 75, 65, 4.0m);

        // ACT
        var odds = _generator.BuildAllOddsForGame(gameId: 5, homeRatings, awayRatings);

        // ASSERT
        foreach (var odd in odds)
        {
            Assert.IsTrue(odd.OddValue > 0m,
                $"Odd '{odd.BetTypeName} – {odd.Selection}' has non-positive value {odd.OddValue}");
        }
    }

    /// <summary>
    /// Test: BuildAllOddsForGame assigns the correct GameId to every generated odd.
    /// </summary>
    [TestMethod]
    public void BuildAllOddsForGame_AllOddsHaveCorrectGameId()
    {
        // ARRANGE
        var ratings = new TeamRatings(70, 70, 70, 5.0m);
        const int expectedGameId = 42;

        // ACT
        var odds = _generator.BuildAllOddsForGame(gameId: expectedGameId, ratings, ratings);

        // ASSERT
        foreach (var odd in odds)
        {
            Assert.AreEqual(expectedGameId, odd.GameId,
                $"Odd '{odd.BetTypeName} – {odd.Selection}' has wrong GameId");
        }
    }
}

