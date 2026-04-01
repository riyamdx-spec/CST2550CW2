using System;
using System.Collections.Generic;
using BettingSystem.Data;
using Microsoft.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace BettingSystem.Services
{
    public class OddsAutoGeneratorService : IDisposable
    {
        private readonly string _connectionString;
        private readonly DatabaseManager _dbManager;
        private System.Threading.Timer? _timer;
        private int _isRunning;

        public OddsAutoGeneratorService(string connectionString)
        {
            _connectionString = connectionString;
            _dbManager = new DatabaseManager(connectionString);
        }

        public void Start(TimeSpan? interval = null)
        {
            // Checks every 30 seconds for matches without odds
            var cadence = interval ?? TimeSpan.FromSeconds(30);
            _timer ??= new System.Threading.Timer(CheckAndGenerateOdds, null, TimeSpan.Zero, cadence);
        }

        // Stops the service
        public void Stop()
        {
            _timer?.Dispose();
            _timer = null;
        }

        private void CheckAndGenerateOdds(object? state)
        {
            try
            {
                var result = RunOnce();
                if (result.ProcessedGames == 0)
                {
                    Console.WriteLine("No scheduled games without odds were found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Odds generation: {ex.Message}");
            }
        }

        public OddsGenerationRunResult RunOnce()
        {
            if (Interlocked.Exchange(ref _isRunning, 1) == 1)
            {
                return OddsGenerationRunResult.Empty;
            }

            try
            {
                List<GameInfo> gamesWithoutOdds = GetMatchesWithoutOdds();
                var generatedGameIds = new List<int>(gamesWithoutOdds.Count);
                var generatedOdds = 0;

                foreach (var game in gamesWithoutOdds)
                {
                    Console.WriteLine($"Generating odds for {game.HomeTeamName} vs {game.AwayTeamName}...");
                    var oddsForGame = GenerateAllOddsForGame(game);
                    generatedOdds += oddsForGame.Count;
                    generatedGameIds.Add(game.GameId);
                    Console.WriteLine($"Odds generated for {game.GameId}");
                }

                return new OddsGenerationRunResult(gamesWithoutOdds.Count, generatedOdds, generatedGameIds);
            }
            finally
            {
                Interlocked.Exchange(ref _isRunning, 0);
            }
        }

        // Finds games that don't have odds generated yet
        public List<GameInfo> GetMatchesWithoutOdds()
        {
            var games = new List<GameInfo>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(
                       @"SELECT g.game_id,
                                g.home_team_id,
                                g.away_team_id,
                                g.league_id,
                                homeTeam.team_name AS home_team_name,
                                awayTeam.team_name AS away_team_name
                         FROM Game g
                         INNER JOIN Team homeTeam ON homeTeam.team_id = g.home_team_id
                         INNER JOIN Team awayTeam ON awayTeam.team_id = g.away_team_id
                         WHERE g.game_status = 'Scheduled'
                           AND g.game_date > GETDATE()
                           AND NOT EXISTS (
                               SELECT 1
                               FROM Odd o
                               WHERE o.game_id = g.game_id
                           )", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        games.Add(new GameInfo(
                            Convert.ToInt32(reader["game_id"]),
                            Convert.ToInt32(reader["home_team_id"]),
                            Convert.ToInt32(reader["away_team_id"]),
                            Convert.ToInt32(reader["league_id"]),
                            Convert.ToString(reader["home_team_name"]) ?? string.Empty,
                            Convert.ToString(reader["away_team_name"]) ?? string.Empty));
                    }
                }
            }

            return games;
        }

        private IReadOnlyList<GeneratedOdd> GenerateAllOddsForGame(GameInfo game)
        {
            // Generate odds for this match
            return _dbManager.GenerateAllOddsForGame(game.GameId, game.HomeTeamId, game.AwayTeamId, game.LeagueId);
        }

        public void Dispose()
        {
            Stop();
        }
    }
}