using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Salary;
using ClinicBookingSystem_Service.Models.Response.Salary;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingSalary : Profile
{
    public MappingSalary()
    {
        CreateMap<CreateNewSalaryRequest, Salary>().ReverseMap();
        CreateMap<Salary, CreateNewSalaryRequest>().ReverseMap();
        CreateMap<Salary, GetSalaryResponse>();
        CreateMap<UpdateNewSalaryRequest, Salary>().ReverseMap();
        CreateMap<Salary, UpdateNewSalaryRequest>();
    }
}