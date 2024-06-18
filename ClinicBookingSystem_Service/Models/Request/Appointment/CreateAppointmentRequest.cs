namespace ClinicBookingSystem_Service.Models.Request.Appointment;

public class CreateAppointmentRequest
{
    public DateOnly Date { get; set; }
    public bool? IsPeriod { get; set; } = false;
    public int? ReExamUnit { get; set; }
    public int? ReExamNumber { get; set; }
    public bool? IsTreatment { get; set; } = false;
    public int ServiceId { get; set; }
    public int SlotId { get; set; }
    public int DentistId { get; set; }
    public int PatientId { get; set; }
}