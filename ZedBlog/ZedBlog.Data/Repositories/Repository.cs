using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZedBlog.Core.Entities;
using ZedBlog.Data.Context;

namespace ZedBlog.Data.Repositories
{
    public class Repository<T>: IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        { 
            await dbContext.Set<T>().AddAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run( () => dbContext.Set<T>().Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run( () => dbContext.Set<T>().Remove(entity) );
        }

        public async Task<T> GetByGuid(Guid id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbContext.Set<T>();
            
            if(predicate != null)
                query = query.Where(predicate);
            
            if(includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbContext.Set<T>();
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.SingleAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().AllAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await dbContext.Set<T>().CountAsync(predicate);
        }
    }
}
