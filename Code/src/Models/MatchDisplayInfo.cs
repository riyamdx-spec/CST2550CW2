namespace BettingSystem.Models
{
    //info to display for each match
    public record MatchDisplayInfo
    (
        FootballMatch CurrentMatch,
        Team HomeTeam,
        Team AwayTeam,
        string LeagueName
    );
}