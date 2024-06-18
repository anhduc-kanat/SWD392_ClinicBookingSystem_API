using System.ComponentModel.DataAnnotations;
using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Appointment : BaseEntities
{

    public DateTimeOffset Date { get; set; }
    public bool? IsPeriod { get; set; }
    public int? ReExamUnit { get; set; }
    public int? ReExamNumber { get; set; }
    public bool? IsApproved { get; set; }
    public AppointmentStatus Status { get; set; }
    public string? Description { get; set; }
    public string? FeedBack {get; set; }
    public string? UserTreatmentName { get; set; }
    public string? UserAccountName { get; set; }
    public string? DentistAccountName { get; set; }
    public string? DentistTreatmentName { get; set; }
    public string? StaffAccountName { get; set; }
    public bool? IsTreatment { get; set; }
    //User
    public ICollection<User>? Users { get; set; }
    public int? UserAccountId { get; set; }
    public int? UserTreatmentId { get; set; }
    public int? StaffAccountId { get; set; }
    public int? DentistAccountId { get; set; }
    public int? DentistTreatmentId { get; set; }
    //Service
    public BusinessService? BusinessService { get; set; }
    //Slot
    public Slot? Slot { get; set; }

}
