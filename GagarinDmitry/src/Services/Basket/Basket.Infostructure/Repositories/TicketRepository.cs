using Basket.Domain.Entities;
using Basket.Domain.Interfaces;
using Basket.Infostructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Basket.Infostructure.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        private readonly BasketDbcontext context;

        public TicketRepository(BasketDbcontext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(Ticket ticket, CancellationToken cancellationToken)
        {
            context.Add(ticket);

            await context.SaveChangesAsync(cancellationToken);

            return ticket.Id;
        }

        public async Task<Ticket?> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Tickets
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
