using System.ComponentModel.DataAnnotations;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Salary : BaseEntities
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int amount { get; set; }
    
    //Users
    public ICollection<User> Users { get; set; }
}