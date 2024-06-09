using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_Service.Models.Response.Appointment;

public class GetAppointmentResponse
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool IsPeriod { get; set; }
    public int ReExamUnit { get; set; }
    public int ReExamNumber { get; set; }
    public bool IsApproved { get; set; }
    public AppointmentStatus Status { get; set; }
    public string Description { get; set; }
    public string FeedBack { get; set; }
    public bool IsTreatment { get; set; }
    public int DentistId { get; set; }
    public string DentistName { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    
    
}