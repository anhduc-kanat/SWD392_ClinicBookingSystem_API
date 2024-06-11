using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Role;
using ClinicBookingSystem_Service.Models.Response.Role;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingRole : Profile
{
    public MappingRole()
    {
        
        CreateMap<CreateRoleRequest, Role>();
        CreateMap<Role, CreateRoleResponse>().ReverseMap();
        CreateMap<Role, GetRoleResponse>().ReverseMap();
        CreateMap<Role, DeleteRoleResponse>().ReverseMap();
        CreateMap<Role, UpdateRoleResponse>().ReverseMap();
        CreateMap<UpdateRoleRequest, Role>();
    }
}