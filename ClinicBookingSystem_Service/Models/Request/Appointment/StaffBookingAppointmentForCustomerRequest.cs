namespace ClinicBookingSystem_Service.Models.Request.Appointment;

public class StaffBookingAppointmentForCustomerRequest
{
    public DateOnly Date { get; set; }
    public int ServiceId { get; set; }
    public int SlotId { get; set; }
    public int DentistId { get; set; }
    public int PatientId { get; set; }
}