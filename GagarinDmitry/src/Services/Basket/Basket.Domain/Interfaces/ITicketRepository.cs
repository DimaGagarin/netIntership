using Basket.Domain.Entities;

namespace Basket.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetAsync(int id, CancellationToken cancellationToken);

        Task<int> CreateAsync(Ticket ticket, CancellationToken cancellationToken);

        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
