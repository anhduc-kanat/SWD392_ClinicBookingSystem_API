using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Response.Meeting;

namespace ClinicBookingSystem_Service.IService;

public interface IMeetingService
{
    Task<BaseResponse<UpdateMeetingResponse>> UpdateMeetingStatus(int meetingId, MeetingStatus status);
}