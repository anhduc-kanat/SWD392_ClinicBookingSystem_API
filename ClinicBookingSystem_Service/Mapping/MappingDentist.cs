using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Dtos.Request;
using ClinicBookingSystem_Service.Models.Response.Dentist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Mapping
{
    public class MappingDentist : Profile
    {
        public MappingDentist()
        {
            CreateMap<CreateDentistRequest, User>().ReverseMap();
            CreateMap<User, GetDentistByIdResponse>();
            CreateMap<User, GetAllDentistsResponse>();
            CreateMap<User, DeleteDentistResponse>();
        }
    }
}
