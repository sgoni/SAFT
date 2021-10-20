using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SharedKernel.SeedWork
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        /// <summary>  
        /// Adds the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        void AddEntity(TEntity entity);

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>  
        /// Gets all.  
        /// </summary>  
        /// <returns></returns> 
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>  
        /// Finds the specified predicate.  
        /// </summary>  
        /// <param name="predicate">The predicate.</param>  
        /// <returns></returns>  
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>  
        /// Gets the specified identifier.  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        /// <returns></returns>  
        Task<TEntity> GetByIdAsync(object id);

        /// <summary>  
        /// Removes the specified entity.  
        /// </summary>  
        /// <param name="entity">The entity.</param>  
        void RemoveEntity(TEntity entity);

        /// <summary>  
        /// Singles the or default.  
        /// </summary>  
        /// <param name="predicate">The predicate.</param>  
        /// <returns></returns> 
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>  
        /// Update the Entity  
        /// </summary>  
        /// <param name="entityToUpdate"></param>  
        void UpdateEntity(TEntity entityToUpdate);

        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams);

        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate);

        Task<QueryResult<TEntity>> GetOrderedPageQueryResultAsync(QueryObjectParams queryObjectParams, IQueryable<TEntity> query);

        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, List<Expression<Func<TEntity, object>>> includes);

        Task<QueryResult<TEntity>> GetPageAsync<TProperty>(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, TProperty>>> includes = null);
    }
}
