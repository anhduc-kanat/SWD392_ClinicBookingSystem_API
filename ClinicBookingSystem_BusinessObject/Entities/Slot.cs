using System.ComponentModel.DataAnnotations;
using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Slot : BaseEntities
{
    public string Name { get; set;  }
    public string? Description { get; set; }
    public TimeSpan StartAt { get; set; }
    public TimeSpan EndAt { get; set; }
    public SlotStatus Status { get; set; }
    //Appointment
    public ICollection<Appointment>? Appointments { get; set; }
}