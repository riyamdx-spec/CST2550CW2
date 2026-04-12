using BettingSystem.Data_Structures;
using BettingSystem.Models;
using BettingSystem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingSystemsTests;

/// <summary>
/// Tests league and team filtering behavior in MatchManager.
/// </summary>
[TestClass]
public class MatchManagerTests
{
    // Helper builds predictable matches for filter scenarios.
    private static FootballMatch MakeMatch(int gameId, int leagueId, int homeTeamId, int awayTeamId)
    {
        return new FootballMatch(
            gameID: gameId,
            leagueID: leagueId,
            homeTeamID: homeTeamId,
            awayTeamID: awayTeamId,
            gameDate: new DateTime(2026, 4, 10).AddDays(gameId));
    }

    // Helper creates team entries for search-by-name checks.
    private static Team MakeTeam(int teamId, string name)
        => new Team(teamId, name, "logo.png");

    /// <summary>
    /// Returns only matches from an existing league.
    /// </summary>
    [TestMethod]
    public void FilterMatchByLeague_WhenLeagueExists_ReturnsItsMatches()
    {
        var league1Matches = new MyList<FootballMatch>();
        league1Matches.Add(MakeMatch(1, 1, 10, 20));
        league1Matches.Add(MakeMatch(2, 1, 11, 21));

        var allMatches = new MyList<FootballMatch>(league1Matches);
        var byLeague = new MyDictionary<int, MyList<FootballMatch>>();
        byLeague.Add(1, league1Matches);

        var teams = new MyDictionary<int, Team>();
        teams.Add(10, MakeTeam(10, "Arsenal"));
        teams.Add(20, MakeTeam(20, "Chelsea"));

        var manager = new MatchManager(new FootballMatchCollection(allMatches, byLeague), teams);

        var result = manager.FilterMatchByLeague(1);

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(1, result[0].LeagueID);
        Assert.AreEqual(1, result[1].LeagueID);
    }

    /// <summary>
    /// Returns an empty list when league id does not exist.
    /// </summary>
    [TestMethod]
    public void FilterMatchByLeague_WhenLeagueMissing_ReturnsEmptyList()
    {
        var allMatches = new MyList<FootballMatch>();
        var byLeague = new MyDictionary<int, MyList<FootballMatch>>();
        var teams = new MyDictionary<int, Team>();

        var manager = new MatchManager(new FootballMatchCollection(allMatches, byLeague), teams);

        var result = manager.FilterMatchByLeague(999);

        Assert.AreEqual(0, result.Count);
    }

    /// <summary>
    /// Uses all matches when subset is not provided and supports partial team-name search.
    /// </summary>
    [TestMethod]
    public void FilterMatchByTeams_WithNullMatches_UsesAllMatchesAndFindsByPartialName()
    {
        var m1 = MakeMatch(1, 1, 10, 20);
        var m2 = MakeMatch(2, 1, 30, 40);

        var allMatches = new MyList<FootballMatch>();
        allMatches.Add(m1);
        allMatches.Add(m2);

        var byLeague = new MyDictionary<int, MyList<FootballMatch>>();
        byLeague.Add(1, new MyList<FootballMatch>(allMatches));

        var teams = new MyDictionary<int, Team>();
        teams.Add(10, MakeTeam(10, "Manchester United"));
        teams.Add(20, MakeTeam(20, "Chelsea"));
        teams.Add(30, MakeTeam(30, "Liverpool"));
        teams.Add(40, MakeTeam(40, "Arsenal"));

        var manager = new MatchManager(new FootballMatchCollection(allMatches, byLeague), teams);

        var result = manager.FilterMatchByTeams("man");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(1, result[0].GameID);
    }

    /// <summary>
    /// Verifies team-name filtering ignores letter casing.
    /// </summary>
    [TestMethod]
    public void FilterMatchByTeams_IsCaseInsensitive()
    {
        var allMatches = new MyList<FootballMatch>();
        allMatches.Add(MakeMatch(1, 1, 10, 20));

        var byLeague = new MyDictionary<int, MyList<FootballMatch>>();
        byLeague.Add(1, new MyList<FootballMatch>(allMatches));

        var teams = new MyDictionary<int, Team>();
        teams.Add(10, MakeTeam(10, "Real Madrid"));
        teams.Add(20, MakeTeam(20, "Barcelona"));

        var manager = new MatchManager(new FootballMatchCollection(allMatches, byLeague), teams);

        var result = manager.FilterMatchByTeams("REAL");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(1, result[0].GameID);
    }

    /// <summary>
    /// Returns empty when no teams match the search term.
    /// </summary>
    [TestMethod]
    public void FilterMatchByTeams_WhenSearchHasNoTeamMatch_ReturnsEmptyList()
    {
        var allMatches = new MyList<FootballMatch>();
        allMatches.Add(MakeMatch(1, 1, 10, 20));

        var byLeague = new MyDictionary<int, MyList<FootballMatch>>();
        byLeague.Add(1, new MyList<FootballMatch>(allMatches));

        var teams = new MyDictionary<int, Team>();
        teams.Add(10, MakeTeam(10, "Inter"));
        teams.Add(20, MakeTeam(20, "Milan"));

        var manager = new MatchManager(new FootballMatchCollection(allMatches, byLeague), teams);

        var result = manager.FilterMatchByTeams("Dortmund");

        Assert.AreEqual(0, result.Count);
    }

    /// <summary>
    /// Restricts team search to the provided subset when one is supplied.
    /// </summary>
    [TestMethod]
    public void FilterMatchByTeams_WithProvidedSubset_OnlySearchesInsideThatSubset()
    {
        var m1 = MakeMatch(1, 1, 10, 20);
        var m2 = MakeMatch(2, 1, 30, 40);

        var allMatches = new MyList<FootballMatch>();
        allMatches.Add(m1);
        allMatches.Add(m2);

        var subset = new MyList<FootballMatch>();
        subset.Add(m2);

        var byLeague = new MyDictionary<int, MyList<FootballMatch>>();
        byLeague.Add(1, new MyList<FootballMatch>(allMatches));

        var teams = new MyDictionary<int, Team>();
        teams.Add(10, MakeTeam(10, "Tottenham"));
        teams.Add(20, MakeTeam(20, "Everton"));
        teams.Add(30, MakeTeam(30, "Leeds"));
        teams.Add(40, MakeTeam(40, "Leicester"));

        var manager = new MatchManager(new FootballMatchCollection(allMatches, byLeague), teams);

        var result = manager.FilterMatchByTeams("tot", subset);

        Assert.AreEqual(0, result.Count);
    }
}
