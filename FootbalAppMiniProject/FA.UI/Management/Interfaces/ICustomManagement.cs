using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.UI.Management.Interfaces
{
    internal interface ICustomManagement
    {
        public void GetAll();
        public void Get();
        public void Add();
        public void Update();
        public void Delete();
    }
}
