using System.Text.Json.Serialization;
using ClinicBookingSystem_Service.Models.Enums;

namespace ClinicBookingSystem_Service.Models.BaseResponse;

public class BaseResponse<T>
{
    [JsonPropertyOrder(-2)]
    public string Message { get; set; } = "Sucessfull";

    [JsonPropertyOrder(-1)]
    public StatusCodeEnum StatusCode { get; set; } = StatusCodeEnum.OK_200;
    public T? Data { get; set; }
    public BaseResponse(string? message, StatusCodeEnum statusCode, T? data)
    {
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }

    public BaseResponse(string? message, StatusCodeEnum statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }

}