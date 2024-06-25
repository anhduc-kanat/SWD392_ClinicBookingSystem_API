namespace ClinicBookingSystem_Service.Models.DTOs.Appointment;
using ClinicBookingSystem_BusinessObject.Entities;
public class AppointmentDto
{
    public DateTime Date { get; set; }
    public bool? IsReExam { get; set; }
    public int? UserTreatmentId { get; set; }
    public string? UserTreatmentName { get; set; }
    public int? UserAccountId { get; set; }
    public string? UserAccountName { get; set; }
    public int? StaffAccountId { get; set; }
    public string? StaffAccountName { get; set; }
    public IEnumerable<User> Users { get; set; }
    public Slot Slot { get; set; }

}