using AutoMapper;
using ClinicBookingSystem_Service.Models.Request.Service;
using ClinicBookingSystem_Service.Models.Response.Service;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingService : Profile
{
    public MappingService()
    {
        CreateMap<CreateServiceRequest, ClinicBookingSystem_BusinessObject.Entities.Service>().ReverseMap();
        CreateMap<ClinicBookingSystem_BusinessObject.Entities.Service, CreateServiceRequest>().ReverseMap();
        CreateMap<ClinicBookingSystem_BusinessObject.Entities.Service, GetServiceResponse>();
        CreateMap<UpdateServiceRequest, ClinicBookingSystem_BusinessObject.Entities.Service>().ReverseMap();
        CreateMap<ClinicBookingSystem_BusinessObject.Entities.Service, UpdateServiceRequest>();

    }
}