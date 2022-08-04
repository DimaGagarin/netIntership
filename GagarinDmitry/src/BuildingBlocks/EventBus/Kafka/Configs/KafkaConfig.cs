using Confluent.Kafka;
using Kafka.Consumer;
using Kafka.Producer;
using Kafka.Producer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kafka.Configs
{
    public static class KafkaConfig
    {
        public static IServiceCollection AddKafkaConsumer<TK, TV, THandler>(this IServiceCollection services, Action<KafkaConsumerConfig> configAction) where THandler : class, IConsumerHandler<TK, TV>
        {
            services.AddScoped<IConsumerHandler<TK, TV>, THandler>();

            services.AddHostedService<KafkaConsumer<TK, TV>>();

            services.Configure(configAction);

            return services;
        }

        public static IServiceCollection AddKafkaProducer<TK, TV>(this IServiceCollection services, Action<KafkaProducerConfig> configAction)
        {
            services.AddSingleton(
                 sp =>
                 {
                     var config = sp.GetRequiredService<IOptions<KafkaProducerConfig>>();
                     var builder = new ProducerBuilder<TK, TV>(config.Value).SetValueSerializer(new KafkaSerializer<TV>());

                     return builder.Build();
                 });

            services.AddSingleton<IKafkaProducer<TK, TV>, KafkaProducer<TK, TV>>();

            services.Configure(configAction);

            return services;
        }
    }
}
