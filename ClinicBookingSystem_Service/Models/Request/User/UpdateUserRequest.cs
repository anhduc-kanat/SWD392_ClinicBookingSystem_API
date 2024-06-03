namespace ClinicBookingSystem_Service.Models.Request.User;

public class UpdateUserRequest
{
    public string EmailCode { get; set; }
    public string Address { get; set; }
    public string PhoneCode { get; set; }
}