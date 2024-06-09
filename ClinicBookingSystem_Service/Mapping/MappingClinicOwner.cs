using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Clinic_Owner;
using ClinicBookingSystem_Service.Models.Response.Clinic_Owner;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingClinicOwner : Profile
{
    public MappingClinicOwner()
    {
        CreateMap<CreateClinicOwnerRequest, User>().ReverseMap();
        CreateMap<UpdateClinicOwnerRequest, User>().ReverseMap();
        CreateMap<User, GetClinicOwnerResponse>();
    }
}