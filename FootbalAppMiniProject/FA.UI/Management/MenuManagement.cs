using FA.UI.Management.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.UI.Management
{
    public class MenuManagement
    {
        public int SelectMenu()
        {
            Console.WriteLine("---------------------------\n" +
                "MAIN MENU\n" +
                "---------------------------\n" +
                "1.Results of the completed game \n" +
                "2.Listing the current status of a team and its football players\n" +
                "3.Ranking of the points table\n" +
                "4.Ranking of teams with the most goals scored and the most goals conceded\n" +
                "5.Ranking of the player with the most goals scored in the league for each team\n" +
                "6.Admin panel\n" +
                "7.Exit");
            int number = 0;
            do
            {
                try
                {
                    Console.WriteLine("Please enter a number");
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > 7)
                    {
                        throw new Exception("Number is out of range");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (number < 1 || number > 7);

            return number;
        }
        //Admin panel choice
        public int SelectAdminMenu() 
        {
            Console.WriteLine("---------------------------\n" +
                "ADMIN PANEL\n" +
                "---------------------------\n" + 
                    "1.Player Management. \n" +
                    "2.Team Management\n" +
                    "3.Game Management\n" +
                    "4.Exit");
            int number = 0;
            do
            {
                try
                {
                    Console.WriteLine("Please enter a number");
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > 4)
                    {
                        throw new Exception("Number is out of range");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (number < 1 || number > 4);

            return number;
        }

        //Submenu for admin panel
        public int SelectSubMenu(int selectionType)
        {
            int selection = 0;
            string menuName = ((AdminPanelType)selectionType).ToString();
            Console.WriteLine($"\n{menuName} Menu \n\n" +
                $"1. {menuName} Add.\n" +
                $"2. {menuName} Get all.\n" +
                $"3. {menuName} Get.\n" +
                $"4. {menuName} Delete.\n" +
                $"5. {menuName} Update.\n" +
                $"6. Exit.");
            int number = 0;
            do
            {
                try
                {
                    Console.WriteLine("Please enter a number");
                    number = int.Parse(Console.ReadLine());
                    if (number < 1 || number > 6)
                    {
                        throw new Exception("Number is out of range");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (number < 1 || number > 6);

            return number;
        }
    }
}
