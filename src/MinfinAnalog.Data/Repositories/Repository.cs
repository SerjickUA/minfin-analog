using Microsoft.EntityFrameworkCore;
using MinfinAnalog.Domain.Interfaces;
using System.Linq.Expressions;

namespace MinfinAnalog.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>() ?? throw new ArgumentNullException(nameof(context));

        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        //public async Task<TEntity> GetByIdAsync(object id)
        //{
        //    return await _dbSet.FindAsync(id).ConfigureAwait(false);
        //}

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>>
        GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include)
        {
            IQueryable<TEntity> query = _dbSet.Include(include);

            return await query.ToListAsync().ConfigureAwait(false);
        }

        //public async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await _dbSet.SingleOrDefaultAsync(predicate).ConfigureAwait(false);
        //}

    }
}
