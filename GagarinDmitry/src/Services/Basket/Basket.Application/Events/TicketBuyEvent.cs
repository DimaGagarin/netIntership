namespace Basket.Application.Events
{
    public class TicketBuyEvent
    {
        public int SessionId { get; set; }

        public TicketBuyEvent(int SessionId)
        {
            this.SessionId = SessionId;
        }
    }
}
