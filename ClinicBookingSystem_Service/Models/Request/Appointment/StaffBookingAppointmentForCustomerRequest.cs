using System.ComponentModel;

namespace ClinicBookingSystem_Service.Models.Request.Appointment;

public class StaffBookingAppointmentForCustomerRequest
{
    public DateOnly Date { get; set; }
    public int ServiceId { get; set; }
    [DefaultValue(false)]
    public bool? IsReExam { get; set; }
    public int SlotId { get; set; }
    public int DentistId { get; set; }
    public int UserAccountId { get; set; }
    public int PatientId { get; set; }
}