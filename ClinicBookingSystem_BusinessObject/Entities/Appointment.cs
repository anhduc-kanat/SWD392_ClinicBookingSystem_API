using System.ComponentModel.DataAnnotations;
using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Appointment : BaseEntities
{
    [Key]
    public int Id { get; set; }
    public DateTimeOffset Date { get; set; }
    public bool IsPeriod { get; set; }
    public int ReExamUnit { get; set; }
    public int ReExamNumber { get; set; }
    public AppointmentType Type { get; set; }
    public bool IsApproved { get; set; }
    public AppointmentStatus Status { get; set; }
    public string Description { get; set; }
    public string feedBack {get; set; }
    public int DurationMinute { get; set; }
    public int SlotEncounter { get; set; }
    
    //User
    public ICollection<User> Users { get; set; }
    //Service
    public ICollection<Service> Services { get; set; }
}