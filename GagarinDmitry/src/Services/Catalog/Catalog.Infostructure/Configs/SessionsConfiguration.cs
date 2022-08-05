using Catalog.Domain.Entities;
using Catalog.Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infostructure.Configs
{
    public class SessionsConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasData
            (
                new Session
                {
                    Id = 1,
                    FilmType = FilmType.Film,
                    StartTime = DateTime.Now,
                    FreeSeats = 50,
                    CinemaId = 1
                },
                new Session
                {
                    Id = 2,
                    FilmType = FilmType.Cartoon,
                    StartTime = DateTime.Now,
                    FreeSeats = 50,
                    CinemaId = 1
                }
            );
        }
    }
}
