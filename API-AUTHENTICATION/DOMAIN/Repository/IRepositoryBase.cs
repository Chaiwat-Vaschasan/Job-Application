using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> Query();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<List<T>> FindAll();
        Task<T> FindOne(Object id);
        Task Add(T entity);
        Task Add(List<T> entities);
        Task Update(T entity);
        Task Update(List<T> entities);
        Task Delete(T entity);
        Task Delete(List<T> entities);
    }
}
