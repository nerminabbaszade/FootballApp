using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.DAL.Model
{
    public class Team:BaseEntity
    {
        public string Name { get; set; }
        public int WinCount { get; set; }
        public int LostCount { get; set; }
        public int DrawCount { get; set; }
        public int ScoredGoalCount { get; set; }
        public int ConcededGoalCCount { get; set; }
        public int Point { get; set; }
        public ICollection<Player> Players { get; set; }
        [InverseProperty("HostTeam")]
        public ICollection<Game> HostGames { get; set; }
        [InverseProperty("GuestTeam")]
        public ICollection<Game> GuestGames { get; set; }
        public Team()
        {
            Players = new List<Player>();
            HostGames = new List<Game>();
            GuestGames = new List<Game>();
        }
    }
}
