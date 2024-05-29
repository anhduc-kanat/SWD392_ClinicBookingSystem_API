using System.ComponentModel.DataAnnotations;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Specification : BaseEntities
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string ImageUrl { get; set; }
    public string AwaredAt { get; set; }
    
    //User
    public User User { get; set; }
    
    //Service 
    public ICollection<Service> Services { get; set; }
}