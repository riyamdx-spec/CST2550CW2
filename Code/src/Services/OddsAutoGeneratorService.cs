using BettingSystem.Data;
namespace BettingSystem.Services
{
    public class OddsAutoGeneratorService
    {
        private readonly DatabaseManager _dbManager;

        public OddsAutoGeneratorService()
        {
            _dbManager = new DatabaseManager();
        }

        public async Task<OddsGenerationRunResult> RunOnce()
        {
            try
            {
                List<GameInfo> gamesWithoutOdds = await _dbManager.GetMatchesWithoutOdds();
                if (gamesWithoutOdds.Count == 0)
                {
                    return OddsGenerationRunResult.Empty;
                }
                var generatedGameIds = new List<int>(gamesWithoutOdds.Count);
                var generatedOdds = 0;

                foreach (var game in gamesWithoutOdds)
                {
                    var oddsForGame = await _dbManager.GenerateAndSaveAllOddsAsync(game.GameId, game.HomeTeamId, game.AwayTeamId, game.LeagueId, null, null);

                    generatedOdds += oddsForGame.Count;
                    generatedGameIds.Add(game.GameId);
                }

                return new OddsGenerationRunResult(gamesWithoutOdds.Count, generatedOdds, generatedGameIds);
            }catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                return OddsGenerationRunResult.Empty;
            }
        }
    }
}