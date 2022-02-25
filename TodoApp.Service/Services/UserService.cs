using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;
using TodoApp.Core.Services;
using TodoApp.Service.Mapping;

namespace TodoApp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User()
            {
                Email = createUserDto.Email,
                UserName = createUserDto.UserName,
            };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return Response<UserDto>.Fail(new ErrorDto(errors, true), 400);
            }

            return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 200);


        }

        public async Task<Response<UserDto>> GetUserByNameAsync(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);

            if (user == null)
            {
                return Response<UserDto>.Fail("Username not found", 404, true);
            }

            return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 200);
        }
    }
}
