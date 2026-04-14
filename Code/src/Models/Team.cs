namespace BettingSystem.Models
{
    public class Team // represent a football team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string LogoPath { get; set; }

        public Team(int id, string name, string logo)
        {
            TeamId = id;    
            TeamName = name;
            LogoPath = logo;
        }
    }
}
