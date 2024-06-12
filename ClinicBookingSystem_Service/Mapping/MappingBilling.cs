using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Billing;
using ClinicBookingSystem_Service.Models.Response.Billing;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingBilling : Profile
{
    public MappingBilling()
    {
        CreateMap<Billing, GetBillingResponse>().ReverseMap();
        CreateMap<CreateBillingRequest, Billing>();
        CreateMap<UpdateBillingRequest, Billing>();
        CreateMap<Billing, CreateBillingResponse>().ReverseMap();
        CreateMap<Billing, UpdateBillingResponse>().ReverseMap();
        CreateMap<Billing, DeleteBillingResponse>().ReverseMap();
        
    }
}