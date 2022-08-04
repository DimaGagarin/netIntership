using Confluent.Kafka;
using Newtonsoft.Json;
using System.Text;

namespace Kafka.Configs
{
    internal sealed class KafkaSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            if (typeof(T) == typeof(Null))
            {
                return Array.Empty<byte>();
            }

            if (typeof(T) == typeof(Ignore))
            {
                throw new NotSupportedException("Not Supported.");
            }

            var json = JsonConvert.SerializeObject(data);

            return Encoding.UTF8.GetBytes(json);
        }
    }
}
