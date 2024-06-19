using System.Text.Json.Serialization;
using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_Service.Models.Response.Service;
using ClinicBookingSystem_Service.Models.Response.Slot;

namespace ClinicBookingSystem_Service.Models.Response.Appointment;

public class GetAppointmentResponse
{
    public int? Id { get; set; }
    public DateOnly? Date { get; set; }
    public bool? IsPeriod { get; set; }
    public int? ReExamUnit { get; set; }
    public int? ReExamNumber { get; set; }
    public AppointmentStatus? Status { get; set; }
    public string? Description { get; set; }
    public string? FeedBack { get; set; }
    public bool? IsTreatment { get; set; }
    public string? DentistTreatmentName { get; set; }
    public string? UserAccountName { get; set; }
    public string? PatientName { get; set; }
    public string? PatientGender { get; set; }
    public string? PatientPhoneNumber { get; set; }
    public string? PatientAddress { get; set; }
    public string? PatientDateOfBirth { get; set; }
    public string? PatientCCCD { get; set; }
    public string? PatientType { get; set; }
    public string? ServiceName { get; set; }
    public ServiceType? ServiceType { get; set; }
    public string? SlotName { get; set; }
    public TimeSpan? StartAt { get; set; }
    public TimeSpan? EndAt { get; set; }
    
}