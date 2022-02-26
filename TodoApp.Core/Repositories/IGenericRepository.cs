using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TodoApp.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// returns the class according to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// all his objects return to us
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// according to the expression given, the result returns to us
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// according to the expression given, the result returns to us
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Allows us to add objects according to class T
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Allows us to remove objects according to class T
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// 
        void Remove(T entity);

        /// <summary>
        /// Allows us to update objects according to class T
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);
    }
}
