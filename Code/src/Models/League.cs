namespace BettingSystem.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public string BannerPath { get; set; }

        public League(int id, string LeagueName, string Path, string bannerPath)
        {
            LeagueId = id;
            Name = LeagueName;
            LogoPath = Path;
            BannerPath = bannerPath;
        }
    }
}
