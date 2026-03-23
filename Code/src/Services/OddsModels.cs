using System;
using System.Collections.Generic;

namespace BettingSystem.Services;

public sealed record TeamRatings(int Attack, int Defense, int Discipline, decimal AvgCorners);

public sealed record OutcomeOdds(decimal Home, decimal Draw, decimal Away);

public sealed record GeneratedOdd(int GameId, string BetTypeName, string Selection, decimal OddValue);

// Helper to hold player information for first-goal-scorer generation
public sealed record PlayerInfo(int PlayerId, string PlayerName, string Position, int ScoringRating, int TeamId);

// Helper to hold game information
public sealed record GameInfo(
    int GameId,
    int HomeTeamId,
    int AwayTeamId,
    int LeagueId,
    string HomeTeamName,
    string AwayTeamName
);

public sealed record OddsGenerationRunResult(
    int ProcessedGames,
    int GeneratedOdds,
    IReadOnlyList<int> GameIds)
{
    public static OddsGenerationRunResult Empty { get; } = new(0, 0, Array.Empty<int>());
}