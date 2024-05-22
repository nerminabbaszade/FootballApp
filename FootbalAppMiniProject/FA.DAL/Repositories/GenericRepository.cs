using FA.DAL.Data;
using FA.DAL.Model;
using FA.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly FADbContext dbContext;
        private readonly DbSet<T> dbSet;
        
        public GenericRepository()
        {
            dbContext = new FADbContext();
            dbSet=dbContext.Set<T>();
        }
        public T Add(T entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }
        public void Delete(int id)
        {
            var entity= dbSet.Find(id);
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }
        
        public T Get(int id, params string[] includes)
        {
            var entity = dbSet.Where(x => x.Id == id);
            foreach (var include in includes)
            {
                entity = entity.AsNoTracking().Include(include);
            }
            return entity.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public IList<T> GetAll(params string[] includes)
        {
            return dbSet.AsNoTracking().ToList();
        }
        public void Update(int id, T entity)
        {
            entity.Id = id;
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
