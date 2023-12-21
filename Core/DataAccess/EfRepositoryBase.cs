using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                await context.AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }    
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Remove(entity);
                await context.SaveChangesAsync();
                return entity;
            }    
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> queryable = context.Set<TEntity>();
                queryable = filter == null ? queryable : queryable.Where(filter);
                return await queryable.ToListAsync();
            }   
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> queryable = context.Set<TEntity>();
                return await queryable.SingleOrDefaultAsync(filter);
            }
            
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }    
        }
    }
}
