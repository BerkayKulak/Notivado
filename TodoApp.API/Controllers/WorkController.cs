using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TodoApp.API.Filters;
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
        private readonly ILogger _logger;

        public WorkController(IWorkService workService, ILogger<WorkController> logger)
        {
            _workService = workService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetWork()
        {
            _logger.LogInformation("GetWork Metoduna girdi");
            return ActionResultInstance(await _workService.GetWorksWithUniqueId());
        }

        [ServiceFilter(typeof(NotFoundFilter<Work,WorkDto>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkById(int id)
        {
            _logger.LogInformation("GetWorkById Metoduna girdi");
            return ActionResultInstance(await _workService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> SaveWork(WorkAddDto workAddDto)
        {
            _logger.LogInformation("SaveWork Metoduna girdi");
            return ActionResultInstance(await _workService.AddWorksWithUniqueId(workAddDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWork(WorkUpdateDto workUpdateDto)
        {
            _logger.LogInformation("UpdateWork Metoduna girdi");
            return ActionResultInstance(await _workService.UpdateWorkWithUniqueId(workUpdateDto, workUpdateDto.Id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            _logger.LogInformation("DeleteWork Metoduna girdi");
            return ActionResultInstance(await _workService.Remove(id));
        }
    }
}
