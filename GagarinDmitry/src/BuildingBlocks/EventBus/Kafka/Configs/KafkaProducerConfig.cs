using Confluent.Kafka;

namespace Kafka.Configs
{
    public class KafkaProducerConfig : ProducerConfig
    {
        public string Topic { get; set; } = null!;
    }
}
