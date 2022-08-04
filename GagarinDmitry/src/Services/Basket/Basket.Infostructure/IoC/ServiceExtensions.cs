using Basket.Domain.Interfaces;
using Basket.Infostructure.Contexts;
using Basket.Infostructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Infostructure.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BasketDbcontext>(config =>
            {
                config.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITicketRepository, TicketRepository>();

            return services;
        }
    }
}
