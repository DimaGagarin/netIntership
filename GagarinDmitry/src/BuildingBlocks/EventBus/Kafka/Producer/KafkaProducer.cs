using Confluent.Kafka;
using Kafka.Configs;
using Kafka.Producer.Interfaces;
using Microsoft.Extensions.Options;

namespace Kafka.Producer
{
    public class KafkaProducer<TK, TV> : IKafkaProducer<TK, TV>
    {
        private readonly IProducer<TK, TV> producer;

        private readonly string topic;

        public KafkaProducer(IOptions<KafkaProducerConfig> topicOptions, IProducer<TK, TV> producer)
        {
            topic = topicOptions.Value.Topic;
            this.producer = producer;
        }

        public async Task ProduceAsync(TK key, TV value)
        {
            await producer.ProduceAsync(topic, new Message<TK, TV> { Key = key, Value = value });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            producer?.Dispose();
        }
    }
}
