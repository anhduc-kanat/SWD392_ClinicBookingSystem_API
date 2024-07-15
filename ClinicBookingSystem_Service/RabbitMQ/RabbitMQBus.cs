using ClinicBookingSystem_Service.RabbitMQ.IService;
using MassTransit;

namespace ClinicBookingSystem_Service.RabbitMQ;

public class RabbitMQBus : IRabbitMQBus
{
    private readonly IPublishEndpoint _publishEndpoint;
    public RabbitMQBus(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    public async Task PublishAsync<T> (T message) where T : class
    {
        await _publishEndpoint.Publish(message);
    }
}