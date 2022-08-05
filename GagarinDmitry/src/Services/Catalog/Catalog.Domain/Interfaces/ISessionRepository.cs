using Catalog.Domain.Entities;

namespace Catalog.Domain.Interfaces
{
    public interface ISessionRepository
    {
        Task<Session?> GetAsync(int id, CancellationToken cancellationToken);

        Task UpdateAsync(Session session, CancellationToken cancellationToken);
    }
}
