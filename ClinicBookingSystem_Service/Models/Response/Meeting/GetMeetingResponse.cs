using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_Service.Models.Response.Meeting;

public class GetMeetingResponse
{
    public DateOnly? Date { get; set; }
    public int MeetingAttempt { get; set; }
    public MeetingStatus Status { get; set; }
}