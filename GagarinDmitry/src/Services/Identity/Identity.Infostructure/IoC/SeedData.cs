using Identity.Domain.Common.Types;
using Identity.Domain.Entities;
using Identity.Infostructure.Configs;
using Identity.Infostructure.Contexts;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infostructure.IoC
{
    /// <summary>
    /// Provides Initial Data
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Method for initialize DbContexts
        /// </summary>
        /// <param name="app"><see cref="IApplicationBuilder"/> to extend</param>
        public async static Task InitializeDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

            if (serviceScope is null)
            {
                return;
            }

            serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

            var configDbContext = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

            configDbContext.Database.Migrate();

            var applicationDbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            applicationDbContext.Database.Migrate();

            if (!configDbContext.Clients.Any())
            {
                foreach (var client in IdentityConfig.Clients)
                {
                    configDbContext.Clients.Add(client.ToEntity());
                }
                configDbContext.SaveChanges();
            }

            if (!configDbContext.IdentityResources.Any())
            {
                foreach (var resource in IdentityConfig.IdentityResources)
                {
                    configDbContext.IdentityResources.Add(resource.ToEntity());
                }
                configDbContext.SaveChanges();
            }

            if (!configDbContext.ApiScopes.Any())
            {
                foreach (var resource in IdentityConfig.ApiScopes)
                {
                    configDbContext.ApiScopes.Add(resource.ToEntity());
                }
                configDbContext.SaveChanges();
            }

            if (!configDbContext.ApiResources.Any())
            {
                foreach (var resource in IdentityConfig.ApiResources)
                {
                    configDbContext.ApiResources.Add(resource.ToEntity());
                }
                configDbContext.SaveChanges();
            }

            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            if (!applicationDbContext.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole<int>(RoleType.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole<int>(RoleType.Client.ToString()));
            }

            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

            if (!applicationDbContext.Users.Any())
            {
                User admin = new()
                {
                    AccountBalance = 50000,
                    UserName = "Admin",
                    FirstName = "Dima",
                    SecondName = "Gaagrin",
                    Age = 21
                };

                IdentityResult result = await userManager.CreateAsync(admin, "password");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, RoleType.Admin.ToString());
                }
            }
        }
    }
}
