using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.User;
using ClinicBookingSystem_Service.Models.Response.User;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateNewUserRequest, User>().ReverseMap();
        CreateMap<User, CreateNewUserResponse>().ReverseMap();
        CreateMap<User, GetAllUserResponse>();
        CreateMap<User, GetUserByIdResponse>();
        CreateMap<User, DeleteUserResponse>();
        CreateMap<User, UpdateUserResponse>();
        CreateMap<UpdateUserRequest, User>().ReverseMap();
    }
}