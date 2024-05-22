using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.DAL.Model
{
    public class Game:BaseEntity
    {
        public int WeekNumber { get; set; }
        public string StadiumName { get; set; }
        public int HostTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public int HostTeamGoalCount { get; set; }
        public int GuestTeamGoalCount { get; set; }
        public Team HostTeam { get; set; }
        public Team GuestTeam { get; set; }
    }
}
