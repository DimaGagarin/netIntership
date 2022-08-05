using FluentValidation.AspNetCore;
using Identity.Application.Services;
using Identity.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Identity.Application.IoC
{
    /// <summary>
    /// Provides extension methods to add services descriptors to the container.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds account business logic components to the container.
        /// </summary>
        /// <param name="services">Service collection to add services descriptors to.</param>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            services.AddServices();

            services.AddAutoMapper(currentAssembly);
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssembly(currentAssembly));

            return services;
        }

        /// <summary>
        /// Adds business logic services to the container.
        /// </summary>
        /// <param name="services">Service collection to add services descriptors to.</param>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
