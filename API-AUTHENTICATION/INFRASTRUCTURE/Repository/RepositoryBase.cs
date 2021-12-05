using DOMAIN.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbContext context;

        public RepositoryBase(DbContext context) 
        {
            this.context = context;
        }

        public async Task Add(T entity)
        {
            await context.AddAsync(entity);
        }

        public async Task Add(List<T> entities)
        {
            foreach (var entity in entities) 
            {
                await context.AddAsync(entity);
            }
        }

        public Task Delete(T entity)
        {
            context.Remove(entity);

            return Task.CompletedTask;
        }

        public Task Delete(List<T> entities)
        {
            foreach (var entity in entities) 
            {
                context.Remove(entity);
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
           return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> FindAll()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> FindOne(object id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> Query()
        {
            return context.Set<T>().AsQueryable();
        }

        public Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task Update(List<T> entities)
        {
            foreach (var entity in entities) 
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            return Task.CompletedTask;
        }
    }
}
