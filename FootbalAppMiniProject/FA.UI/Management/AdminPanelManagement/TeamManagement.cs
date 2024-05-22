using FA.BLL.Services.Interfaces;
using FA.BLL.Services;
using FA.UI.Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.DAL.Model;

namespace FA.UI.Management.AdminPanelManagement
{

    internal class TeamManagement : ICustomManagement

    {
        private readonly IGenericService<Team> _service;
        public TeamManagement()
        {
            _service = new GenericService<Team>();
        }
        public void Add()
        {
            Team team = new Team();
            Console.WriteLine("Enter team name:");
            team.Name = Console.ReadLine();
            Console.WriteLine("Enter won game count:");
            team.WinCount=int.Parse(Console.ReadLine());
            int winCount = team.WinCount;
            Console.WriteLine("Enter lost game count:");
            team.LostCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter draw game count:");
            team.DrawCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter scored goal count:");
            int drawCount=team.DrawCount;
            team.ScoredGoalCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter conceded goal count:");
            team.ConcededGoalCCount = int.Parse(Console.ReadLine());
            team.Point += winCount * 3 + drawCount;
            _service.Add(team);
            Console.WriteLine("Team is added succesfully!");
        }

        public void Delete()
        {
            Console.WriteLine("Enter Team id: ");
            int id = int.Parse(Console.ReadLine());
            _service.Delete(id);
            Console.WriteLine("Deleted Successfully.");
        }

        public void Get()
        {
            Console.WriteLine("Enter Team id: ");
            int id = int.Parse(Console.ReadLine());
            var item = _service.Get(id);
            Console.WriteLine($"{"Team   ",-15} {"ID",-4} {"G",-3} {"W",-3} {"D",-4} {"L",-5} {"SG",-5} {"CG",-5} {"AVR",-6} {"X",-3}");
            Console.WriteLine("------------------------------------------------------------");
            if (item == null) { Console.WriteLine("There is no team with this ID!"); }
            else
            {
                Console.WriteLine($"{item.Name,-15} {item.Id,-4} {item.WinCount + item.LostCount + item.DrawCount,-3} {item.WinCount,-3} {item.DrawCount,-4} {item.LostCount,-5} {item.ScoredGoalCount,-5} {item.ConcededGoalCCount,-5} {(item.ScoredGoalCount - item.ConcededGoalCCount),-6} {item.Point,-3}");
            }
        }
        public void GetAll()
        {
            var items = _service.GetAll();
            Console.WriteLine($"{"Team   ",-15} {"ID",-4} {"G",-3} {"W",-3} {"D",-4} {"L",-5} {"SG",-5} {"CG",-5} {"AVR",-6} {"X",-3}");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name,-15} {item.Id,-4} {item.WinCount + item.LostCount + item.DrawCount,-3} {item.WinCount,-3} {item.DrawCount,-4} {item.LostCount,-5} {item.ScoredGoalCount,-5} {item.ConcededGoalCCount,-5} {(item.ScoredGoalCount - item.ConcededGoalCCount),-6} {item.Point,-3}");
            }
        }

        public void Update()
        {
            GetAll();
            Console.WriteLine("Enter team id:");
            int id = int.Parse(Console.ReadLine());
            Team team=_service.Get(id);
            Console.WriteLine("Enter team name:");
            team.Name = Console.ReadLine();
            Console.WriteLine("Enter won game count:");
            team.WinCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter lost game count:");
            team.LostCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter draw game count:");
            team.DrawCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter scored goal count:");
            team.ScoredGoalCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter conceded goal count:");
            team.ConcededGoalCCount = int.Parse(Console.ReadLine());
            _service.Update(id, team);
            Console.WriteLine("Team is updated succesfully!");
        }
    }
}
