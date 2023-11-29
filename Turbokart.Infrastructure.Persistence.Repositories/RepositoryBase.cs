using Microsoft.EntityFrameworkCore;

using Turbokart.Infrastructure.Persistence.Interfaces;

namespace Turbokart.Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase<T>: IRepository<T> where T : class
    {
        protected DbSet<T> set;
        protected DbContext context;

        protected RepositoryBase(DbContext dbContext)
        {
            this.set = dbContext.Set<T>();
            this.context = dbContext;
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await set.ToListAsync();
        }

        public async virtual Task<T> GetBy(object id)
        {
            return await set.FindAsync(id);
        }

        public async Task Save(T entity)
        {
            await set.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            set.Update(entity);
        }
    }
}