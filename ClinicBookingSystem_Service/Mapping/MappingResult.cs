using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Response.Result;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingResult : Profile
{
    public MappingResult()
    {
        CreateMap<Result, GetResultResponse>().ReverseMap()
            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
            .ForMember(dest => dest.Medicines, opt => opt.MapFrom(src => src.Medicines));
        CreateMap<Result, CreateResultResponse>().ReverseMap();
        CreateMap<Result, UpdateResultResponse>().ReverseMap();
        CreateMap<Result, DeleteResultResponse>().ReverseMap();
        
        CreateMap<Result, Appointment>().ReverseMap()
            .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(src => src.Id));
    }
}