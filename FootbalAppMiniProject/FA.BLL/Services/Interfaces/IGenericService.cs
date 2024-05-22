using FA.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BLL.Services.Interfaces
{
    public interface IGenericService<T> where T : BaseEntity
    {
        public T Add(T entity);
        public T Get(int id,params string[] includes);
        public IList<T> GetAll(params string[] includes);
        public void Update(int id, T entity);
        public void Delete(int id);
    }
}
