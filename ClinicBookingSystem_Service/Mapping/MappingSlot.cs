using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.DTOs.Slot;
using ClinicBookingSystem_Service.Models.Request.Slot;
using ClinicBookingSystem_Service.Models.Response.Slot;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingSlot : Profile
{
    public MappingSlot()
    {
        CreateMap<CreateNewSlotRequest, Slot>();
        CreateMap<UpdateSlotRequest, Slot>();
        CreateMap<Slot, SlotResponse>().ReverseMap();
        CreateMap<Slot, SlotDto>().ReverseMap();

    }
}