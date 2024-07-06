using ClinicBookingSystem_Service.RabbitMQ.Events.Appointment;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace ClinicBookingSystem_Service.RabbitMQ.Consumers.Appointment;

public class GetAllConsumer : IConsumer<GetAllEvent>
{
    private readonly ILogger<GetAllEvent> _logger;
    public GetAllConsumer(ILogger<GetAllEvent> logger)
    {
        _logger = logger;
    }
    public Task Consume(ConsumeContext<GetAllEvent> context)
    {
        _logger.LogInformation("GetAllConsumer ${Message}" + context.Message);
        return Task.CompletedTask;
    }
}