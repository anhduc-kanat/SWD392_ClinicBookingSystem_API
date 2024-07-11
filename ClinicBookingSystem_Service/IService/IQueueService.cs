namespace ClinicBookingSystem_Service.IService;

public interface IQueueService
{
    Task PublishAppointmentToQueue(int appointmentBusinessServiceId, int dentistId);
    Task ConsumeMessageDentistQueue(string dentistName);
}