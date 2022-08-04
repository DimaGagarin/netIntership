namespace Kafka.Producer.Interfaces
{
    public interface IKafkaProducer<in TK, in TV> : IDisposable
    {
        public Task ProduceAsync(TK key, TV value);
    }
}
