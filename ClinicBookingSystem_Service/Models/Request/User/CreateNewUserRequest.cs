using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Service.Models.Request.User;

public class CreateNewUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}