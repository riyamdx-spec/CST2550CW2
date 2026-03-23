namespace BettingSystem.Services;

public sealed class OddsGenerator_Outcome
{
    private readonly OddsGenerator _oddsGenerator;

    public OddsGenerator_Outcome(string? connectionString = null)
    {
        _oddsGenerator = new OddsGenerator(connectionString);
    }

    public OutcomeOdds GenerateOutcomeOdds(int gameId, int homeTeamId, int awayTeamId, int leagueId, bool persist = true)
    {
        return _oddsGenerator.GenerateOutcomeOdds(gameId, homeTeamId, awayTeamId, leagueId, persist);
    }
}