using Confluent.Kafka;

namespace Kafka.Configs
{
    public class ProducerConfiguration : ProducerConfig
    {
        public string Topic { get; set; } = null!;
    }
}
