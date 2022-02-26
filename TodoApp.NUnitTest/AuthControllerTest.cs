﻿using System;
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
    public class AuthControllerTest
    {
        private Mock<IAuthenticationnService> _authService;

        private AuthController _controller;

        private ClientLoginDto _clientLoginDto;

        private LoginDto _loginDto;

        private RefreshTokenDto _refreshTokenDto;

        private TokenDto _tokenDto;



        [SetUp]
        public void Setup()
        {
            _authService = new Mock<IAuthenticationnService>();

            _controller = new AuthController(_authService.Object);

            _clientLoginDto = new ClientLoginDto()
            {
                ClientId = "",
                ClientSecret = ""
            };

            _loginDto = new LoginDto()
            {
                Email = "Kulakbekay17*",
                Password = "kulakberkay17@gmail.com",
            };

            _refreshTokenDto = new RefreshTokenDto()
            {
                Token = "aKlszzaSHpVLqVZke8u9b5LAffNwtd/vxUXt8mXWj4E="
            };

            _tokenDto = new TokenDto()
            {
                AccessToken =
                    "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9." +
                    "eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImJiMmI5MDNmLTkxZjgtNDI1OS1hNDNlL" +
                    "TdhYTNkZTYyYWExNyIsImVtYWlsIjoia3VsYWtiZXJrYXkxN0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJrdWxha2J" +
                    "lcmtheTE3IiwianRpIjoiYzBmN2I0MTMtYTVkOS00NmE1LWI5ODctZjdiYTRiMDM5ODQ3IiwiYXVkIjpbInd3dy5hdXRoc2V" +
                    "ydmVyLmNvbSIsInd3dy5taW5pYXBwMS5jb20iLCJ3d3cubWluaWFwcDIuY29tIiwid3d3Lm1pbmlhcHAzLmNvbSJdLCJuYmYiOjE2NDU4Nzc0MDUs" +
                    "ImV4cCI6MTY0NTg3ODAwNSwiaXNzIjoid3d3LmF1dGhzZXJ2ZXIuY29tIn0.IsI6qoXtzBck-AEFn_OWLVCpT45lpEVDi4P7GZcY5nU",
                AccessTokenExpiration = DateTime.Now.AddMinutes(10),
                RefreshToken = "aKlszzaSHpVLqVZke8u9b5LAffNwtd/vxUXt8mXWj4E=",
                RefreshTokenExpiration = DateTime.Now.AddMinutes(600)

            };


        }

        [Test]
        public async Task Login_ActionExecute_ReturnResponseTokenDto()
        {
            _authService.Setup(x => x.CreateTokenAsync(_loginDto));

            var result =  _controller.Login(_loginDto);

            Assert.IsInstanceOf(typeof(Task<IActionResult>), result);
        }




    }
}
