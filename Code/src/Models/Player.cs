namespace BettingSystem.Models
{
    public class Player // represent a football player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Position { get; set; }

        public Player(int id, string name, int teamId, string position)
        {
            PlayerId = id;
            Name = name;
            TeamId = teamId;
            Position = position;
        }
    }
}