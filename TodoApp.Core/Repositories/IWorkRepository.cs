using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;

namespace TodoApp.Core.Repositories
{
    public interface IWorkRepository : IGenericRepository<WorkDto>
    {
        Task<List<Work>> GetWorkByUniqueId();
        Task AddWorkByUniqueId(Work work);
        Work UpdateByUniqueId(Work entity);
        Task<Work> GetByIdUniqueAsync(int id);
    }
}
