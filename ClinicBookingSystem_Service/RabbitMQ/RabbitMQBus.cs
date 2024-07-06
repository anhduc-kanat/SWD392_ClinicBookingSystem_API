using ClinicBookingSystem_Service.RabbitMQ.IService;
using MassTransit;

namespace ClinicBookingSystem_Service.RabbitMQ;

public class RabbitMQBus : IRabbitMQBus
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ISendEndpointProvider _sendEndpointProvider;
    public RabbitMQBus(IPublishEndpoint publishEndpoint,
        ISendEndpointProvider sendEndpointProvider)
    {
        _publishEndpoint = publishEndpoint;
        _sendEndpointProvider = sendEndpointProvider;
    }
    public async Task PublishAsync<T> (T message, string queueName) where T : class
    {
        var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"));
        await endpoint.Send(message);
    }
}