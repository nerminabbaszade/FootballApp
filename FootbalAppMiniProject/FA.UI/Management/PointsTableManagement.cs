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
    public class PointsTableManagement
    {
        private readonly IGenericService<Team> _teamService;
        public PointsTableManagement()
        {
            _teamService = new GenericService<Team>();
        }
        public void GetResult()
        {
            var team = _teamService.GetAll();
            var sortedTeams = team.OrderByDescending(t => t.WinCount + t.LostCount + t.DrawCount)
                     .ThenByDescending(t => (t.ScoredGoalCount - t.ConcededGoalCCount));

            Console.WriteLine($"{"Team   ",-15} {"G",-3} {"W",-3} {"D",-4} {"L",-5} {"SG",-5} {"CG",-5} {"AVR",-6} {"X",-3}");
            Console.WriteLine("------------------------------------------------------------");
           
            foreach (var item in sortedTeams)
            {
                Console.WriteLine($"{item.Name,-15} {item.WinCount + item.LostCount + item.DrawCount,-3} {item.WinCount,-3} {item.DrawCount,-4} {item.LostCount,-5} {item.ScoredGoalCount,-5} {item.ConcededGoalCCount,-5} {(item.ScoredGoalCount - item.ConcededGoalCCount),-6} {item.Point,-3}");

            }
        }
    }
}
