using System.ComponentModel.DataAnnotations;
using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class AppointmentBusinessService : BaseEntities
{
    public AppointmentBusinessServiceStatus? Status { get; set; }
    public int? UserTreatmentId { get; set; }
    public string? UserTreatmentName { get; set; }
    public int? UserAccountId { get; set; }
    public string? UserAccountName { get; set; }
    public int? DentistId { get; set; }
    public string? DentistName { get; set; }
    public string? ServiceName { get; set; }
    public long ServicePrice { get; set; }
    public ServiceType? ServiceType { get; set; }
    
    //Appointment
    public Appointment? Appointment { get; set; }
    //BusinessService
    public BusinessService? BusinessService { get; set; }
    //Meeting
    public ICollection<Meeting>? Meetings { get; set; }
    public int? TotalMeetingDate { get; set; }
    public int? MeetingCount { get; set; }
}