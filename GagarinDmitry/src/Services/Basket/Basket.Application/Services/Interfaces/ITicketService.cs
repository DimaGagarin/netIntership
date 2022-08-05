using Basket.Application.Models;

namespace Basket.Application.Services.Interfaces
{
    public interface ITicketService
    {
        Task<TicketInfo> GetAsync(int id, CancellationToken cancellationToken);

        Task<int> CreateAsync(TicketInfo ticketInfo, CancellationToken cancellationToken);
    }
}
