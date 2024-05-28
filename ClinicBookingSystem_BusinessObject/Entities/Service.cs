using ClinicBookingSystem_BusinessObject.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Service
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ExpectedDurationInMinute { get; set; }
    public ServiceType ServiceType { get; set; }
    
    //Specification
    public Specification Specification { get; set; }
    //Appointment
    public ICollection<Appointment> Appointments { get; set; }
}