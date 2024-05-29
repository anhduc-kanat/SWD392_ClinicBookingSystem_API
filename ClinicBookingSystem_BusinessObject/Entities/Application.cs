using System.ComponentModel.DataAnnotations;
using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Application : BaseEntities
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ApplicationType Type { get; set; }
    public ApplicationStatus Status { get; set; }
    public bool IsApproved { get; set; }
    
    //User
    public User User { get; set; }
}