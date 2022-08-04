using Identity.Domain.Entities;
using Identity.Infostructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Identity.Infostructure.IoC
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
        {
            services
                .AddDbContext<ApplicationDbContext>()
                .AddIdentity<User, IdentityRole<int>>(options =>
                {
                    options.Password.RequiredLength = 1;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                })
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssembly = typeof(ServiceExtension).GetTypeInfo().Assembly.GetName().Name;

            services
                .AddIdentityServer()
                .AddAspNetIdentity<User>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                       sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddDeveloperSigningCredential();

            return services;
        }
    }
}
