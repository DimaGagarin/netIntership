using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infostructure.Configs
{
    public class CinemaConfigurations : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData
            (
                new Cinema
                {
                    Id = 1,
                    Title = "October",
                    City = "Mogilev",
                    Country = "Belarus",
                    Address = "ul. Kosmonavtov 35-11",
                    PhoneNumber = "+375228888888"
                }
            );
        }
    }
}
