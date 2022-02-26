using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TodoApp.API.Controllers;
using TodoApp.Core.DTOs;
using TodoApp.Core.Services;

namespace TodoApp.NUnitTest
{
    [TestFixture]
    public class UserControllerTest
    {
        private Mock<IUserService> _userService;

        private UserController _controller;

        private IHttpContextAccessor _httpContextAccessor;

        private CreateUserDto _createUserDto;

        private UserDto _userDto;


        [SetUp]
        public void Setup()
        {
            _userService = new Mock<IUserService>();

            _controller = new UserController(_userService.Object, _httpContextAccessor);

            _createUserDto = new CreateUserDto()
            {
                Email = "Kulakbekay17",

                Password = "Kulakbekay17*",

                UserName = "kulakberkay17@gmail.com"
            };

            _userDto = new UserDto()
            {
                Email = "Kulakbekay17",

                UserName = "Kulakbekay17*",

                Id = "f448e38f-257b-4323-96f9-947727c111d5"
            };

        }

        [Test]
        public async Task CreateUser_ActionExecute_ReturnCreateUserAsync()
        {
            _userService.Setup(x => x.CreateUserAsync(_createUserDto))
                .ReturnsAsync(Response<UserDto>.Success(_userDto, 200));

            var result = _controller.CreateUser(createUserDto:_createUserDto);


            Assert.IsInstanceOf(typeof(Task<IActionResult>), result);
        }





    }


}
