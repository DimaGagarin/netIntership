using AutoMapper;
using Basket.Application.Events;
using Basket.Application.Models;
using Basket.Application.Services.Interfaces;
using Basket.Domain.Entities;
using Basket.Domain.Interfaces;
using Kafka.Producer.Interfaces;

namespace Basket.Application.Services
{
    internal class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IMapper mapper;
        private readonly IKafkaProducer<string, TicketBuyEvent> kafkaProducer;

        public TicketService(ITicketRepository repository, IMapper mapper, IKafkaProducer<string, TicketBuyEvent> kafkaProducer)
        {
            this.ticketRepository = repository;
            this.mapper = mapper;
            this.kafkaProducer = kafkaProducer;
        }

        public async Task<TicketInfo> GetAsync(int id, CancellationToken cancellationToken)
        {
            var ticket = await ticketRepository.GetAsync(id, cancellationToken);

            return mapper.Map<TicketInfo>(ticket);
        }

        public async Task<int> CreateAsync(TicketInfo ticketInfo, CancellationToken cancellationToken)
        {
            var ticketBuyEvent = new TicketBuyEvent(ticketInfo.SessionId);

            await kafkaProducer.ProduceAsync("ticketBuy", ticketBuyEvent);


            var ticket = mapper.Map<Ticket>(ticketInfo);

            return await ticketRepository.CreateAsync(ticket, cancellationToken);
        }
    }
}
