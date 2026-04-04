using System.Reflection;
using BettingSystem.Data_Structures;
using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystemsTests;

/// <summary>
/// Tests AddNewMatchService in-memory updates and generated game result constraints.
/// </summary>
[TestClass]
public class AddNewMatchServiceTests
{
    // Helper creates an admin session context expected by AddNewMatchService.
    private static AppUser CreateAdminUser()
    {
        return new AppUser(
            id: 99,
            fName: "Rayan",
            lName: "Tester",
            DOB: new DateTime(2005, 2, 1),
            mail: "tester@gmail.com",
            balance: 0m,
            userRole: "admin",
            registrationDate: new DateTime(2024, 1, 1),
            status: "active");
    }

    // Helper seeds the session with an empty league bucket for target league lookups.
    private static SessionManager CreateSessionWithMatches(int leagueId)
    {
        var session = new SessionManager(CreateAdminUser(), new Simulator())
        {
            GameResults = new MyDictionary<int, GameResult>(),
            MatchesCollection = new FootballMatchCollection(
                new MyList<FootballMatch>(),
                new MyDictionary<int, MyList<FootballMatch>>())
        };

        session.MatchesCollection.MatchesByLeague.Add(leagueId, new MyList<FootballMatch>());
        return session;
    }

    private static AddNewMatchService CreateService(
        FootballMatch match,
        MyList<Player> homePlayers,
        MyList<Player> awayPlayers,
        SessionManager session)
    {
        return new AddNewMatchService(match, homePlayers, awayPlayers, session);
    }

    /// <summary>
    /// Ensures new match and generated result are stored in all in-memory session collections.
    /// </summary>
    [TestMethod]
    public void AddNewMatchInMemory_AddsMatchToSessionCollections_AndGameResults()
    {
        var newMatch = new FootballMatch(2001, 7, 10, 11, new DateTime(2026, 6, 1));
        var generatedResult = new GameResult(0, 2, 1, 8, 0, 3, "Player A", 501);
        var session = CreateSessionWithMatches(newMatch.LeagueID);

        var service = CreateService(newMatch, new MyList<Player>(), new MyList<Player>(), session);

        service.AddNewMatchInMemory(newMatch, generatedResult);

        Assert.IsTrue(session.GameResults.ContainsKey(newMatch.GameID));
        Assert.AreEqual(generatedResult, session.GameResults[newMatch.GameID]);
        Assert.AreEqual(1, session.MatchesCollection.AllMatches.Count);
        Assert.AreEqual(newMatch.GameID, session.MatchesCollection.AllMatches[0].GameID);
        Assert.AreEqual(1, session.MatchesCollection.MatchesByLeague[newMatch.LeagueID].Count);
        Assert.AreEqual(newMatch.GameID, session.MatchesCollection.MatchesByLeague[newMatch.LeagueID][0].GameID);
    }

    /// <summary>
    /// Calls the private generator repeatedly to validate value ranges and optional first scorer data.
    /// </summary>
    [TestMethod]
    public void GenerateGameResults_ValuesStayWithinExpectedRanges()
    {
        var newMatch = new FootballMatch(3001, 9, 21, 22, new DateTime(2026, 7, 1));
        var session = CreateSessionWithMatches(newMatch.LeagueID);

        var homePlayers = new MyList<Player>();
        homePlayers.Add(new Player(1, "Home One", 21, "ATT"));
        var awayPlayers = new MyList<Player>();
        awayPlayers.Add(new Player(2, "Away One", 22, "ATT"));

        var service = CreateService(newMatch, homePlayers, awayPlayers, session);
        var method = typeof(AddNewMatchService).GetMethod("GenerateGameResults", BindingFlags.NonPublic | BindingFlags.Instance);

        Assert.IsNotNull(method);

        for (int i = 0; i < 25; i++)
        {
            var result = (GameResult)method!.Invoke(service, null)!;

            Assert.AreEqual(0, result.GameId);
            Assert.IsTrue(result.HomeTeamScore >= 0 && result.HomeTeamScore <= 6);
            Assert.IsTrue(result.AwayTeamScore >= 0 && result.AwayTeamScore <= 6);
            Assert.IsTrue(result.TotalCorners >= 0 && result.TotalCorners <= 15);
            Assert.IsTrue(result.RedCards >= 0 && result.RedCards <= 1);
            Assert.IsTrue(result.YellowCards >= 0 && result.YellowCards <= 10);

            if (result.FirstScorerId.HasValue)
            {
                Assert.IsTrue(result.FirstScorerId.Value == 1 || result.FirstScorerId.Value == 2);
                Assert.IsFalse(string.IsNullOrWhiteSpace(result.FirstScorerName));
            }
        }
    }

    /// <summary>
    /// Verifies first scorer fields stay null when no players are provided.
    /// </summary>
    [TestMethod]
    public void GenerateGameResults_WithNoPlayers_FirstScorerIsAlwaysNull()
    {
        var newMatch = new FootballMatch(4001, 3, 31, 32, new DateTime(2026, 8, 1));
        var session = CreateSessionWithMatches(newMatch.LeagueID);
        var service = CreateService(newMatch, new MyList<Player>(), new MyList<Player>(), session);

        var method = typeof(AddNewMatchService).GetMethod("GenerateGameResults", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.IsNotNull(method);

        for (int i = 0; i < 20; i++)
        {
            var result = (GameResult)method!.Invoke(service, null)!;
            Assert.IsNull(result.FirstScorerId);
            Assert.IsNull(result.FirstScorerName);
        }
    }
}
