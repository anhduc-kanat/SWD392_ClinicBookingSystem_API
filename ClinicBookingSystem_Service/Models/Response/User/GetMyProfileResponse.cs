using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_Service.Models.Response.Service;
using ClinicBookingSystem_Service.Models.Response.Specification;

namespace ClinicBookingSystem_Service.Models.Response.User;

public class GetMyProfileResponse
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public bool? EmailConfirmed { get; set; }
    public bool? PhoneConfirmed { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? DateOfBirth { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? TotalDateOff { get; set; }
    public int? DateOffCount { get; set; }
    public int? TotalEmergencyDateOffAttempt { get; set; }
    public int? EmergencyDateOffAttemptCount { get; set; }
    public bool? IsOnDateOff { get; set; }
    public JobStatus? JobStatus { get; set; }
    public DateOnly? StartDateOff { get; set; }
    public DateOnly? EndDateOff { get; set; }
    public string? RoleName { get; set; }
    public ICollection<GetServiceResponse>? BusinessServices { get; set; }
    public ICollection<GetSpecificationResponse>? Specifications { get; set; }
}