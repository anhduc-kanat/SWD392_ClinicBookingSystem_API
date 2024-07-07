namespace ClinicBookingSystem_Service.RabbitMQ.IService;

public interface IRabbitMQBus
{
    Task PublishAsync<T>(T message, string queueName) where T : class;
}