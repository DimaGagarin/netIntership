using Basket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Basket.Infostructure.Contexts
{
    public class BasketDbcontext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; } = null!;

        public BasketDbcontext(
            DbContextOptions<BasketDbcontext> options
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
