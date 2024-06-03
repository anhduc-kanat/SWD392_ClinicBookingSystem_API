using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;

namespace ClinicBookingSystem_Service.Models.Response.User;

public class CreateNewUserResponse
{
    public string Email { get; set; }
    public string Password { get; set; }

}