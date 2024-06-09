using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Salary;
using ClinicBookingSystem_Service.Models.Request.Service;
using ClinicBookingSystem_Service.Models.Request.Slot;
using ClinicBookingSystem_Service.Models.Request.Specification;
using ClinicBookingSystem_Service.Models.Request.User;
using ClinicBookingSystem_Service.Models.Response.Salary;
using ClinicBookingSystem_Service.Models.Response.Service;
using ClinicBookingSystem_Service.Models.Response.Slot;
using ClinicBookingSystem_Service.Models.Response.Specification;
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
        


        //
        CreateMap<CreateSpecificationRequest, Specification>().ReverseMap();
        CreateMap<Specification, CreateSpecificationRequest>().ReverseMap();
        CreateMap<Specification, GetSpecificationResponse>();
        CreateMap<UpdateSpecificationRequest, Specification>().ReverseMap();
        CreateMap<Specification, UpdateSpecificationRequest>();

    }
}