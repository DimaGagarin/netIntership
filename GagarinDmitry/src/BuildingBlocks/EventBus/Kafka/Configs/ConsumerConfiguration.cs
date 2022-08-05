using Confluent.Kafka;

namespace Kafka.Configs
{
    public class ConsumerConfiguration : ConsumerConfig
    {
        public string Topic { get; set; } = null!;

        public ConsumerConfiguration()
        {
            AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
            EnableAutoOffsetStore = false;
        }
    }
}
