using FluentValidation.AspNetCore;
using Identity.Application.Services;
using Identity.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Identity.Application.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            services.AddServices();

            services.AddAutoMapper(currentAssembly);
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssembly(currentAssembly));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
