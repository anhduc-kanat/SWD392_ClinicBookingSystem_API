namespace ClinicBookingSystem_Service.IService;

public interface IQueueService
{
    Task PublishAppointmentToQueue(int appointmentId, int dentistId);
}