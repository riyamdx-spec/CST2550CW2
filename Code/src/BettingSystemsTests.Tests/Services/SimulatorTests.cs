using System.Reflection;
using BettingSystem.Data_Structures;
using BettingSystem.Models;
using BettingSystem.Services;

namespace BettingSystemsTests.Services;

/// <summary>
/// Covers simulator in-memory update paths and emitted events for admin and user sessions.
/// </summary>
[TestClass]
public class SimulatorTests
{
	/// <summary>
	/// Creates a test user with a selectable role.
	/// </summary>
	private static AppUser CreateUser(string role = "user")
	{
		return new AppUser(
			id: 1,
			fName: "Test",
			lName: "User",
			DOB: new DateTime(2000, 1, 1),
			mail: "test@example.com",
			balance: 100m,
			userRole: role,
			registrationDate: new DateTime(2024, 1, 1),
			status: "active");
	}

	/// <summary>
	/// Builds a non-admin session containing two scheduled matches.
	/// </summary>
	private static SessionManager CreateUserSessionWithMatches()
	{
		var session = new SessionManager(CreateUser(), new Simulator())
		{
			MatchesCollection = new FootballMatchCollection(
				new MyList<FootballMatch>(),
				new MyDictionary<int, MyList<FootballMatch>>()),
			HistoryBetSlips = new MyList<BetHistorySlip>()
		};

		var leagueMatches = new MyList<FootballMatch>();
		var match1 = new FootballMatch(1, 100, 10, 20, DateTime.Today.AddHours(2));
		var match2 = new FootballMatch(2, 100, 30, 40, DateTime.Today.AddHours(3));

		session.MatchesCollection.AllMatches.Add(match1);
		session.MatchesCollection.AllMatches.Add(match2);

		leagueMatches.Add(match1);
		leagueMatches.Add(match2);
		session.MatchesCollection.MatchesByLeague.Add(100, leagueMatches);

		return session;
	}

	/// <summary>
	/// Builds an admin session containing three scheduled matches.
	/// </summary>
	private static SessionManager CreateAdminSessionWithMatches()
	{
		var session = new SessionManager(CreateUser("admin"), new Simulator())
		{
			MatchesCollection = new FootballMatchCollection(
				new MyList<FootballMatch>(),
				new MyDictionary<int, MyList<FootballMatch>>())
		};

		session.MatchesCollection.AllMatches.Add(new FootballMatch(1, 100, 10, 20, DateTime.Today.AddHours(2)));
		session.MatchesCollection.AllMatches.Add(new FootballMatch(2, 100, 30, 40, DateTime.Today.AddHours(3)));
		session.MatchesCollection.AllMatches.Add(new FootballMatch(3, 100, 50, 60, DateTime.Today.AddHours(4)));

		return session;
	}

	/// <summary>
	/// Invokes a private simulator method to test isolated update logic.
	/// </summary>
	private static void InvokePrivateMethod(object target, string methodName, params object[] parameters)
	{
		MethodInfo? method = target.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
		Assert.IsNotNull(method, $"Expected private method '{methodName}' to exist.");
		method.Invoke(target, parameters);
	}

	/// <summary>
	/// Verifies that UpdateAdminSide marks the supplied matches as Started and Completed,
	/// and fires the MatchStatusUpdated event exactly once.
	/// </summary>
	[TestMethod]
	public void UpdateAdminSide_UpdatesStatuses_AndRaisesMatchStatusEvent()
	{
		var simulator = new Simulator();
		var session = CreateAdminSessionWithMatches();
		simulator.SetSession(session);

		int statusUpdatedCalls = 0;
		simulator.MatchStatusUpdated += () => statusUpdatedCalls++;

		var startedIds = new MyList<int>();
		startedIds.Add(1);

		var completedIds = new MyList<int>();
		completedIds.Add(2);

		InvokePrivateMethod(simulator, "UpdateAdminSide", startedIds, completedIds);

		Assert.AreEqual("Started", session.MatchesCollection.AllMatches[0].GameStatus);
		Assert.AreEqual("Completed", session.MatchesCollection.AllMatches[1].GameStatus);
		Assert.AreEqual("Scheduled", session.MatchesCollection.AllMatches[2].GameStatus);
		Assert.AreEqual(1, statusUpdatedCalls);
	}

	/// <summary>
	/// Verifies that UpdateMemory removes started matches from all in-memory collections,
	/// updates bet and slip statuses in history, and raises BetSlipUpdated and HistoryUpdated events.
	/// </summary>
	[TestMethod]
	public void UpdateMemory_RemovesStartedMatches_UpdatesHistory_AndRaisesEvents()
	{
		var simulator = new Simulator();
		var session = CreateUserSessionWithMatches();
		simulator.SetSession(session);

            session.UserSlip.AddBet(new Bet(1, "Home Win", 2.00m, 1, 1, DateTime.Today));
            session.UserSlip.AddBet(new Bet(2, "Away Win", 3.00m, 1, 2, DateTime.Today));

		var historySlip = new BetHistorySlip(500, 1, DateTime.Today, 10m, 2m, 20m, "Pending", false);
            var historyBet = new HistoryBet(900, "Home Win", 2m, 1, "Match Winner", "Pending", "A", "B", DateTime.Today, "League", 1, homeId: 10, awayId: 20);
		historySlip.Bets.Add(historyBet);
		session.HistoryBetSlips.Add(historySlip);

		int slipUpdatedCalls = 0;
		int historyUpdatedCalls = 0;
		simulator.BetSlipUpdated += () => slipUpdatedCalls++;
		simulator.HistoryUpdated += () => historyUpdatedCalls++;

		var startedIds = new MyList<int>();
		startedIds.Add(1);

		var completedIds = new MyList<int>();

		var updatedBets = new MyDictionary<int, string>();
		updatedBets.Add(900, "Won");

		var updatedSlips = new MyDictionary<int, string>();
		updatedSlips.Add(500, "Won");

		InvokePrivateMethod(simulator, "UpdateMemory", startedIds, completedIds, updatedBets, updatedSlips);

		Assert.AreEqual(1, session.MatchesCollection.AllMatches.Count);
		Assert.AreEqual(2, session.MatchesCollection.AllMatches[0].GameID);
		Assert.AreEqual(1, session.MatchesCollection.MatchesByLeague[100].Count);
		Assert.AreEqual(2, session.MatchesCollection.MatchesByLeague[100][0].GameID);

		Assert.AreEqual(1, session.UserSlip.Bets.Count);
		Assert.AreEqual(2, session.UserSlip.Bets.First.Value.GameID);

		Assert.AreEqual("Won", session.HistoryBetSlips[0].Status);
		Assert.AreEqual("Won", session.HistoryBetSlips[0].Bets[0].Result);

		Assert.AreEqual(1, slipUpdatedCalls);
		Assert.AreEqual(1, historyUpdatedCalls);
	}

	/// <summary>
	/// Verifies that UpdateMemory raises no events and leaves all collections unchanged
	/// when both the started and completed ID lists are empty.
	/// </summary>
	[TestMethod]
	public void UpdateMemory_NoChanges_DoesNotRaiseEvents()
	{
		var simulator = new Simulator();
		var session = CreateUserSessionWithMatches();
		simulator.SetSession(session);

		int slipUpdatedCalls = 0;
		int historyUpdatedCalls = 0;
		simulator.BetSlipUpdated += () => slipUpdatedCalls++;
		simulator.HistoryUpdated += () => historyUpdatedCalls++;

		var startedIds = new MyList<int>();
		var completedIds = new MyList<int>();
		var updatedBets = new MyDictionary<int, string>();
		var updatedSlips = new MyDictionary<int, string>();

		InvokePrivateMethod(simulator, "UpdateMemory", startedIds, completedIds, updatedBets, updatedSlips);

		Assert.AreEqual(2, session.MatchesCollection.AllMatches.Count);
		Assert.AreEqual(0, slipUpdatedCalls);
		Assert.AreEqual(0, historyUpdatedCalls);
	}
}
