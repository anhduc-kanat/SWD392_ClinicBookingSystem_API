using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_Service.Models.Response.Appointment;

public class UserGetAppointmentResponse
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public bool IsPeriod { get; set; }
    public int ReExamUnit { get; set; }
    public int ReExamNumber { get; set; }
    public bool IsApprove { get; set; }
    public string Description { get; set; }
    public string FeedBack { get; set; }
    public bool IsTreatment { get; set; }
    public string DentistName { get; set; }
    public string UserTreatmentName { get; set; }
    public string ServiceName { get; set; }
    public ServiceType ServiceType { get; set; }
    public string SlotName { get; set; }
    public TimeSpan StartAt { get; set; }
    public TimeSpan EndAt { get; set; }
}