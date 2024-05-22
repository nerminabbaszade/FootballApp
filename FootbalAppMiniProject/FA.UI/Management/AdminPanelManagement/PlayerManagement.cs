using FA.BLL.Services;
using FA.BLL.Services.Interfaces;
using FA.DAL.Model;
using FA.UI.Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FA.UI.Management.AdminPanelManagement
{
    internal class PlayerManagement : ICustomManagement
    {
        private readonly IGenericService<Player> _service;
        private readonly IGenericService<Team> _teamService;
        public PlayerManagement()
        {
            _service = new GenericService<Player>();
            _teamService=new GenericService<Team>();
        }
        public void Add()
        {
            Player player = new Player();
            Console.WriteLine("Enter Form Number ");
            player.FormNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Full Name ");
            player.FullName = Console.ReadLine();
            Console.WriteLine("Enter how many goals scored:");
            player.GoalCount = int.Parse(Console.ReadLine());

            TeamManagement teamManagement= new TeamManagement();
            teamManagement.GetAll();

            Console.WriteLine("Choose Team ID : (number)");
            int teamId= int.Parse(Console.ReadLine());
            player.TeamId = teamId;
            var addedPlayer=_service.Add(player);

            Team team=_teamService.Get(teamId);
            team.Players.Add(player);
            _teamService.Update(teamId, team);
            Console.WriteLine("Player is added succesfully!");
        }
        public void Delete()
        {
            Console.WriteLine("Enter Player id: ");
            int id = int.Parse(Console.ReadLine());
            _service.Delete(id);
            Console.WriteLine("Deleted Successfully.");
        }
        public void Get()
        {
            Console.WriteLine("Enter Player id: ");
            int id = int.Parse(Console.ReadLine());
            var item = _service.Get(id);
            if (item == null) { Console.WriteLine("There is no player with this ID!"); }
            else {
                Console.WriteLine($"{"ID",-4} {"Forma No",-10} {"Ad Soyad",-20} {"AQ",-4} {"Team ID"}");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"{item.Id,-4} {item.FormNumber,-10} {item.FullName,-20} {item.GoalCount,-4} {item.TeamId}");
            }
        }
        public void GetbyTeamId(int id)
        {
            var list = _service.GetAll().Where(x=>x.TeamId==id);
            if (list == null) { Console.WriteLine("There is no player with this ID!"); }
            else
            {
                Console.WriteLine($"{"ID",-4} {"Forma No",-10} {"Ad Soyad",-20} {"AQ",-4} {"Team ID"}");
                Console.WriteLine("-------------------------------------------------");
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Id,-4} {item.FormNumber,-10} {item.FullName,-20} {item.GoalCount,-4} {item.TeamId}");
                }
            }
        }
        public void GetAll()
        {
            var items = _service.GetAll();
            Console.WriteLine($"{"ID",-4} {"Forma No",-10} {"Ad Soyad",-20} {"AQ",-4} {"Team ID"}");
            Console.WriteLine("-------------------------------------------------");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id,-4} {item.FormNumber,-10} {item.FullName,-20} {item.GoalCount,-4} {item.TeamId}");
            }
        }
        public void Update()
        {
            GetAll();
            Console.WriteLine("Enter Player id:");
            int id = int.Parse(Console.ReadLine());
            Player player=_service.Get(id);
            Console.WriteLine("Enter Form Number ");
            player.FormNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Full Name ");
            player.FullName = Console.ReadLine();
            Console.WriteLine("Enter how many goals scored:");
            player.GoalCount = int.Parse(Console.ReadLine());

            TeamManagement teamManagement = new TeamManagement();
            teamManagement.GetAll();
            Console.WriteLine("Choose Team ID : (number)");
            player.TeamId = int.Parse(Console.ReadLine());
            _service.Update(id, player);
            Console.WriteLine("Player is updated succesfully!");
        }
    }
}
