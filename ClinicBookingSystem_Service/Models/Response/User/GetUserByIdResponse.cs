namespace ClinicBookingSystem_Service.Models.Response.User;

public class GetUserByIdResponse
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string EmailCode { get; set; }
}