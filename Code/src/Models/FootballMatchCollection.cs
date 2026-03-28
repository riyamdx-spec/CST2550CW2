using BettingSystem.Data_Structures;

namespace BettingSystem.Models
{
    // collection of football matches
    public record FootballMatchCollection
    (
        MyList<FootballMatch> AllMatches, // store all matches
        MyDictionary<int, MyList<FootballMatch>> MatchesByLeague // matches keyed by league id
    );
}