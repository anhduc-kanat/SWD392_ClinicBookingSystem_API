using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_Service.Models.Response.Application;

public class ApplicationResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public bool IsApprove { get; set; }
    public string Reason { get; set; }
    public string ImageUrl { get; set; }
    public ApplicationStatus Status { get; set; }
}