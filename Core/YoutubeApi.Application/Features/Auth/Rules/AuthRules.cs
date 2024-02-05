using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Features.Auth.Exceptions;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }

        public Task EmailOrPasswordShouldNotBeIncalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeIncalid();
            return Task.CompletedTask;
        }

        public Task RefreshTokenSouldNotBeExpired(DateTime? expiredDate)
        {
            if (expiredDate <= DateTime.Now)
            {
                throw new RefreshTokenSouldNotBeExpiredException();
            }
            return Task.CompletedTask;
        }
    }
}
