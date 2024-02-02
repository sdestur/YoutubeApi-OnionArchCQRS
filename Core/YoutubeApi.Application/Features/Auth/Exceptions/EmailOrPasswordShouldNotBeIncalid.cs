using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeIncalid : BaseException
    {
        public EmailOrPasswordShouldNotBeIncalid() : base("Kullanıcı adı veya şifre yanlıştır.!") { }
    }
}
