using Naive_bayes.Common.Repositories;
using Naive_bayes.Data_Access.Contexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Naive_bayes.Data_Access.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>, IDisposable where TEntity : class
    {
        protected PenetrationDataContext Context { get; }

        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(PenetrationDataContext context)
        {
            Context = context;
            dbSet = Context.Set<TEntity>();
        }

        protected virtual async Task<TEntity> Add(TEntity entity)
        {
            entity = this.dbSet.Add(entity);
            await this.Context.SaveChangesAsync();
            return entity;
        }

        protected virtual async Task<TEntity> Find(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

        protected virtual async Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            var result = this.dbSet.Where(predicate);
            return result.AsQueryable();
        }

        protected virtual async Task<IQueryable<TEntity>> GetAll()
        {
            return this.dbSet.AsQueryable();
        }

        protected virtual async Task Remove(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
            await this.Context.SaveChangesAsync();
        }

        protected virtual async Task<int> SaveChanges()
        {
            return await this.Context.SaveChangesAsync();
        }

        protected virtual async Task<TEntity> Update(TEntity entity)
        {
            var dbEntityEntry = this.Context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
            await this.Context.SaveChangesAsync();
            return dbEntityEntry.Entity;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
