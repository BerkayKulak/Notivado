using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;

namespace TodoApp.Core.Services
{
    public interface IWorkService: IServiceGeneric<Work,WorkDto>
    {
        /// <summary>
        /// Returns the todo list to us with a user-specific Id
        /// </summary>
        /// <returns></returns>
        Task<Response<List<WorkAddDto>>> GetWorksWithUniqueId();

        /// <summary>
        /// Allows us to add a user with a custom Id
        /// </summary>
        /// <param name="workAddDto"></param>
        /// <returns></returns>
        Task<Response<Work>> AddWorksWithUniqueId(WorkAddDto workAddDto);

        /// <summary>
        /// returns empty data to us with the WorkUpdateDto and id values it receives
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<NoDataDto>> UpdateWorkWithUniqueId(WorkUpdateDto entity, int id);


    }
}
