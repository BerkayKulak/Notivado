using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
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

            var result = await _controller.RegisterUser(createUserDto:_createUserDto);

            Assert.IsInstanceOf(typeof(IActionResult), result);
        }


        [Test]
        public void CreateUser_ActionExecute_GetUser()
        {
            _userService.Setup(x => x.GetUserByNameAsync(/*_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value)*/"Kulakbekay17"));

            var responseWorkDto = Response<CreateUserDto>.Success(_createUserDto, 200);

            Assert.AreEqual(responseWorkDto.Data.Email, "Kulakbekay17");
        }




    }


}
