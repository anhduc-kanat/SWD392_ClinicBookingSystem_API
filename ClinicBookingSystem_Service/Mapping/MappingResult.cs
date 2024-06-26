using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Response.Result;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingResult : Profile
{
    public MappingResult()
    {
        CreateMap<Result, GetResultResponse>().ReverseMap();
        CreateMap<Result, CreateResultResponse>().ReverseMap();
        CreateMap<Result, UpdateResultResponse>().ReverseMap();
        CreateMap<Result, DeleteResultResponse>().ReverseMap();
    }
}