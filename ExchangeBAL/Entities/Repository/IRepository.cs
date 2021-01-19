using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forex.ExchangeBAL.Entities.Repository
{
    public interface IRepository<T> where T: class
    { 
        ForexDbContext DBContext { get;}
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        T Update(T entity);
    }
}
