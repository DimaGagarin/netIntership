namespace Basket.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public int SessionId { get; set; }

        public DateTimeOffset DateOfPurchase { get; set; }

        public int Row { get; set; }

        public int Seat { get; set; }

        public int Price { get; set; }
    }
}
