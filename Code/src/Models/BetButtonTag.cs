namespace BettingSystem.Models
{
    //info to store in the tag of a bet button
    public record BetButtonTag
    (
        int BetTypeId,
        string Selection
    );
}