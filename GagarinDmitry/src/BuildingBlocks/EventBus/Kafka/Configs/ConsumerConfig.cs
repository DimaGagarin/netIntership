using Confluent.Kafka;

namespace Kafka.Configs
{
    public class KafkaConsumerConfig : ConsumerConfig
    {
        public string Topic { get; set; } = null!;

        public KafkaConsumerConfig()
        {
            AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
            EnableAutoOffsetStore = false;
        }
    }
}
