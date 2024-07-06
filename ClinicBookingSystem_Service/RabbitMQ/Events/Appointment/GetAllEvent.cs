namespace ClinicBookingSystem_Service.RabbitMQ.Events.Appointment;

public class GetAllEvent
{
    public int Id { get; set; }
    public string Name { get; set; }
}