using ClinicBookingSystem_BusinessObject.Entities;

namespace ClinicBookingSystem_Service.Models.Response.Appointment;

public class StaffBookingAppointmentResponse
{
    public int AppointmentId { get; set; }
    public string UserAccountId { get; set; }
    public string UserAccountName { get; set; }
    public List<AppointmentBusinessService> AppointmentBusinessServices { get; set; }
    public string UserAccountPhone { get; set; }
}