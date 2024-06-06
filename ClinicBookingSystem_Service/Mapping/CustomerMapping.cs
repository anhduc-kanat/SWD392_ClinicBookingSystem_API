using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Authen;
using ClinicBookingSystem_Service.Models.Request.Customer;
using ClinicBookingSystem_Service.Models.Request.User;
using ClinicBookingSystem_Service.Models.Response.Authen;
using ClinicBookingSystem_Service.Models.Response.Customer;
using ClinicBookingSystem_Service.Models.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Mapping
{
    public class CustomerMapping :Profile
    {
        public CustomerMapping()
        {
            CreateMap<RegisterRequest, User>().ReverseMap();
            CreateMap<User, RegisterResponse>();
            CreateMap<UpdateCustomerRequest, User>().ReverseMap();
            CreateMap<User,UpdateCustomerResponse>();
            CreateMap<User, GetCustomerResponse>();
            CreateMap<User, DeleteCustomerResponse>();

        }

    }
}
