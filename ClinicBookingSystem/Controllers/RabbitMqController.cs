using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.RabbitMQ.IService;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;

[ApiController]
[Route("api/rabbitmq")]
public class RabbitMqController : ControllerBase
{
    private readonly IQueueService _queueService;
    public RabbitMqController(IQueueService queueService)
    {
        _queueService = queueService;
    }
    
    [HttpPost("publish-appointment-to-queue/{appointmentId}/{dentistId}")]
    public async Task PublishAppointmentToQueue(int appointmentId, int dentistId)
    {
        await _queueService.PublishAppointmentToQueue(appointmentId, dentistId);
    }
    
    [HttpGet]
    [Route("consume-message-dentist-queue/{dentistPhoneNumber}")]
    public async Task ConsumeMessageDentistQueue(string dentistPhoneNumber)
    {
        await _queueService.ConsumeMessageDentistQueue(dentistPhoneNumber);
    }
    
    [HttpGet]
    [Route("get-queue-length/{dentistPhoneNumber}")]
    public async Task<int> GetQueueLength(string dentistPhoneNumber)
    {
        return await _queueService.GetQueueLength(dentistPhoneNumber);
    }
}