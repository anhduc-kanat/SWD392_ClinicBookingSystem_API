using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Application;
using ClinicBookingSystem_Service.Models.Response.Application;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingApplication : Profile
{
    public MappingApplication()
    {
        CreateMap<Application, ApplicationResponse>();
        CreateMap<Application, CreateNewApplicationRequest>().ReverseMap();
        CreateMap<Application, UpdateApplicationRequest>().ReverseMap();
        
    }
}