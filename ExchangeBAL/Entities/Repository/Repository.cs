using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.Entities.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ForexDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ForexDbContext context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public ForexDbContext DBContext 
        { 
            get { return _context; } 
        }

        public T Add(T entity) 
    {
            var dbEntity = _context.Entry<T>(entity);
            dbEntity.State = EntityState.Added;
            return entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public T Update(T entity)
        {
            var dbEntity = _context.Entry<T>(entity);
            dbEntity.State = EntityState.Modified;
            return entity;
        }
    }
}
