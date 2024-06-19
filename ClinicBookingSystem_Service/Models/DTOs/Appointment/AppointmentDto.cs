namespace ClinicBookingSystem_Service.Models.DTOs.Appointment;
using ClinicBookingSystem_BusinessObject.Entities;
public class AppointmentDto
{
    public DateTime Date { get; set; }
    public bool? IsPeriod { get; set; }
    public int? ReExamUnit { get; set; }
    public int? ReExamNumber { get; set; }
    public bool? IsTreatment { get; set; }
    public int? UserTreatmentId { get; set; }
    public string? UserTreatmentName { get; set; }
    public int? UserAccountId { get; set; }
    public string? UserAccountName { get; set; }
    public int DentistAccountId { get; set; }
    public string? DentistAccountName { get; set; }
    public int? DentistTreatmentId { get; set; }
    public string? DentistTreatmentName { get; set; }
    public int? StaffAccountId { get; set; }
    public string? StaffAccountName { get; set; }
    public IEnumerable<User> Users { get; set; }
    public BusinessService BusinessService { get; set; }
    public Slot Slot { get; set; }

}