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
    public class MostLeastGoalManagement
    {
        private readonly IGenericService<Team> _teamService;
        public MostLeastGoalManagement()
        {
            _teamService = new GenericService<Team>();
        }
        public void GetResult()
        {
            var team = _teamService.GetAll();
            var mostScoredGoal = team.OrderByDescending(t => t.ScoredGoalCount).FirstOrDefault();
            var mostConcededGoal = team.OrderByDescending(t => t.ConcededGoalCCount).FirstOrDefault();
            Console.WriteLine($"{"Team   ",-15} {"SG",-5} {"CG",-5}");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"{mostScoredGoal.Name,-15} {mostScoredGoal.ScoredGoalCount,-5} {mostScoredGoal.ConcededGoalCCount,-5}");
            Console.WriteLine($"{mostConcededGoal.Name,-15} {mostConcededGoal.ScoredGoalCount,-5} {mostConcededGoal.ConcededGoalCCount,-5}");
        }
    }
}
