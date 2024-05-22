using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.DAL.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateOnly CreateDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
