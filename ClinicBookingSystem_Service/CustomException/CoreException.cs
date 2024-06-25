using ClinicBookingSystem_Service.Models.Enums;

namespace ClinicBookingSystem_Service.CustomException;


public class CoreException : Exception
{
    public StatusCodeEnum StatusCode { get; set; }
    public string Message { get; set; }

    public CoreException(string message, StatusCodeEnum statusCode) : base(message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}