using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Note;
using ClinicBookingSystem_Service.Models.Response.Note;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingNote : Profile
{
    public MappingNote()
    {
        CreateMap<Note, DentistAddNoteResponse>().ReverseMap();
        CreateMap<DentistAddNoteRequest, Note>();
        CreateMap<Note, AppointmentBusinessService>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}