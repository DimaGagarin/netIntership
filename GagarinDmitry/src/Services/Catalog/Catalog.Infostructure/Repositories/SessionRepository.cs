using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infostructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infostructure.Repositories
{
    internal class SessionRepository : ISessionRepository
    {
        private readonly CatalogDbContext context;

        public SessionRepository(CatalogDbContext context)
        {
            this.context = context;
        }

        public async Task<Session?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Sessions
                .Include(s => s.Cinema)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Session session, CancellationToken cancellationToken)
        {
            context.Sessions.Update(session);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
