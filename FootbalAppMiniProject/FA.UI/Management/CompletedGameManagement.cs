using FA.UI.Management.AdminPanelManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.UI.Management
{
    public class CompletedGameManagement
    {
        public void AddGame()
        {
            GameManagement gameManagement = new GameManagement();
            char flag = 'y';
            do
            {
                gameManagement.Add();
                Console.WriteLine("Are there any other game results?(y/n)");
                flag=char.Parse(Console.ReadLine());
            } while (flag=='y');
        }
    }
}
