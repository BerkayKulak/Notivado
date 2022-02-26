﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using TodoApp.Core.Configuration;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;

namespace TodoApp.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly CustomTokenOptions _tokenOptions;

        public TokenService(UserManager<User> userManager, IOptions<CustomTokenOptions> tokenOptions)
        {
            _userManager = userManager;
            _tokenOptions = tokenOptions.Value;
        }

        private string CreateRefreshToken()
        {


            var numberByte = new Byte[32];

            using var rnd = RandomNumberGenerator.Create();

            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }

        private IEnumerable<Claim> GetClaim(User userApp, List<String> audiences)
        {
            var userList = new List<Claim>()
            {
                // kullanıcının kimliği oludğundan dolayı ID ye karşılık geliyor.
                new Claim(ClaimTypes.NameIdentifier,userApp.Id),
                new Claim(JwtRegisteredClaimNames.Email,userApp.Email),
                new Claim(ClaimTypes.Role,userApp.UserName),
            
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            // Audience bakacak gerçekten kendisinie istek yapılmaya uygun mu kontrol edecek, eğer uygun değilse tokeni geri çevirecek.
            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            return userList;

        }

        // üyelik sistemi gerektirmeyen token oluşturmak istediğimde
        private IEnumerable<Claim> GetClaimsByClient(Client client)
        {
            var claims = new List<Claim>();

            claims.AddRange(client.Audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());

            new Claim(JwtRegisteredClaimNames.Sub, client.Id).ToString();

            return claims;
        }


        public TokenDto CreateToken(User userApp)
        {
            // var olan saate dakika olarak eklicek
            // token ömrünü belirledik
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.RefreshTokenExpiration);

            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOptions.SecurityKey);

            // şifreleme algoritmamız
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenOptions.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaim(userApp, _tokenOptions.Audience), signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto()
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };

            return tokenDto;

        }

        public ClientTokenDto CreateTokenByClient(Client client)
        {
            // var olan saate dakika olarak eklicek
            // token ömrünü belirledik
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOptions.SecurityKey);

            // şifreleme algoritmamız
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenOptions.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaimsByClient(client),
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new ClientTokenDto()
            {
                AccessToken = token,
                AccessTokenExpiration = accessTokenExpiration,
            };

            return tokenDto;
        }
    }
}
