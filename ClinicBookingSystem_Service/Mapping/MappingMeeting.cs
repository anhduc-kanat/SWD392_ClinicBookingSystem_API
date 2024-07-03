using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Response.Meeting;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingMeeting : Profile
{
    public MappingMeeting()
    {
        CreateMap<GetMeetingResponse, Meeting>().ReverseMap();
    }
}