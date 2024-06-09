using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Medicine;
using ClinicBookingSystem_Service.Models.Response.Medicine;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingMedicine : Profile
{
    public MappingMedicine()
    {
        CreateMap<Medicine, GetMedicineResponse>().ReverseMap();
        CreateMap<CreateMedicineResponse, Medicine>().ReverseMap();
        CreateMap<UpdateMedicineResponse, Medicine>().ReverseMap();
        CreateMap<DeleteMedicineResponse, Medicine>().ReverseMap();
        CreateMap<Medicine, CreateMedicineRequest>();
        CreateMap<Medicine, UpdateMedicineRequest>();
        
    }
}