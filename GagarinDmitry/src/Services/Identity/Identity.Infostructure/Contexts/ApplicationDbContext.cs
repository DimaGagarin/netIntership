using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Identity.Infostructure.Contexts
{
    /// <summary>
    /// Class for the Entity Framework database context used for identity.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        /// <summary>
        /// Application configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new <see cref="ApplicationDbContext"/> instance with <see cref="DbContextOptions"/>.
        /// </summary>
        /// <param name="options"><see cref="DbContextOptions"/> options.</param>
        /// <param name="configuration">Application configuration.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.Configuration = configuration;
            Database.Migrate();
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
