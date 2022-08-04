namespace Kafka.Consumer.Interfaces
{
    public interface IKafkaConsumerHandler<in TK, in TV>
    {
        Task HandlerAsync(TK key, TV value);
    }
}
