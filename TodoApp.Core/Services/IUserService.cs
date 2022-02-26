using System.Threading.Tasks;
using TodoApp.Core.DTOs;

namespace TodoApp.Core.Services
{
    public interface IUserService
    {
        /// <summary>
        /// a method that allows us to register a user
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns></returns>
        Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<Response<UserDto>> GetUserByNameAsync(string userName);

    }
}
