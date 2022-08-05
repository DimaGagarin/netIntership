using Basket.Application.Events;
using Kafka.Configs;

namespace Basket.WebApi.Extensions.Produsers
{
    public static class ProducerExtension
    {
        public static IServiceCollection AddProducers(this IServiceCollection services)
        {
            services.AddProducer<string, TicketBuyEvent>(p =>
            {
                p.Topic = "Sessions";
                p.BootstrapServers = "broker:29092";
            });

            return services;
        }
    }
}
