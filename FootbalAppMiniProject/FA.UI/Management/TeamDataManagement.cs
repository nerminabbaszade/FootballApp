using FA.BLL.Services.Interfaces;
using FA.BLL.Services;
using FA.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.UI.Management
{
    internal class TeamDataManagement
    {
        private readonly IGenericService<Team> _teamService;
        private readonly IGenericService<Player> _playerService;
        public TeamDataManagement()
        {
            _teamService = new GenericService<Team>();
            _playerService = new GenericService<Player>();
        }
        public void GetTeam()
        {
            Console.WriteLine("Enter Team Name: ");
            string name = Console.ReadLine();
            var item = _teamService.GetAll();
            Team team1 = _teamService.GetAll().FirstOrDefault(team => team.Name.ToLower() == name.ToLower());
            int teamId = team1.Id;
            Team team2 = _teamService.Get(teamId, "Players");
            var sortedPlayers = team2.Players.OrderBy(player => player.FormNumber).ToList();

            if (team1 == null)
            {
                Console.WriteLine("There no team with this name!");
            }
            else
            {
                Console.WriteLine($"{"Team   ",-8} {"G",-3} {"W",-3} {"D",-4} {"L",-5} {"SG",-5} {"CG",-5} {"AVR",-6} {"X",-3}");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"{team1.Name,-8} {team1.WinCount + team1.LostCount + team1.DrawCount,-3} {team1.WinCount,-3} {team1.DrawCount,-4} {team1.LostCount,-5} {team1.ScoredGoalCount,-5} {team1.ConcededGoalCCount,-5} {(team1.ScoredGoalCount - team1.ConcededGoalCCount),-6} {team1.Point,-3}");
                Console.WriteLine();
                Console.WriteLine($"{"Forma No",-10} {"Ad Soyad",-20} {"AQ"}");
                Console.WriteLine("--------------------------");
                foreach (var player in sortedPlayers)
                {
                    Console.WriteLine($"{player.FormNumber,-10} {player.FullName,-20} {player.GoalCount}");
                }
            }
        }
    }
}
