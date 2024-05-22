using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.DAL.Model
{
    public class Player:BaseEntity
    {
        public int TeamId { get; set; }
        public int FormNumber { get; set; }
        public string FullName { get; set; }
        public Team Team { get; set; }
        public int GoalCount { get; set; }
    }
}
