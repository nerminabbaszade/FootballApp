using FA.BLL.Services;
using FA.BLL.Services.Interfaces;
using FA.DAL.Model;
using FA.UI.Management.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.UI.Management.AdminPanelManagement
{
    internal class GameManagement : ICustomManagement
    {
        private readonly IGenericService<Game> _service;
        private readonly IGenericService<Team> _teamService;
        private readonly IGenericService<Player> _playerService;
        public GameManagement()
        {
            _service=new GenericService<Game>();
            _teamService=new GenericService<Team>();
            _playerService=new GenericService<Player>();
        }
        public void Add()
        {
            Game game = new();
            Console.WriteLine("Enter Week Number ");
            game.WeekNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stadium Name ");
            game.StadiumName = Console.ReadLine();
            TeamManagement teamManagement = new();
            Console.WriteLine("Team list:");
            teamManagement.GetAll();
            int hostTeamId, guestTeamId;
            do
            {
                Console.WriteLine("Choose Host Team ID :");
                hostTeamId = int.Parse(Console.ReadLine());
                game.HostTeamId = hostTeamId;
                Console.WriteLine("Choose Guest Team ID :");
                guestTeamId = int.Parse(Console.ReadLine());
                game.GuestTeamId = guestTeamId; 
            } while (game.HostTeamId == game.GuestTeamId);

            Team hostTeam = _teamService.Get(hostTeamId);
            Team guestTeam= _teamService.Get(guestTeamId);

            hostTeam.HostGames.Add(game);
            guestTeam.GuestGames.Add(game);

            Console.WriteLine("Enter Host Team Goal Count : ");
            int hostGoalCount = int.Parse(Console.ReadLine());
            game.HostTeamGoalCount = hostGoalCount;
            Console.WriteLine("Enter Guest Team Goal Count : ");
            int guestGoalCount = int.Parse(Console.ReadLine());
            game.GuestTeamGoalCount= guestGoalCount;
            var added=_service.Add(game);

            if (hostGoalCount > guestGoalCount)
            {
                hostTeam.WinCount++;
                guestTeam.LostCount++;
                hostTeam.Point += 3;
            }
            else if (hostGoalCount < guestGoalCount)
            {
                hostTeam.LostCount++;
                guestTeam.WinCount++;
                guestTeam.Point += 3;
            }
            else
            {
                hostTeam.DrawCount++;
                guestTeam.DrawCount++;
                hostTeam.Point++;
                guestTeam.Point++;
            }

            hostTeam.ScoredGoalCount += hostGoalCount;
            hostTeam.ConcededGoalCCount += guestGoalCount;
            guestTeam.ScoredGoalCount += guestGoalCount;
            guestTeam.ConcededGoalCCount += hostGoalCount;

            _teamService.Update(hostTeamId, hostTeam);
            _teamService.Update(guestTeamId, guestTeam);

            PlayerManagement playerManagement = new PlayerManagement();
            Console.WriteLine("Host Team players:");
            playerManagement.GetbyTeamId(hostTeamId);
            Console.WriteLine();
            Console.WriteLine("Guest Team palyers:");
            playerManagement.GetbyTeamId(guestTeamId);
            Console.WriteLine();

            if (hostGoalCount > 0)
            {
                char flag;
                do
                {
                    Console.WriteLine("Enter Player ID who has goal score in host team: ");
                    int playerId = int.Parse(Console.ReadLine());
                    Player player = _playerService.Get(playerId);
                    Console.WriteLine("Enter Goal Score :");
                    int goalScore = int.Parse(Console.ReadLine());
                    player.GoalCount+=goalScore;
                    _playerService.Update(playerId, player);
                    Console.WriteLine("Do you want to add other Player : y/n");
                    flag = char.Parse(Console.ReadLine());
                } while (flag == 'y' );
                _teamService.Update(hostTeamId, hostTeam);
            }
            if (guestGoalCount > 0)
            {
                char flag;
                do
                {
                    Console.WriteLine("Enter Player ID who has goal score in guest team : ");
                    int playerId = int.Parse(Console.ReadLine());
                    Player player = _playerService.Get(playerId);
                    Console.WriteLine("Enter Goal Score :");
                    int goalScore = int.Parse(Console.ReadLine());
                    player.GoalCount+=goalScore;
                    _playerService.Update(playerId, player);
                    Console.WriteLine("Do you want to add other Player : y/n");
                    flag = char.Parse(Console.ReadLine());
                } while (flag == 'y');
            }

            Console.WriteLine("Game is added succesfully!");
        }
        public void Delete()
        {
            Console.WriteLine("Enter Game id: ");
            int id = int.Parse(Console.ReadLine());
            _service.Delete(id);
            Console.WriteLine("Deleted Successfully.");
        }
        public void Get()
        {
            Console.WriteLine("Enter Game id: ");
            int id = int.Parse(Console.ReadLine());
            var item = _service.Get(id);
            Console.WriteLine("ID\tWeek\tStadium\tHost ID\tGuest ID\tHost Goal\tGuest Goal");
            if (item == null) { Console.WriteLine("There is no game with this ID!"); }
            else
            {
                Console.WriteLine($"{item.Id}\t{item.WeekNumber}\t{item.StadiumName}\t{item.HostTeamId}\t{item.GuestTeamId}\t\t{item.HostTeamGoalCount}\t\t{item.GuestTeamGoalCount}");
            }
        }

        public void GetAll()
        {
            var items = _service.GetAll();
            Console.WriteLine("ID\tWeek\tStadium\t\tHost ID\tGuest ID\tHost Goal\tGuest Goal");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id}\t{item.WeekNumber}\t{item.StadiumName}\t\t{item.HostTeamId}\t{item.GuestTeamId}\t\t{item.HostTeamGoalCount}\t\t{item.GuestTeamGoalCount}");
            }
        }

        public void Update()
        {
            GetAll();
            Console.WriteLine("Enter game ID:");
            int id= int.Parse(Console.ReadLine());
            Game game= _service.Get(id);
            Console.WriteLine("Enter game week:");
            game.WeekNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter stadium name:");
            game.StadiumName = Console.ReadLine();
            Console.WriteLine("Choose Host Team ID:");
            game.HostTeamId = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose Guest Team ID:");
            game.GuestTeamId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Host Team Goal Count : ");
            game.HostTeamGoalCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Guest Team Goal Count : ");
            game.GuestTeamGoalCount = int.Parse(Console.ReadLine());

            _service.Update(id, game);
            Console.WriteLine("Game is updated succesfully!");
        }
    }
}
