using Catalog.Domain.Interfaces;
using Catalog.Infostructure.Contexts;
using Catalog.Infostructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infostructure.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogDbContext>(config =>
            {
                config.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISessionRepository, SessionRepository>();

            return services;
        }
    }
}
