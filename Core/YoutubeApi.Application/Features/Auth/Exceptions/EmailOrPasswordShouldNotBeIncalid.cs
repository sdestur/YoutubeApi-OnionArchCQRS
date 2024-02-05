using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInValid : BaseException
    {
        public EmailOrPasswordShouldNotBeInValid() : base("Kullanıcı adı veya şifre yanlıştır.!") { }

    }

}
