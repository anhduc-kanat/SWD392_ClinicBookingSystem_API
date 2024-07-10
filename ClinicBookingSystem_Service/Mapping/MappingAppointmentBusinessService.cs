using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Response.Appointment;
using ClinicBookingSystem_Service.Models.Response.AppointmentService;
using ClinicBookingSystem_Service.Models.Response.Transaction;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingAppointmentBusinessService : Profile
{
    public MappingAppointmentBusinessService()
    {
        CreateMap<GetAppointmentServiceResponse, AppointmentBusinessService>().ReverseMap()
            .ForMember(dest => dest.Meetings, opt => opt.MapFrom(src => src.Meetings));

        CreateMap<GetAppointmentServiceName, AppointmentBusinessService>().ReverseMap();
        


    }
}