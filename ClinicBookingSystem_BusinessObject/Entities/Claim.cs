using System.ComponentModel.DataAnnotations;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Claim : BaseEntities
{
    [Key]
    public int Id { get; set; }
    public string? ClaimGroup { get; set; }
    public string? ClainValue { get; set; }
    public string? Description { get; set; }
    
    //Role
    public ICollection<Role>? Roles { get; set; }
    //USer
    public ICollection<User>? Users { get; set; }
}