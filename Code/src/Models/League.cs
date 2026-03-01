using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }

        public League(int id, string LeagueName, string Path)
        {
            LeagueId = id;
            Name = LeagueName;
            LogoPath = Path;
        }
    }
}
