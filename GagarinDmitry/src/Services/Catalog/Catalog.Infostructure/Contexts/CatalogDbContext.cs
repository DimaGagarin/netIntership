using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Catalog.Infostructure.Contexts
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; } = null!;

        public DbSet<Cinema> Cinemas { get; set; } = null!;

        public CatalogDbContext(
            DbContextOptions<CatalogDbContext> options
           ) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
