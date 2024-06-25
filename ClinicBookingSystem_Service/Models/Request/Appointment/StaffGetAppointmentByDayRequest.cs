using System.ComponentModel;

namespace ClinicBookingSystem_Service.Models.Request.Appointment;

public class StaffGetAppointmentByDayRequest
{
    [DefaultValue($"DateOnly.FromDateTime(DateTime.Now)")]
    public DateOnly Date { get; set; }
    
}