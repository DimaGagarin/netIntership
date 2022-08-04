using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(currentAssembly);
            services.AddAutoMapper(currentAssembly);

            return services;
        }
    }
}
