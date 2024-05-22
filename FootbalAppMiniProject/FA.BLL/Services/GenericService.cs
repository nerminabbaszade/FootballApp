using FA.BLL.Services.Interfaces;
using FA.DAL.Model;
using FA.DAL.Repositories.Interfaces;
using FA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.BLL.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        public GenericService()
        {
            _repository = new GenericRepository<T>();
        }
        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public T Get(int id, params string[] includes)
        {
            return _repository.Get(id,includes);
        }

        public IList<T> GetAll(params string[] includes)
        {
            return _repository.GetAll(includes);
        }

        public void Update(int id, T entity)
        {
            _repository.Update(id, entity);
        }
    }
}
