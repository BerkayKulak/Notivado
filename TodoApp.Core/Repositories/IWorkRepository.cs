using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;

namespace TodoApp.Core.Repositories
{
    public interface IWorkRepository : IGenericRepository<WorkDto>
    {
        /// <summary>
        /// Pulls a personalized todo list
        /// </summary>
        /// <returns></returns>
        Task<List<Work>> GetWorkByUniqueId();

        /// <summary>
        /// Add a personalized todo list
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddWorkByUniqueId(Work work);

        /// <summary>
        /// Update a personalized todo list
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Work UpdateByUniqueId(Work entity);

        /// <summary>
        /// Get By id a personalized todo list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Work> GetByIdUniqueAsync(int id);
    }
}
