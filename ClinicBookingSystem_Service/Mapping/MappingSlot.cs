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
        CreateMap<UpdateSlotRequest, Slot>()
            .ForMember(dest => dest.StartAt, opt => opt.MapFrom(src =>
                src.StartAtHour + ":" + src.StartAtMinute + ":00"))
            .ForMember(dest => dest.EndAt, opt => opt.MapFrom(src =>
                src.EndAtHour + ":" + src.EndAtMinute + ":00"));
        CreateMap<Slot, SlotResponse>().ReverseMap();
        CreateMap<Slot, SlotDto>().ReverseMap();

    }
}