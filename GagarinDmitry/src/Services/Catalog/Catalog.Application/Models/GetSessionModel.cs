using Catalog.Domain.Entities.Types;

namespace Catalog.Application.Models
{
    public class GetSessionModel
    {
        public string FilmType { get; set; } = null!;

        public DateTimeOffset StartTime { get; set; }

        public int CinemaId { get; set; }

        public int FreeSeats { get; set; }
    }
}
