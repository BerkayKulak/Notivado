using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.DTOs;
using TodoApp.Core.Services;

namespace TodoApp.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;

            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserDto createUserDto)
        {

            return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {

            return ActionResultInstance(await _userService.GetUserByNameAsync(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value));
        }
    }
}
