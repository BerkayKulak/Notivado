using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;
using TodoApp.Core.Services;

namespace TodoApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : CustomBaseController
    {
        private readonly IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
          
        }

        [HttpGet]
        public async Task<IActionResult> GetWork()
        {
            return ActionResultInstance(await _workService.GetWorksWithUniqueId());
        }

        [HttpPost]
        public async Task<IActionResult> SaveWork(WorkAddDto workAddDto)
        {
            return ActionResultInstance(await _workService.AddWorksWithUniqueId(workAddDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWork(WorkDto productDto)
        {
            return ActionResultInstance(await _workService.Update(productDto, productDto.Id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            return ActionResultInstance(await _workService.Remove(id));
        }
    }
}
