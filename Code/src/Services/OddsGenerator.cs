using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace BettingSystem.Services
{
    public class OddsGenerator
    {
        private const decimal StandardMargin = 0.93m;
        private const decimal HighVarianceMargin = 0.85m;
        private readonly string _connectionString;

        public OddsGenerator(string? connectionString = null)
        {
            _connectionString =
                connectionString
                ?? Environment.GetEnvironmentVariable("ODDS_CONNECTION_STRING")
                ?? string.Empty;
        }

        // Gets team ratings from the database
        public TeamRatings GetTeamRatings(int teamId, int leagueId)
        {
            using var conn = CreateOpenConnection();
            using var cmd = new SqlCommand(
                @"SELECT attack_rating, defense_rating, discipline_rating, avg_corners_per_game
                  FROM TeamRating
                  WHERE team_id = @teamId AND league_id = @leagueId",
                conn);

            cmd.Parameters.AddWithValue("@teamId", teamId);
            cmd.Parameters.AddWithValue("@leagueId", leagueId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new TeamRatings(
                    Convert.ToInt32(reader["attack_rating"]),
                    Convert.ToInt32(reader["defense_rating"]),
                    Convert.ToInt32(reader["discipline_rating"]),
                    Convert.ToDecimal(reader["avg_corners_per_game"]));
            }

            // Default ratings if team not found
            return new TeamRatings(60, 60, 60, 5.0m);
        }

        // 1. Match Outcome (Home/Draw/Away) Odds
        public OutcomeOdds CalculateOutcomeOdds(TeamRatings homeRatings, TeamRatings awayRatings)
        {
            var homeStrength = homeRatings.Attack + homeRatings.Defense + 15;
            var awayStrength = awayRatings.Attack + awayRatings.Defense;

            var totalStrength = Math.Max(1d, homeStrength + awayStrength);
            var homeProbability = (homeStrength / totalStrength) * 0.70;
            var awayProbability = (awayStrength / totalStrength) * 0.70;
            var drawProbability = 0.27;

            var totalProbability = homeProbability + awayProbability + drawProbability;
            homeProbability /= totalProbability;
            awayProbability /= totalProbability;
            drawProbability /= totalProbability;

            return new OutcomeOdds(
                ToOdds(homeProbability, StandardMargin, 1.20m, 15.00m),
                ToOdds(drawProbability, StandardMargin, 2.00m, 15.00m),
                ToOdds(awayProbability, StandardMargin, 1.20m, 15.00m));
        }

        public OutcomeOdds GenerateOutcomeOdds(int gameId, int homeTeamId, int awayTeamId, int leagueId, bool persist = true)
        {
            var outcome = CalculateOutcomeOdds(GetTeamRatings(homeTeamId, leagueId), GetTeamRatings(awayTeamId, leagueId));

            if (persist)
            {
                SaveOddsToDatabase(BuildOutcomeOdds(gameId, outcome));
            }

            return outcome;
        }

        // 2. Double Chance Odds
        public IReadOnlyList<GeneratedOdd> GenerateDoubleChanceOdds(int gameId, decimal homeOdds, decimal drawOdds, decimal awayOdds, bool persist = true)
        {
            var odds = BuildDoubleChanceOdds(gameId, new OutcomeOdds(homeOdds, drawOdds, awayOdds));

            if (persist)
            {
                SaveOddsToDatabase(odds);
            }

            return odds;
        }

        // 3. Over or Under goals Odds
        public IReadOnlyList<GeneratedOdd> GenerateOverUnderOdds(int gameId, int homeAttack, int homeDefense, int awayAttack, int awayDefense, bool persist = true)
        {
            var odds = BuildOverUnderOdds(gameId, new TeamRatings(homeAttack, homeDefense, 60, 5.0m), new TeamRatings(awayAttack, awayDefense, 60, 5.0m));

            if (persist)
            {
                SaveOddsToDatabase(odds);
            }

            return odds;
        }

        // 4. Both Teams to Score Odds
        public IReadOnlyList<GeneratedOdd> GenerateBothTeamsToScoreOdds(int gameId, int homeAttack, int awayAttack, bool persist = true)
        {
            var odds = BuildBothTeamsToScoreOdds(gameId, homeAttack, awayAttack);

            if (persist)
            {
                SaveOddsToDatabase(odds);
            }

            return odds;
        }

        // 5. Total Corners
        public IReadOnlyList<GeneratedOdd> GenerateCornerOdds(int gameId, int homeAttack, int awayAttack, bool persist = true)
        {
            var odds = BuildCornerOdds(gameId, new TeamRatings(homeAttack, 60, 60, 5.0m), new TeamRatings(awayAttack, 60, 60, 5.0m));

            if (persist)
            {
                SaveOddsToDatabase(odds);
            }

            return odds;
        }

        // 6. Yellow Cards Odds
        public IReadOnlyList<GeneratedOdd> GenerateYellowCardOdds(int gameId, int homeDiscipline, int awayDiscipline, bool persist = true)
        {
            var odds = BuildYellowCardOdds(gameId, homeDiscipline, awayDiscipline);

            if (persist)
            {
                SaveOddsToDatabase(odds);
            }

            return odds;
        }

        // 7. Red Cards Odds
        public IReadOnlyList<GeneratedOdd> GenerateRedCardOdds(int gameId, int homeDiscipline, int awayDiscipline, bool persist = true)
        {
            var odds = BuildRedCardOdds(gameId, homeDiscipline, awayDiscipline);

            if (persist)
            {
                SaveOddsToDatabase(odds);
            }

            return odds;
        }

        // 8. First Goal Scorer Odds
        public IReadOnlyList<GeneratedOdd> GenerateFirstGoalScorerOdds(int gameId, int homeTeamId, int awayTeamId, bool persist = true)
        {
            var players = GetPlayersForTeams(homeTeamId, awayTeamId);
            var odds = BuildFirstGoalScorerOdds(gameId, players);

            if (persist && odds.Count > 0)
            {
                SaveOddsToDatabase(odds);
            }

            return odds;
        }

        // 9. Correct Score Odds
        public GeneratedOdd GenerateCorrectScoreOdd(int gameId, int homeGoals, int awayGoals, TeamRatings homeRatings, TeamRatings awayRatings)
        {
            var homeExpected = ((double)homeRatings.Attack - awayRatings.Defense) / 40.0 + 1.5;
            var awayExpected = ((double)awayRatings.Attack - homeRatings.Defense) / 40.0 + 1.2;

            var combinedProbability = PoissonProbability(homeGoals, homeExpected) * PoissonProbability(awayGoals, awayExpected);
            var selection = $"{homeGoals}-{awayGoals}";

            return new GeneratedOdd(gameId, "Correct Score", selection, ToOdds(combinedProbability, HighVarianceMargin, 6.0m, 100.0m));
        }

        public decimal GenerateCorrectScoreOdds(int gameId, int homeGoals, int awayGoals, int homeTeamId, int awayTeamId, int leagueId, bool persist = true)
        {
            var odd = GenerateCorrectScoreOdd(gameId, homeGoals, awayGoals, GetTeamRatings(homeTeamId, leagueId), GetTeamRatings(awayTeamId, leagueId));

            if (persist)
            {
                SaveOddsToDatabase(new[] { odd });
            }

            return odd.OddValue;
        }

        public IReadOnlyList<GeneratedOdd> BuildAllOddsForGame(int gameId, TeamRatings homeRatings, TeamRatings awayRatings, IReadOnlyCollection<PlayerInfo>? players = null)
        {
            var generatedOdds = new List<GeneratedOdd>();
            var outcome = CalculateOutcomeOdds(homeRatings, awayRatings);

            generatedOdds.AddRange(BuildOutcomeOdds(gameId, outcome));
            generatedOdds.AddRange(BuildDoubleChanceOdds(gameId, outcome));
            generatedOdds.AddRange(BuildOverUnderOdds(gameId, homeRatings, awayRatings));
            generatedOdds.AddRange(BuildBothTeamsToScoreOdds(gameId, homeRatings.Attack, awayRatings.Attack));
            generatedOdds.AddRange(BuildCornerOdds(gameId, homeRatings, awayRatings));
            generatedOdds.AddRange(BuildYellowCardOdds(gameId, homeRatings.Discipline, awayRatings.Discipline));
            generatedOdds.AddRange(BuildRedCardOdds(gameId, homeRatings.Discipline, awayRatings.Discipline));

            if (players is { Count: > 0 })
            {
                generatedOdds.AddRange(BuildFirstGoalScorerOdds(gameId, players));
            }

            return generatedOdds;
        }

        public IReadOnlyList<GeneratedOdd> GenerateAllOddsForGame(int gameId, int homeTeamId, int awayTeamId, int leagueId, bool persist = true)
        {
            var homeRatings = GetTeamRatings(homeTeamId, leagueId);
            var awayRatings = GetTeamRatings(awayTeamId, leagueId);
            var players = GetPlayersForTeams(homeTeamId, awayTeamId);

            // Main Method to generate all odds for a game
            Console.WriteLine($"Generating odds for game {gameId} (Home: {homeTeamId} vs Away: {awayTeamId})...");

            var generatedOdds = BuildAllOddsForGame(gameId, homeRatings, awayRatings, players);

            if (persist)
            {
                SaveOddsToDatabase(generatedOdds);
            }

            Console.WriteLine($"All odds generated for game {gameId} ({generatedOdds.Count} odds created).");
            return generatedOdds;
        }

        public OutcomeOdds GetOutcomeOdds(int gameId)
        {
            using var conn = CreateOpenConnection();
            using var cmd = new SqlCommand(
                @"SELECT o.selection, o.odd_value
                  FROM Odd o
                  INNER JOIN BetType bt ON o.bet_type_id = bt.bet_type_id
                  WHERE o.game_id = @gameId AND bt.bet_type_name = 'Match Outcome'",
                conn);

            cmd.Parameters.AddWithValue("@gameId", gameId);

            decimal home = 0;
            decimal draw = 0;
            decimal away = 0;

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var selection = Convert.ToString(reader["selection"]);
                var value = Convert.ToDecimal(reader["odd_value"]);

                switch (selection)
                {
                    case "Home Win":
                        home = value;
                        break;
                    case "Draw":
                        draw = value;
                        break;
                    case "Away Win":
                        away = value;
                        break;
                }
            }

            return new OutcomeOdds(home, draw, away);
        }

        // Helper to hold player information for first-goal-scorer generation
        public List<PlayerInfo> GetPlayersForTeams(int homeTeamId, int awayTeamId)
        {
            using var conn = CreateOpenConnection();
            using var cmd = new SqlCommand(
                @"SELECT p.player_id, p.player_name, p.player_position, pr.scoring_rating, p.team_id
                  FROM Player p
                  INNER JOIN PlayerRating pr ON p.player_id = pr.player_id
                  WHERE (p.team_id = @homeTeam OR p.team_id = @awayTeam)
                    AND pr.is_active = 1",
                conn);

            cmd.Parameters.AddWithValue("@homeTeam", homeTeamId);
            cmd.Parameters.AddWithValue("@awayTeam", awayTeamId);

            var players = new List<PlayerInfo>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var rawPosition = Convert.ToString(reader["player_position"]);
                var normalizedPosition = string.IsNullOrWhiteSpace(rawPosition)
                    ? "ATT"
                    : rawPosition.Trim().ToUpperInvariant() switch
                    {
                        "ATT" => "ATT",
                        "MID" => "MID",
                        "DEF" => "DEF",
                        "GK" => "GK",
                        "FW" => "ATT",
                        "MF" => "MID",
                        "DF" => "DEF",
                        _ => "ATT"
                    };

                players.Add(new PlayerInfo(
                    Convert.ToInt32(reader["player_id"]),
                    Convert.ToString(reader["player_name"]) ?? string.Empty,
                    Convert.ToString(reader["player_position"]) ?? "FW",
                    Convert.ToInt32(reader["scoring_rating"]),
                    Convert.ToInt32(reader["team_id"])));
            }

            return players;
        }

        private IReadOnlyList<GeneratedOdd> BuildOutcomeOdds(int gameId, OutcomeOdds outcomeOdds) =>
            new List<GeneratedOdd>
            {
                new(gameId, "Match Outcome", "Home Win", outcomeOdds.Home),
                new(gameId, "Match Outcome", "Draw", outcomeOdds.Draw),
                new(gameId, "Match Outcome", "Away Win", outcomeOdds.Away)
            };

        private IReadOnlyList<GeneratedOdd> BuildDoubleChanceOdds(int gameId, OutcomeOdds outcomeOdds)
        {
            var homeProbability = InvertOdds(outcomeOdds.Home);
            var drawProbability = InvertOdds(outcomeOdds.Draw);
            var awayProbability = InvertOdds(outcomeOdds.Away);

            return new List<GeneratedOdd>
            {
                new(gameId, "Double Chance", "1X", ToOdds(homeProbability + drawProbability, StandardMargin, 1.05m, 8.0m)),
                new(gameId, "Double Chance", "12", ToOdds(homeProbability + awayProbability, StandardMargin, 1.05m, 8.0m)),
                new(gameId, "Double Chance", "X2", ToOdds(drawProbability + awayProbability, StandardMargin, 1.05m, 8.0m))
            };
        }

        private IReadOnlyList<GeneratedOdd> BuildOverUnderOdds(int gameId, TeamRatings homeRatings, TeamRatings awayRatings)
        {
            var expectedGoals = ((homeRatings.Attack + awayRatings.Attack) - (homeRatings.Defense + awayRatings.Defense)) / 40.0 + 2.5;

            return new List<GeneratedOdd>
            {
                CreateBinaryMarketOdd(gameId, "Over/Under", "Over 2.5", expectedGoals > 2.5 ? 0.55 : 0.45),
                CreateBinaryMarketOdd(gameId, "Over/Under", "Under 2.5", expectedGoals > 2.5 ? 0.45 : 0.55),
                CreateBinaryMarketOdd(gameId, "Over/Under", "Over 1.5", expectedGoals > 1.5 ? 0.65 : 0.35),
                CreateBinaryMarketOdd(gameId, "Over/Under", "Under 1.5", expectedGoals > 1.5 ? 0.35 : 0.65),
                CreateBinaryMarketOdd(gameId, "Over/Under", "Over 3.5", expectedGoals > 3.5 ? 0.40 : 0.60),
                CreateBinaryMarketOdd(gameId, "Over/Under", "Under 3.5", expectedGoals > 3.5 ? 0.60 : 0.40)
            };
        }

        private IReadOnlyList<GeneratedOdd> BuildBothTeamsToScoreOdds(int gameId, int homeAttack, int awayAttack)
        {
            var probability = Math.Min(0.65, 0.35 + ((homeAttack + awayAttack) / 400.0));

            return new List<GeneratedOdd>
            {
                CreateBinaryMarketOdd(gameId, "Both Teams to Score", "Yes", probability),
                CreateBinaryMarketOdd(gameId, "Both Teams to Score", "No", 1 - probability)
            };
        }

        private IReadOnlyList<GeneratedOdd> BuildCornerOdds(int gameId, TeamRatings homeRatings, TeamRatings awayRatings)
        {
            var expectedCorners = (double)(homeRatings.AvgCorners + awayRatings.AvgCorners);

            return new List<GeneratedOdd>
            {
                CreateBinaryMarketOdd(gameId, "Total Corners", "Over 8.5", expectedCorners > 8.5 ? 0.58 : 0.42),
                CreateBinaryMarketOdd(gameId, "Total Corners", "Under 8.5", expectedCorners > 8.5 ? 0.42 : 0.58),
                CreateBinaryMarketOdd(gameId, "Total Corners", "Over 9.5", expectedCorners > 9.5 ? 0.55 : 0.45),
                CreateBinaryMarketOdd(gameId, "Total Corners", "Under 9.5", expectedCorners > 9.5 ? 0.45 : 0.55),
                CreateBinaryMarketOdd(gameId, "Total Corners", "Over 10.5", expectedCorners > 10.5 ? 0.52 : 0.48),
                CreateBinaryMarketOdd(gameId, "Total Corners", "Under 10.5", expectedCorners > 10.5 ? 0.48 : 0.52)
            };
        }

        private IReadOnlyList<GeneratedOdd> BuildYellowCardOdds(int gameId, int homeDiscipline, int awayDiscipline)
        {
            var expectedYellows = ((200 - homeDiscipline - awayDiscipline) / 25.0) + 3;

            return new List<GeneratedOdd>
            {
                CreateBinaryMarketOdd(gameId, "Yellow Cards", "Over 3.5", expectedYellows > 3.5 ? 0.58 : 0.42),
                CreateBinaryMarketOdd(gameId, "Yellow Cards", "Under 3.5", expectedYellows > 3.5 ? 0.42 : 0.58),
                CreateBinaryMarketOdd(gameId, "Yellow Cards", "Over 4.5", expectedYellows > 4.5 ? 0.54 : 0.46),
                CreateBinaryMarketOdd(gameId, "Yellow Cards", "Under 4.5", expectedYellows > 4.5 ? 0.46 : 0.54)
            };
        }

        private IReadOnlyList<GeneratedOdd> BuildRedCardOdds(int gameId, int homeDiscipline, int awayDiscipline)
        {
            var redCardProbability = Math.Min(0.35, 0.15 + ((200 - homeDiscipline - awayDiscipline) / 1000.0));
            var twoOrMoreCardsProbability = Math.Clamp(redCardProbability * 0.35, 0.03, 0.20);

            return new List<GeneratedOdd>
            {
                CreateBinaryMarketOdd(gameId, "Red Cards", "Over 0.5", redCardProbability),
                CreateBinaryMarketOdd(gameId, "Red Cards", "Under 0.5", 1 - redCardProbability),
                CreateBinaryMarketOdd(gameId, "Red Cards", "Over 1.5", twoOrMoreCardsProbability),
                CreateBinaryMarketOdd(gameId, "Red Cards", "Under 1.5", 1 - twoOrMoreCardsProbability)
            };
        }

        private IReadOnlyList<GeneratedOdd> BuildFirstGoalScorerOdds(int gameId, IEnumerable<PlayerInfo> players)
        {
            var generatedOdds = new List<GeneratedOdd>();

            foreach (var player in players)
            {
                var baseProbability = player.ScoringRating / 2000.0;
                // Adjusts by positions
                baseProbability *= player.Position switch
                {
                    "FW" => 2.5,
                    "MF" => 1.2,
                    "DF" => 0.3,
                    // Goalkeepers
                    _ => 0.05
                };

                generatedOdds.Add(new GeneratedOdd(
                    gameId,
                    "First Goal Scorer",
                    player.PlayerName,
                    ToOdds(baseProbability, HighVarianceMargin, 3.0m, 50.0m)));
            }

            return generatedOdds;
        }

        private void SaveOddsToDatabase(IEnumerable<GeneratedOdd> odds)
        {
            using var conn = CreateOpenConnection();
            var betTypeCache = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var odd in odds)
            {
                SaveOddToDatabase(conn, betTypeCache, odd);
            }
        }

        private void SaveOddToDatabase(SqlConnection conn, IDictionary<string, int> betTypeCache, GeneratedOdd odd)
        {
            var betTypeId = GetBetTypeId(conn, betTypeCache, odd.BetTypeName);
            using var cmd = new SqlCommand(
                @"BEGIN TRY
                      INSERT INTO Odd (game_id, bet_type_id, selection, odd_value, creation_date, is_active)
                      VALUES (@gameId, @betTypeId, @selection, @oddValue, @creationDate, @isActive)
                  END TRY
                  BEGIN CATCH
                      IF ERROR_NUMBER() IN (2601, 2627)
                      BEGIN
                          UPDATE Odd
                          SET odd_value = @oddValue,
                              creation_date = @creationDate,
                              is_active = @isActive
                          WHERE game_id = @gameId
                            AND bet_type_id = @betTypeId
                            AND selection = @selection;
                      END
                      ELSE
                      BEGIN
                          THROW;
                      END
                  END CATCH",
                conn);

            cmd.Parameters.AddWithValue("@gameId", odd.GameId);
            cmd.Parameters.AddWithValue("@betTypeId", betTypeId);
            cmd.Parameters.AddWithValue("@selection", odd.Selection);
            cmd.Parameters.AddWithValue("@oddValue", odd.OddValue);
            cmd.Parameters.AddWithValue("@creationDate", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@isActive", true);
            cmd.ExecuteNonQuery();
        }

        private int GetBetTypeId(SqlConnection conn, IDictionary<string, int> betTypeCache, string betTypeName)
        {
            if (betTypeCache.TryGetValue(betTypeName, out var cachedId))
            {
                return cachedId;
            }

            using var cmd = new SqlCommand(
                "SELECT bet_type_id FROM BetType WHERE bet_type_name = @name",
                conn);
            cmd.Parameters.AddWithValue("@name", betTypeName);

            var result = cmd.ExecuteScalar();
            if (result is null)
            {
                throw new InvalidOperationException($"Bet type '{betTypeName}' not found in database.");
            }

            var betTypeId = Convert.ToInt32(result);
            betTypeCache[betTypeName] = betTypeId;
            return betTypeId;
        }

        private SqlConnection CreateOpenConnection()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new InvalidOperationException(
                    "Connection string is not configured. Pass one to OddsGenerator or set ODDS_CONNECTION_STRING.");
            }

            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        private static GeneratedOdd CreateBinaryMarketOdd(int gameId, string betTypeName, string selection, double probability) =>
            new(gameId, betTypeName, selection, ToOdds(probability, StandardMargin, 1.20m, 50.0m));

        private static double InvertOdds(decimal odds) => odds <= 0 ? 0 : 1d / (double)odds;

        private static decimal ToOdds(double probability, decimal margin, decimal minOdds, decimal maxOdds)
        {
            var safeProbability = Math.Clamp(probability, 0.01, 0.99);
            var odds = Math.Round((decimal)(1d / safeProbability) * margin, 2, MidpointRounding.AwayFromZero);
            return Math.Clamp(odds, minOdds, maxOdds);
        }

        private static double PoissonProbability(int goals, double lambda)
        {
            return Math.Pow(lambda, goals) * Math.Exp(-lambda) / Factorial(goals);
        }

        private static double Factorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            double result = 1;
            for (var i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}

