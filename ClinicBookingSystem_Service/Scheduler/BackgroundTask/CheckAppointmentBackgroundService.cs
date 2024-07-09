using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.RabbitMQ.IService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClinicBookingSystem_Service.Scheduler.BackgroundTask;

public class CheckAppointmentBackgroundService : BackgroundService
{
    private readonly ILogger<CheckAppointmentBackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IRabbitMQService _rabbitMqService;
    public CheckAppointmentBackgroundService(ILogger<CheckAppointmentBackgroundService> logger,
        IServiceProvider serviceProvider,
        IRabbitMQService rabbitMqService)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _rabbitMqService = rabbitMqService;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var provider = _serviceProvider.CreateScope();
        var unitOfWork = provider.ServiceProvider.GetRequiredService<IUnitOfWork>();
        _logger.LogInformation("5 secs job: CheckAppointmentBackgroundService is starting.");
        var appointments = await unitOfWork.AppointmentRepository.GetTodayMeetingTreatmentAppointment();
        foreach (var appointment in appointments)
        {
            
        }
    }
}