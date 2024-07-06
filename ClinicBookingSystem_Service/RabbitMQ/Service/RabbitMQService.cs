using System.Text;
using ClinicBookingSystem_Service.RabbitMQ.IService;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ClinicBookingSystem_Service.RabbitMQ.Service;

public class RabbitMQService : IRabbitMQService
{
    private readonly RabbitMQConnection _rabbitMQConnection;
    public RabbitMQService(RabbitMQConnection rabbitMQConnection)
    {
        _rabbitMQConnection = rabbitMQConnection;
    }
    public void PublishMessage(string queueName, string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        _rabbitMQConnection.GetConnection().CreateModel().BasicPublish(exchange: "",
            routingKey: queueName,
            basicProperties: null,
            body: body);
    }
    public void ConsumerMessage(string queueName)
    {
        var channel = _rabbitMQConnection.GetConnection().CreateModel();
        channel.QueueDeclare(queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] Received {0}", message);
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        };
        channel.BasicConsume(queue: queueName,
            autoAck: false,
            consumer: consumer);
    }
}