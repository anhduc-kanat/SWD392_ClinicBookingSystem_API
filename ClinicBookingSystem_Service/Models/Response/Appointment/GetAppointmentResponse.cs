using System.Text.Json.Serialization;
using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_Service.Models.Response.Service;
using ClinicBookingSystem_Service.Models.Response.Slot;

namespace ClinicBookingSystem_Service.Models.Response.Appointment;

public class GetAppointmentResponse
{
    public int Id { get; set; }
    public DateTimeOffset Date { get; set; }
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
    public string ServiceName { get; set; }
    public ServiceType ServiceType { get; set; }
    public string SlotName { get; set; }
    public int SlotStartAtHour { get; set; }
    public int SlotStartAtMinute { get; set; }
    public int SlotEndAtHour { get; set; }
    public int SlotEndAtMinute { get; set; }
}