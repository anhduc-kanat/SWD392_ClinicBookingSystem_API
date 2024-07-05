using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Response.Appointment;
using ClinicBookingSystem_Service.Models.Response.AppointmentService;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingAppointmentBusinessService : Profile
{
    public MappingAppointmentBusinessService()
    {
        CreateMap<GetAppointmentServiceResponse, AppointmentBusinessService>().ReverseMap()
            .ForMember(dest => dest.Meetings, opt => opt.MapFrom(src => src.Meetings));
        
    }
}