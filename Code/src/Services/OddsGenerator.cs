using System;
using System.Collections.Generic;

namespace BettingSystem.Services
{
    public class OddsGenerator
    {
        private const decimal StandardMargin = 0.93m;
        private const decimal HighVarianceMargin = 0.85m;

        public OddsGenerator(string? connectionString = null)
        {
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

        public OutcomeOdds GenerateOutcomeOdds(TeamRatings homeRatings, TeamRatings awayRatings)
        {
            return CalculateOutcomeOdds(homeRatings, awayRatings);
        }

        // 2. Double Chance Odds
        public IReadOnlyList<GeneratedOdd> GenerateDoubleChanceOdds(int gameId, decimal homeOdds, decimal drawOdds, decimal awayOdds)
        {
            return BuildDoubleChanceOdds(gameId, new OutcomeOdds(homeOdds, drawOdds, awayOdds));
        }

        // 3. Over or Under goals Odds
        public IReadOnlyList<GeneratedOdd> GenerateOverUnderOdds(int gameId, int homeAttack, int homeDefense, int awayAttack, int awayDefense)
        {
            return BuildOverUnderOdds(gameId, new TeamRatings(homeAttack, homeDefense, 60, 5.0m), new TeamRatings(awayAttack, awayDefense, 60, 5.0m));
        }

        // 4. Both Teams to Score Odds
        public IReadOnlyList<GeneratedOdd> GenerateBothTeamsToScoreOdds(int gameId, int homeAttack, int awayAttack)
        {
            return BuildBothTeamsToScoreOdds(gameId, homeAttack, awayAttack);
        }

        // 5. Total Corners
        public IReadOnlyList<GeneratedOdd> GenerateCornerOdds(int gameId, int homeAttack, int awayAttack)
        {
            return BuildCornerOdds(gameId, new TeamRatings(homeAttack, 60, 60, 5.0m), new TeamRatings(awayAttack, 60, 60, 5.0m));
        }

        // 6. Yellow Cards Odds
        public IReadOnlyList<GeneratedOdd> GenerateYellowCardOdds(int gameId, int homeDiscipline, int awayDiscipline)
        {
            return BuildYellowCardOdds(gameId, homeDiscipline, awayDiscipline);
        }

        // 7. Red Cards Odds
        public IReadOnlyList<GeneratedOdd> GenerateRedCardOdds(int gameId, int homeDiscipline, int awayDiscipline)
        {
            return BuildRedCardOdds(gameId, homeDiscipline, awayDiscipline);
        }

        // 8. First Goal Scorer Odds
        public IReadOnlyList<GeneratedOdd> GenerateFirstGoalScorerOdds(int gameId, IReadOnlyCollection<PlayerInfo> players)
        {
            return BuildFirstGoalScorerOdds(gameId, players);
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

        public decimal GenerateCorrectScoreOdds(int gameId, int homeGoals, int awayGoals, TeamRatings homeRatings, TeamRatings awayRatings)
        {
            return GenerateCorrectScoreOdd(gameId, homeGoals, awayGoals, homeRatings, awayRatings).OddValue;
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
                    "ATT" => 2.5,
                    "MID" => 1.2,
                    "DEF" => 0.3,
                    "GK" => 0.05,
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

