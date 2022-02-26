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
        Task<Response<List<WorkAddDto>>> GetWorksWithUniqueId();
        Task<Response<WorkAddDto>> AddWorksWithUniqueId(WorkAddDto workAddDto);


    }
}
