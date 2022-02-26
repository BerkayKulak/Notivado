using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DTOs;

namespace TodoApp.Core.Services
{
    public interface IAuthenticationnService
    {
        /// <summary>
        /// The method that generates the token of the login user
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        /// <summary>
        /// the method of generating refresh tokens
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

        /// <summary>
        /// the method that revokes the validity of the token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);

        /// <summary>
        /// the token method produced by the client
        /// </summary>
        /// <param name="clientLoginDto"></param>
        /// <returns></returns>
        Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}
