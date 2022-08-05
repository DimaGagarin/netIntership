using Catalog.Application.Events;
using Catalog.Application.Events.Handlers;
using Confluent.Kafka;
using Kafka.Configs;

namespace Catalog.WebApi.Extensions.Consumers
{
    public static class ConsumerExtension
    {
        public static IServiceCollection AddConsumers(this IServiceCollection services)
        {
            services.AddConsumer<string, TicketBuyEvent, TicketBuyHandler>(p =>
            {
                p.Topic = "Sessions";
                p.GroupId = "SessionsGroup";
                p.BootstrapServers = "broker:29092";
                p.AutoOffsetReset = AutoOffsetReset.Latest;
            });

            return services;
        }
    }
}
