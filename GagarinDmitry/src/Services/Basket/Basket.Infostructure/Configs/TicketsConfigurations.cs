using Basket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.Infostructure.Configs
{
    public class TicketsConfigurations : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasData
            (
                new Ticket
                {
                    Id = 1,
                    SessionId = 1,
                    DateOfPurchase = DateTime.Now,
                    Row = 1,
                    Seat = 1,
                    Price = 212
                },
                new Ticket
                {
                    Id = 2,
                    SessionId = 1,
                    DateOfPurchase = DateTime.Now,
                    Row = 1,
                    Seat = 2,
                    Price = 212
                }
            );
        }
    }
}
