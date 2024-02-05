using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions
{
    public class RefreshTokenSouldNotBeExpiredException : BaseException
    {
        public RefreshTokenSouldNotBeExpiredException() : base("Oturum süresi sona ermiştirç Lütfen tekrar giriş yapın.") { }


    }

}
