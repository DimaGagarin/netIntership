using Catalog.Domain.Entities.Types;

namespace Catalog.Domain.Entities
{
    public class Session : BaseEntity
    {
        public FilmType FilmType { get; set; } 

        public DateTimeOffset StartTime { get; set; }

        public int CinemaId { get; set; }

        public int FreeSeats { get; set; }

        public Cinema Cinema { get; set; } = null!;
    }
}
