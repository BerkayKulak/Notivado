using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DTOs;

namespace TodoApp.Core.Services
{
    public interface IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {
        /// <summary>
        /// Method of returning the class according to the order
        /// </summary> the method that returns Dto according to the given parameter id
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<TDto>> GetByIdAsync(int id);

        /// <summary>
        /// The method that returns the entire list as TDto
        /// </summary>
        /// <returns></returns>
        Task<Response<IEnumerable<TDto>>> GetAllAsync();

        /// <summary>
        /// the method that throws a query to the database according to the given expression expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// A method that returns a dto object according to the given dto object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Response<TDto>> AddAsync(TDto entity);

        /// <summary>
        /// a method that returns empty content according to the given id parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<NoDataDto>> Remove(int id);

        /// <summary>
        /// a method that returns empty content to us according to the given TDto entity and id
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<NoDataDto>> Update(TDto entity, int id);

        /// <summary>
        /// the method that returns true or false to us according to the expression expression given
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    }
}
