using Catalog.Domain.Interfaces;
using Kafka.Consumer;

namespace Catalog.Application.Events.Handlers
{
    public class TicketBuyHandler : IConsumerHandler<string, TicketBuyEvent>
    {
        private readonly ISessionRepository sessionRepository;

        public TicketBuyHandler(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        public async Task HandlerAsync(string key, TicketBuyEvent value)
        {
            var session = await sessionRepository.GetAsync(value.SessionId, new CancellationToken());

            if (session != null)
            {
                session.FreeSeats--;

                await sessionRepository.UpdateAsync(session, new CancellationToken());
            }
        }
    }
}
