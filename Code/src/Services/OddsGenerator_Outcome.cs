using BettingSystem.Data;

namespace BettingSystem.Services;

public sealed class OddsGenerator_Outcome
{
    private readonly DatabaseManager _databaseManager;

    public OddsGenerator_Outcome(string? connectionString = null)
    {
        _databaseManager = new DatabaseManager(connectionString);
    }

    public OutcomeOdds GenerateOutcomeOdds(int gameId, int homeTeamId, int awayTeamId, int leagueId, bool persist = true)
    {
        return _databaseManager.GenerateOutcomeOdds(gameId, homeTeamId, awayTeamId, leagueId, persist);
    }
}