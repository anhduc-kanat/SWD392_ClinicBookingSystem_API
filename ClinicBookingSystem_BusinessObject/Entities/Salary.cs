using System.ComponentModel.DataAnnotations;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Salary : BaseEntities
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public long amount { get; set; }
    
    //Users
    public ICollection<User>? Users { get; set; }
}