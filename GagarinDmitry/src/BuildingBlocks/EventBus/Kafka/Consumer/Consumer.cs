using Confluent.Kafka;
using Kafka.Configs;
using Kafka.Consumer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Kafka.Consumer
{
    public class Consumer<TK, TV> : BackgroundService
    {
        private readonly ConsumerConfiguration config;

        private readonly IServiceScopeFactory serviceScopeFactory;

        public Consumer(IOptions<ConsumerConfiguration> config, IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.config = config.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();

            using var scope = serviceScopeFactory.CreateScope();
            var consumerHandler = scope.ServiceProvider.GetRequiredService<IConsumerHandler<TK, TV>>();

            var builder = new ConsumerBuilder<TK, TV>(config).SetValueDeserializer(new Deserializer<TV>());
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
