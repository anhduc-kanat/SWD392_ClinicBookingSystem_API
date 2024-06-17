namespace ClinicBookingSystem_Service.Models.DTOs.Appointment;
using ClinicBookingSystem_BusinessObject.Entities;
public class AppointmentDto
{
    public DateTime Date { get; set; }
    public bool? IsPeriod { get; set; }
    public int? ReExamUnit { get; set; }
    public int? ReExamNumber { get; set; }
    public bool? IsTreatment { get; set; }
    public IEnumerable<User> Users { get; set; }
    public BusinessService BusinessService { get; set; }
    public Slot Slot { get; set; }

}