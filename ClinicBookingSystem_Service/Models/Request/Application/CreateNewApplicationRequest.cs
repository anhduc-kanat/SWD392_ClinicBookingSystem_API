namespace ClinicBookingSystem_Service.Models.Request.Application;

public class CreateNewApplicationRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Type { get; set; }
}