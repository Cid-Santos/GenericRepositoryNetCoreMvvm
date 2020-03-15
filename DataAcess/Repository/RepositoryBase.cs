using DataAcess.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        protected readonly SQLiteAsyncConnection Connection;

        public RepositoryBase(SQLiteAsyncConnection connection)
        {
            this.Connection = connection;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Connection?.CloseAsync();
            }
        }
        public AsyncTableQuery<TEntity> AsQueryable() => Connection.Table<TEntity>();
        public async Task<TEntity> Get(int id) => await Connection.FindAsync<TEntity>(id);
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate) => await Connection.FindAsync<TEntity>(predicate);
        public async Task<List<TEntity>> Get() => await Connection.Table<TEntity>().ToListAsync();
        public async Task<List<TEntity>> Get<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null)
        {
            var query = Connection.Table<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }
        public async Task<int> Insert(TEntity entity) =>  await Connection.InsertAsync(entity);
        public async Task<int> Update(TEntity entity) => await Connection.UpdateAsync(entity);
        public async Task<int> Delete(TEntity entity) => await Connection.DeleteAsync(entity);
    }
}
