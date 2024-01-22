﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Interfaces.Tokens;
using YoutubeApi.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace YoutubeApi.Infrastructure.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly TokenSetting tokenSettings;
        private readonly UserManager<User> userManager;

        public TokenService(IOptions<TokenSetting> options, UserManager<User> userManager)
        {
            tokenSettings = options.Value;
            this.userManager = userManager;
        }
        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email , user.Email),

            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));

            var token = new JwtSecurityToken(
                issuer : tokenSettings.Issuer,
                audience : tokenSettings.Audience,
                expires : DateTime.Now.AddMinutes(tokenSettings.TokenValidityInMunites),
                claims : claims,
                signingCredentials : new SigningCredentials(key , SecurityAlgorithms.HmacSha256)
                );

            await userManager.AddClaimsAsync(user ,claims);

            return token;
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken()
        {
            throw new NotImplementedException();
        }
    }
}
