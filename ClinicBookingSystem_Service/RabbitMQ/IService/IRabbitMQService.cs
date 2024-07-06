namespace ClinicBookingSystem_Service.RabbitMQ.IService;

public interface IRabbitMQService
{
    void PublishMessage(string queueName, string message);
    void ConsumerMessage(string queueName);
}