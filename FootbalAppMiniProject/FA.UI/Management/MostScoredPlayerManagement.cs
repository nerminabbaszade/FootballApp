using FA.BLL.Services.Interfaces;
using FA.BLL.Services;
using FA.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FA.UI.Management
{
    public class MostScoredPlayerManagement
    {
        private readonly IGenericService<Team> _teamService;
        public MostScoredPlayerManagement()
        {
            _teamService = new GenericService<Team>();
        }
        public void GetData()
        {
            Console.WriteLine($"{"Team",-8} \t{"Form No",-8} {"Full Name",-20} {"Goal count"}");
            Console.WriteLine("-----------------------------------------------------------------");
            var teams = _teamService.GetAll();
            foreach (var team in teams) { 
                int id = team.Id;
                var teamWithPlayerList = _teamService.Get(id, "Players");
                var sortedPlayers = teamWithPlayerList.Players.OrderByDescending(player => player.GoalCount).FirstOrDefault();
                Console.WriteLine($"{team.Name,-8}\t{sortedPlayers.FormNumber,-10}{sortedPlayers.FullName,-20}{sortedPlayers.GoalCount}");
            }
        }
    }
}
