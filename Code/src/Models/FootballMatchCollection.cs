namespace BettingSystem.Models
{
    // collection of football matches
    public record FootballMatchCollection
    (
        SortedSet<FootballMatch> AllMatches, // store all matches
        Dictionary<int, SortedSet<FootballMatch>> MatchesByLeague // matches keyed by league id
    );
}