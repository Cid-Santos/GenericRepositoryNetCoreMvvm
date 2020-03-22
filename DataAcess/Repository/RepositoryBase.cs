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
        // Acompanha se Dispose foi chamado.
        private bool disposed = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        public RepositoryBase(SQLiteAsyncConnection connection)
        {
            this.Connection = connection;
        }

        /// <summary>
        /// O padrão para o descarte de um objeto, conhecido como padrão Dispose, impõe ordem no tempo de vida de um objeto.
        /// (GC) Força uma coleta de lixo imediata, este objeto será limpo pelo método Dispose. 
        ///  Portanto, você deve chamar GC.SupressFinalize para retira esse objeto da fila de finalização.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Metodo para fechar a conexão do banco SQLite, utiliza um parametro para 
        /// fechar a conexao (disposing = True)
        /// </summary>
        /// <param name="disposing">Parametro booleano</param>
        protected virtual void Dispose(bool disposing)
        {
            //Verifique se Dispose já foi chamado.
            if (!this.disposed)
            {
                // Se o disposing for igual a true, descarta todos os
                // e recursos não gerenciados.
                if (disposing)
                {
                    // Descarta recursos gerenciados.
                    Connection?.CloseAsync();
                }
                //Se o Dispose foi feito.
                disposed = true;
            }
        }

        /// <summary>
        /// Inicializa uma nova instância da classe AsyncTableQuery <T>.
        /// </summary>
        /// <returns></returns>
        public AsyncTableQuery<TEntity> AsQueryable()
        {
            return Connection.Table<TEntity>();
        }

        /// <summary>
        ///  Metodo para buscar o objeto generico por Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> Get(int id)
        {
            return await Connection.FindAsync<TEntity>(id);
        }

        /// <summary>
        /// Metodo para buscar o objeto generico atraves de uma expressão lambida com predicato
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await Connection.FindAsync<TEntity>(predicate);
        }

        /// <summary>
        /// Metodo para buscar todos os items  de um objeto generico
        /// </summary>
        /// <returns>Retorna uma lista do tipo generico</returns>
        public async Task<List<TEntity>> Get()
        {
            return await Connection.Table<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Metodo para buscar o objeto generico atraves de uma expressão lambida com predicato
        /// e com ordenação dos dados 
        /// </summary>
        /// <typeparam name="TValue">tipo de ordenação</typeparam>
        /// <param name="predicate">valor da consulta</param>
        /// <param name="orderBy">Valor a ser ordenado</param>
        /// <returns>Retorna uma lista do tipo generico ordenada</returns>
        public async Task<List<TEntity>> Get<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null)
        {
            var query = Connection.Table<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Insere dados de um objeto generio em um objeto generico SQLite
        /// </summary>
        /// <param name="entity">Parâmetro de tipo de dados a ser utilizados</param>
        /// <returns>Retorna o estado do objeto</returns>
        public async Task<int> Insert(TEntity entity)
        {
            return await Connection.InsertAsync(entity);
        }

        /// <summary>
        /// Altera os dados de um objeto generio em um objeto generico SQLite
        /// </summary>
        /// <param name="entity">Parâmetro de tipo de dados a ser utilizados</param>
        /// <returns>Retorna o estado do objeto</returns>
        public async Task<int> Update(TEntity entity)
        {
            return await Connection.UpdateAsync(entity);
        }

        /// <summary>
        /// Salva os dados de um objeto generio em um objeto generico SQLite
        /// </summary>
        /// <param name="entity">Parâmetro de tipo de dados a ser utilizados</param>
        /// <returns>Retorna o estado do objeto</returns>
        public async Task<int> Delete(TEntity entity)
        {
            return await Connection.DeleteAsync(entity);
        }
    }
}
