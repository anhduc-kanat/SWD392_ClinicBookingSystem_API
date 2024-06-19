using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Response.User;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingUser : Profile
{
    public MappingUser()
    {
        CreateMap<GetMyProfileResponse, User>().ReverseMap()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
    }
}