namespace Kafka.Consumer.Interfaces
{
    public interface IConsumerHandler<in TK, in TV>
    {
        Task HandlerAsync(TK key, TV value);
    }
}
