using FA.UI.Management;
using FA.UI.Management.AdminPanelManagement;
using FA.UI.Management.Interfaces;

namespace FA.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuManagement menuManagement = new MenuManagement();
            ICustomManagement management;
            CompletedGameManagement completedGameManagement;
            MostLeastGoalManagement mostGoalManagement;
            MostScoredPlayerManagement mostScoredPlayerManagement;
            PointsTableManagement pointsTableManagement;
            TeamDataManagement teamDataManagement;

            int selection = menuManagement.SelectMenu();
            bool flag = true;
            do
            {
                switch (selection)
                {
                    case 1:
                        completedGameManagement = new CompletedGameManagement();
                        completedGameManagement.AddGame();
                        selection = menuManagement.SelectMenu();
                        break;
                    case 2:
                        teamDataManagement = new TeamDataManagement();
                        teamDataManagement.GetTeam();
                        selection = menuManagement.SelectMenu();
                        break;
                    case 3:
                        pointsTableManagement = new PointsTableManagement();
                        pointsTableManagement.GetResult();
                        selection = menuManagement.SelectMenu();
                        break;
                    case 4:
                        mostGoalManagement = new MostLeastGoalManagement();
                        mostGoalManagement.GetResult();
                        selection = menuManagement.SelectMenu();
                        break;
                    case 5:
                        mostScoredPlayerManagement = new MostScoredPlayerManagement();
                        mostScoredPlayerManagement.GetData();
                        selection = menuManagement.SelectMenu();
                        break;
                    case 6:
                        int choiceAdmin = menuManagement.SelectAdminMenu();
                        switch (choiceAdmin)
                        {
                            case 1:
                                management = new PlayerManagement();
                                int choicePlayer = menuManagement.SelectSubMenu(choiceAdmin);
                                switch (choicePlayer)
                                {
                                    case 1:
                                        management.Add();
                                        break;
                                    case 2:
                                        management.GetAll();
                                        break;
                                    case 3:
                                        management.Get();
                                        break;
                                    case 4:
                                        management.Delete();
                                        break;
                                    case 5:
                                        management.Update();
                                        break;
                                    case 6:
                                        break;
                                }
                                break;
                            case 2:
                                management = new TeamManagement();
                                int choiceTeam = menuManagement.SelectSubMenu(choiceAdmin);
                                switch (choiceTeam)
                                {
                                    case 1:
                                        management.Add();
                                        break;
                                    case 2:
                                        management.GetAll();
                                        break;
                                    case 3:
                                        management.Get();
                                        break;
                                    case 4:
                                        management.Delete();
                                        break;
                                    case 5:
                                        management.Update();
                                        break;
                                    case 6:
                                        break;
                                }
                                break;
                            case 3:
                                management = new TeamManagement();
                                int choiceGame = menuManagement.SelectSubMenu(choiceAdmin);
                                switch (choiceGame)
                                {
                                    case 1:
                                        management.Add();
                                        break;
                                    case 2:
                                        management.GetAll();
                                        break;
                                    case 3:
                                        management.Get();
                                        break;
                                    case 4:
                                        management.Delete();
                                        break;
                                    case 5:
                                        management.Update();
                                        break;
                                    case 6:
                                        break;
                                }
                                break;
                            case 4:
                                selection = menuManagement.SelectMenu();
                                break;
                        }
                        break;
                    case 7:
                        flag = false;
                        Console.WriteLine("You exitted!");
                        break;
                }
            } while (flag);
        }
    }
}
