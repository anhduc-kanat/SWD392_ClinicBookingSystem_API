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
    public string? FullName { get; set; }

    public bool? IsTreatment { get; set; }
    //User
    public ICollection<User>? Users { get; set; }
    //Service
    public BusinessService? BusinessService { get; set; }
    //Slot
    public Slot? Slot { get; set; }

}
