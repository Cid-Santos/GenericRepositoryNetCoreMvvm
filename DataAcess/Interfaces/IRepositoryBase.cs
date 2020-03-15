using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAcess.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class, new()
    {
        Task<TEntity> Get(int id);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> Get();
        Task<List<TEntity>> Get<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null);
        Task<int> Insert(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(TEntity entity);
        AsyncTableQuery<TEntity> AsQueryable();

    }
}
