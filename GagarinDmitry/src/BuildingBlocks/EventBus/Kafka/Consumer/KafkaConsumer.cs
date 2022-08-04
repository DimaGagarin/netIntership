using Confluent.Kafka;
using Kafka.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Kafka.Consumer
{
    public class KafkaConsumer<TK, TV> : BackgroundService
    {
        private readonly KafkaConsumerConfig config;

        private readonly IServiceScopeFactory serviceScopeFactory;

        public KafkaConsumer(IOptions<KafkaConsumerConfig> config, IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.config = config.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();

            using var scope = serviceScopeFactory.CreateScope();
            var consumerHandler = scope.ServiceProvider.GetRequiredService<IConsumerHandler<TK, TV>>();

            var builder = new ConsumerBuilder<TK, TV>(config).SetValueDeserializer(new KafkaDeserializer<TV>());
            using var consumer = builder.Build();

            consumer.Subscribe(config.Topic);

            while (!stoppingToken.IsCancellationRequested)
            {
                var result = consumer.Consume(TimeSpan.FromMilliseconds(10));

                if (result != null)
                {
                    await consumerHandler.HandlerAsync(result.Message.Key, result.Message.Value);
                    consumer.Commit(result);
                    consumer.StoreOffset(result);
                }
            }
        }
    }
}
