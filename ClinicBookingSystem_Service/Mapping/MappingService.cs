using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Service;
using ClinicBookingSystem_Service.Models.Response.Service;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingService : Profile
{
    public MappingService()
    {
        CreateMap<CreateServiceRequest, BusinessService>();
        CreateMap<UpdateServiceRequest, BusinessService>();
        CreateMap<BusinessService, GetServiceResponse>().ReverseMap();
        CreateMap<CreateServiceResponse, BusinessService>().ReverseMap();
        CreateMap<UpdateServiceResponse, BusinessService>().ReverseMap();
        CreateMap<BusinessService, DeleteServiceResponse>().ReverseMap();

    }
}