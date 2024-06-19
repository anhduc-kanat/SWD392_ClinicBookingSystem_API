namespace ClinicBookingSystem_Service.Models.Request.Clinic_Owner;

public class CreateClinicOwnerRequest
{
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}