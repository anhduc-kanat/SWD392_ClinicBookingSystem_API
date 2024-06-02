using System.ComponentModel.DataAnnotations;
using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Application : BaseEntities
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Reason { get; set; }
    public ApplicationStatus? Status { get; set; } = ApplicationStatus.Pending;
    public string? ImageUrl { get; set; }
    public bool? IsApproved { get; set; }
    
    //User
    public ICollection<User>? User { get; set; }
}