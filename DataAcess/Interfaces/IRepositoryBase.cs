using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAcess.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class, new()
    {
        /// <summary>
        /// Inicializa uma nova instância da classe AsyncTableQuery <T>.
        /// </summary>
        /// <returns></returns>
        AsyncTableQuery<TEntity> AsQueryable();

        /// <summary>
        ///  Metodo para buscar o objeto generico por Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> Get(int id);
        /// <summary>
        /// Metodo para buscar o objeto generico atraves de uma expressão lambida com predicato
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Metodo para buscar todos os items  de um objeto generico
        /// </summary>
        /// <returns>Retorna uma lista do tipo generico</returns>
        Task<List<TEntity>> Get();
        /// <summary>
        /// Metodo para buscar o objeto generico atraves de uma expressão lambida com predicato
        /// e com ordenação dos dados 
        /// </summary>
        /// <typeparam name="TValue">tipo de ordenação</typeparam>
        /// <param name="predicate">valor da consulta</param>
        /// <param name="orderBy">Valor a ser ordenado</param>
        /// <returns>Retorna uma lista do tipo generico ordenada</returns>
        Task<List<TEntity>> Get<TValue>(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TValue>> orderBy = null);
        /// <summary>
        /// Insere dados de um objeto generio em um objeto generico SQLite
        /// </summary>
        /// <param name="entity">Parâmetro de tipo de dados a ser utilizados</param>
        /// <returns>Retorna o estado do objeto</returns>
        Task<int> Insert(TEntity entity);
        /// <summary>
        /// Altera os dados de um objeto generio em um objeto generico SQLite
        /// </summary>
        /// <param name="entity">Parâmetro de tipo de dados a ser utilizados</param>
        /// <returns>Retorna o estado do objeto</returns>
        Task<int> Update(TEntity entity);
        /// <summary>
        /// Salva os dados de um objeto generio em um objeto generico SQLite
        /// </summary>
        /// <param name="entity">Parâmetro de tipo de dados a ser utilizados</param>
        /// <returns>Retorna o estado do objeto</returns>
        Task<int> Delete(TEntity entity);

    }
}
