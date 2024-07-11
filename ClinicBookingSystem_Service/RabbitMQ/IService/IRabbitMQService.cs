namespace ClinicBookingSystem_Service.RabbitMQ.IService;

public interface IRabbitMQService
{
    void PublishMessage(string queueName, string message);
    string ConsumeMessage(string queueName);
    void ConsumeAllMessages(string queueName);
    void PurgeQueue(string queueName);
}