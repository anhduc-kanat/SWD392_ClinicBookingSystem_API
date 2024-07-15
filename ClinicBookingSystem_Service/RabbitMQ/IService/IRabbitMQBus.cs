namespace ClinicBookingSystem_Service.RabbitMQ.IService;

public interface IRabbitMQBus
{
    Task PublishAsync<T>(T message) where T : class;
    
}