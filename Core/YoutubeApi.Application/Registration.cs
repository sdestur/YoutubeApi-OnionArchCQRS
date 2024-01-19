using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Beheviors;
using YoutubeApi.Application.Exceptions;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Application.Interfaces.UnitOfWorks;

namespace YoutubeApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
           var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }
    }
}
