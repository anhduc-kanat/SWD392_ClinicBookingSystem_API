using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Response.Meeting;
using ClinicBookingSystem_Service.RabbitMQ.IService;
using MassTransit.RabbitMqTransport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;

[ApiController]
[Route("api/meeting")]
public class MeetingController : ControllerBase
{
    private readonly IMeetingService _meetingService;
    private readonly IQueueService _queueService;
    public MeetingController(IMeetingService meetingService,
        IQueueService queueService)
    {
        _meetingService = meetingService;
        _queueService = queueService;
    }
    
    /// <summary>
    /// Update meeting status bởi staff, login và truyền Bearer token vào header
    /// </summary>
    /// <remarks>
    /// 1: Done
    ///
    /// 2: CheckIn (Checkin để bắt đầu cuộc hẹn)
    ///
    /// 3: Waiting (Trong trạng thái chờ để được checkin)
    ///
    /// 4: Future (Cuộc hẹn sắp tới - không phải ngày hôm nay)
    /// </remarks>
    /// <param name="meetingId"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("update-meeting-status/{meetingId}")]
    public async Task<BaseResponse<UpdateMeetingResponse>> UpdateMeetingStatus(int meetingId, MeetingStatus status)
    {
        var result = await _meetingService.UpdateMeetingStatus(meetingId, status);
        return result;
    }
    
    /// <summary>
    /// Staff add dentist vào meeting, login và truyền Bearer token vào header
    /// </summary>
    /// <param name="meetingId"></param>
    /// <param name="dentistId"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("add-dentist-into-meeting/{meetingId}/{dentistId}")]
    [Authorize(Roles = "STAFF")]
    public async Task<BaseResponse<AddDentistIntoMeetingResponse>> AddDentistIntoMeeting(int meetingId, int dentistId)
    {
        var addDentistResponse = await _meetingService.AddDentistIntoMeeting(meetingId, dentistId);
        if (addDentistResponse.Data != null)
            await _queueService.PublishAppointmentToQueue(addDentistResponse.Data.MeetingId,
                addDentistResponse.Data.DentistId);
        return addDentistResponse;
    }
    
    /// <summary>
    /// Staff và Customer đều có thể update dentist trong meeting
    /// </summary>
    /// <param name="meetingId"></param>
    /// <param name="dentistId"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("update-dentist-in-meeting/{meetingId}/{dentistId}")]
    [Authorize]
    public async Task<BaseResponse<UpdateDentistInMeeting>> UpdateDentistInMeeting(int meetingId, int dentistId)
    {
        var result = await _meetingService.UpdateDentistInMeeting(meetingId, dentistId);
        return result;
    }
    
    /// <summary>
    /// Dentist hoàn thành 1 cuộc hẹn, login và truyền Bearer token vào header
    /// </summary>
    /// <remarks>
    /// Chỉ có dentist mới có quyền update meeting status thành Done
    /// </remarks>
    /// <param name="meetingId"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("update-meeting-into-done/{meetingId}")]
    [Authorize(Roles = "DENTIST")]
    public async Task<BaseResponse<UpdateMeetingIntoDoneResponse>> UpdateMeetingIntoDone(int meetingId)
    {
        var result = await _meetingService.UpdateMeetingIntoDone(meetingId);
        return result;
    }
}