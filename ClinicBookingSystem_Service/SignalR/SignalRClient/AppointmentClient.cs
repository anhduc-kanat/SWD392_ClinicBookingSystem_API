using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.RabbitMQ.IService;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClinicBookingSystem_Service.SignalR.SignalRClient;

public class AppointmentClient
{
    private readonly HubConnection _hubConnection;
    private readonly IRabbitMQService _rabbitMqService;
    private readonly IUnitOfWork _unitOfWork;
    public AppointmentClient(string hubUrl, IRabbitMQService rabbitMqService,
        IUnitOfWork unitOfWork)
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(hubUrl)
            .Build();
        
        _rabbitMqService = rabbitMqService;
        _unitOfWork = unitOfWork;
        _hubConnection.On<string>("ReceiveAppointmentStatusChange", async (appointmentId) =>
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetAppointmentById(Convert.ToInt32(appointmentId));
            _rabbitMqService.PublishMessage("appointmentId", "asd");
        });
    }
    
}