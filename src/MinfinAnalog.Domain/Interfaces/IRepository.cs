using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinfinAnalog.Domain.Interfaces;
public interface IRepository<TEntity> where TEntity : class
{
    void Add(TEntity entity);

    void Remove(TEntity entity);

    void Update(TEntity entity);

    //Task<TEntity> GetByIdAsync(object id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> GetAllAsync<TProperty>
    (Expression<Func<TEntity, TProperty>> include);

    //Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
}

