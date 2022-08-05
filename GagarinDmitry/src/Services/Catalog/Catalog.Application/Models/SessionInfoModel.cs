namespace Catalog.Application.Models
{
    public class SessionInfoModel
    {
        public string FilmType { get; set; } = null!;

        public DateTimeOffset StartTime { get; set; }

        public int CinemaId { get; set; }

        public int FreeSeats { get; set; }
    }
}
