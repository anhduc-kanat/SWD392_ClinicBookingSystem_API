using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_Service.Models.Response.Meeting;

public class GetMeetingResponse
{
    public int Id { get; set; }
    public DateOnly? Date { get; set; }
    public int MeetingAttempt { get; set; }
    public MeetingStatus Status { get; set; }
    public int? DentistId { get; set; }
    public string? DentistName { get; set; }
}