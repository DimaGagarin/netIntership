using Confluent.Kafka;
using Kafka.Consumer;
using Kafka.Consumer.Interfaces;
using Kafka.Producer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kafka.Configs
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddConsumer<TK, TV, THandler>(this IServiceCollection services, Action<ConsumerConfiguration> configAction) where THandler : class, IConsumerHandler<TK, TV>
        {
            services.AddScoped<IConsumerHandler<TK, TV>, THandler>();

            services.AddHostedService<Consumer<TK, TV>>();

            services.Configure(configAction);

            return services;
        }

        public static IServiceCollection AddProducer<TK, TV>(this IServiceCollection services, Action<ProducerConfiguration> configAction)
        {
            services.AddSingleton(
                 sp =>
                 {
                     var config = sp.GetRequiredService<IOptions<ProducerConfiguration>>();
                     var builder = new ProducerBuilder<TK, TV>(config.Value).SetValueSerializer(new Serializer<TV>());

                     return builder.Build();
                 });

            services.AddSingleton<Producer.Interfaces.IKafkaProducer<TK, TV>, Producer<TK, TV>>();

            services.Configure(configAction);

            return services;
        }
    }
}
