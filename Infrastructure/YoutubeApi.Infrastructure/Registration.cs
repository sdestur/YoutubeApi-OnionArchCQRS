using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Infrastructure.Tokens;

namespace YoutubeApi.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<TokenSetting>(configuration.GetSection("JWT"));
        }
    }
}
