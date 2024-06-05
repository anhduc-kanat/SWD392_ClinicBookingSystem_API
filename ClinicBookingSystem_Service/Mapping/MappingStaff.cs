using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Dtos.Request;
using ClinicBookingSystem_Service.Models.Request.Staff;
using ClinicBookingSystem_Service.Models.Response.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Mapping
{
    public class MappingStaff : Profile
    {
        public MappingStaff()
        {
            CreateMap<CreateStaffRequest, User>().ReverseMap();
            CreateMap<UpdateStaffRequest, User>().ReverseMap();
            CreateMap<User, GetStaffByIdResponse>();
            CreateMap<User, GetAllStaffsResponse>();
            CreateMap<User, DeleteStaffResponse>();
            CreateMap<User, CreateStaffResponse>();
            CreateMap<User, UpdateStaffResponse>();
        }
    }
}
