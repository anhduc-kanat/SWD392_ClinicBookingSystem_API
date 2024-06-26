using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_Service.Models.Response.Appointment;

public class UserGetAppointmentResponse
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public bool? IsReExam { get; set; }
    public AppointmentStatus Status { get; set; }
    public string Description { get; set; }
    public string FeedBack { get; set; }
    public string UserAccountName { get; set; }
    public string UserTreatmentName { get; set; }
    public string? PatientGender { get; set; }
    public string? PatientPhoneNumber { get; set; }
    public string? PatientAddress { get; set; }
    public string? PatientDateOfBirth { get; set; }
    public string? PatientCCCD { get; set; }
    public string? PatientType { get; set; }
    public string SlotName { get; set; }
    public TimeSpan StartAt { get; set; }
    public TimeSpan EndAt { get; set; }
}