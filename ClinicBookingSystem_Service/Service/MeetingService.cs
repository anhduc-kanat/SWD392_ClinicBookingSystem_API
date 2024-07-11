using AutoMapper;
using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.CustomException;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Response.Meeting;

namespace ClinicBookingSystem_Service.Service;

public class MeetingService : IMeetingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public MeetingService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<UpdateMeetingResponse>> UpdateMeetingStatus(int meetingId, MeetingStatus status)
    {
        var meeting = await _unitOfWork.MeetingRepository.GetMeetingById(meetingId);
        if(meeting == null) throw new CoreException("Meeting not found", StatusCodeEnum.BadRequest_400);
        
        var appointment =
            await _unitOfWork.AppointmentRepository.GetAppointmentById(
                meeting.AppointmentBusinessService.Appointment.Id);
        if(appointment == null) throw new CoreException("Appointment not found", StatusCodeEnum.BadRequest_400);
        /*if(appointment.IsFullyPaid is null or false)
            throw new CoreException("Appointment is not fully paid", StatusCodeEnum.BadRequest_400);*/
        
        if (meeting.Date.Value.Year > DateTime.Now.Year &&
            meeting.Date.Value.Month > DateTime.Now.Month &&
            meeting.Date.Value.Day > DateTime.Now.Day) throw new CoreException("Meeting is in the future", StatusCodeEnum.BadRequest_400);
        if(status == MeetingStatus.Done) throw new CoreException("Dont have permission to do this", StatusCodeEnum.BadRequest_400);
        
        meeting.Status = status;
        if (meeting.Status == MeetingStatus.CheckIn && appointment.IsFullyPaid == true)
        {
            meeting.AppointmentBusinessService.Appointment.Status = AppointmentStatus.Waiting;
        }
        else if (meeting.Status == MeetingStatus.CheckIn
                 && appointment.IsFullyPaid == false 
                 || appointment.IsFullyPaid == null
                 && appointment.IsClinicalExamPaid == true)
        {
            meeting.AppointmentBusinessService.Appointment.Status = AppointmentStatus.OnGoing;
        }

        await _unitOfWork.MeetingRepository.UpdateAsync(meeting);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<UpdateMeetingResponse>(meeting);
        return new BaseResponse<UpdateMeetingResponse>("Update meeting status successfully", StatusCodeEnum.OK_200, result);
    }
    
    public async Task<BaseResponse<AddDentistIntoMeetingResponse>> AddDentistIntoMeeting(int meetingId, int dentistId)
    {
        var meeting = await _unitOfWork.MeetingRepository.GetMeetingById(meetingId);
        if(meeting == null) throw new CoreException("Meeting not found", StatusCodeEnum.BadRequest_400);
        if(meeting.AppointmentBusinessService.ServiceType != ServiceType.Treatment)
            throw new CoreException("Treatment only", StatusCodeEnum.BadRequest_400);
        if(meeting.Status != MeetingStatus.CheckIn) 
            throw new CoreException("Meeting has not been checked-in", StatusCodeEnum.BadRequest_400);
        
        var dentist = await _unitOfWork.DentistRepository.GetDentistById(dentistId);
        if(dentist == null) throw new CoreException("Dentist not found", StatusCodeEnum.BadRequest_400);
        if(!dentist.BusinessServices.Any(p => p.Id == meeting.AppointmentBusinessService.BusinessService.Id))
            throw new CoreException("Dentist not provide this service", StatusCodeEnum.BadRequest_400);
        
        meeting.DentistId = dentistId;
        meeting.DentistName = dentist.FirstName + " " + dentist.LastName;
        await _unitOfWork.MeetingRepository.UpdateAsync(meeting);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<AddDentistIntoMeetingResponse>(meeting);
        result.AppointmentId = meeting.AppointmentBusinessService.Appointment.Id;
        return new BaseResponse<AddDentistIntoMeetingResponse>("Add dentist into meeting successfully", StatusCodeEnum.OK_200, result);
    }
    
    public async Task<BaseResponse<UpdateDentistInMeeting>> UpdateDentistInMeeting(int meetingId, int dentistId)
    {
        var meeting = await _unitOfWork.MeetingRepository.GetMeetingById(meetingId);
        if(meeting == null) throw new CoreException("Meeting not found", StatusCodeEnum.BadRequest_400);
        if(meeting.Status == MeetingStatus.Done)
            throw new CoreException("Can not change when this meeting is done", StatusCodeEnum.BadRequest_400);
        
        var dentist = await _unitOfWork.DentistRepository.GetDentistById(dentistId);
        if(dentist == null) throw new CoreException("Dentist not found", StatusCodeEnum.BadRequest_400);
        if(!dentist.BusinessServices.Any(p => p.Id == meeting.AppointmentBusinessService.BusinessService.Id))
            throw new CoreException("Dentist not provide this service", StatusCodeEnum.BadRequest_400);
        
        meeting.DentistId = dentistId;
        meeting.DentistName = dentist.FirstName + " " + dentist.LastName;
        await _unitOfWork.MeetingRepository.UpdateAsync(meeting);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<UpdateDentistInMeeting>(meeting);
        
        return new BaseResponse<UpdateDentistInMeeting>("Add dentist into meeting successfully", StatusCodeEnum.OK_200, result);
    }
    
    public async Task<BaseResponse<UpdateMeetingIntoDoneResponse>> UpdateMeetingIntoDone(int meetingId)
    {
        var meeting = await _unitOfWork.MeetingRepository.GetMeetingById(meetingId);
        if(meeting == null) throw new CoreException("Meeting not found", StatusCodeEnum.BadRequest_400);
        if(meeting.Status == MeetingStatus.Done)
            throw new CoreException("Meeting is already done", StatusCodeEnum.BadRequest_400);
        
        meeting.Status = MeetingStatus.Done;
        await _unitOfWork.MeetingRepository.UpdateAsync(meeting);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<UpdateMeetingIntoDoneResponse>(meeting);
        return new BaseResponse<UpdateMeetingIntoDoneResponse>("Update meeting into done successfully", StatusCodeEnum.OK_200, result);
    }
}