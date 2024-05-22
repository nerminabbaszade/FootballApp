using FA.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        public T Add(T entity);
        public void Delete (int  id);
        public void Update(int id, T entity);
        public T Get(int id, params string[] includes);
        public IList<T> GetAll(params string[] includes);
    }
}
