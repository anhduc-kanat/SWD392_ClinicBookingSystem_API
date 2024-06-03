namespace ClinicBookingSystem_Service.Models.Response.User;

public class UpdateUserResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string EmailCode { get; set; }
    public string Address { get; set; }
    public string PhoneCode { get; set; }
    
}