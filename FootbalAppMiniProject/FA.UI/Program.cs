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

            bool flag = true;
            do
            {
                int selection = menuManagement.SelectMenu();

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
                        bool isContinue = true;
                        do
                        {
                            int choiceAdmin = menuManagement.SelectAdminMenu();
                            
                            switch (choiceAdmin)
                            {
                               
                                case 1:
                                    management = new PlayerManagement();
                                    bool isPlayer = true;
                                    do
                                    {
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
                                                isPlayer = false;
                                                break;
                                        }
                                    }while(isPlayer);
                                    break;
                                case 2:
                                    management = new TeamManagement();
                                    bool isTeam=true;
                                    do
                                    {
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
                                                isTeam = false;
                                                break;
                                        }
                                    }while (isTeam);
                                    break;
                                case 3:
                                    management = new GameManagement();
                                    bool isGame=true;
                                    do
                                    {
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
                                                isGame = false;
                                                break;
                                        }
                                    }while(isGame);
                                    break;
                                case 4:
                                    isContinue = false;
                                    break;
                            }
                        }
                        while (isContinue);
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
