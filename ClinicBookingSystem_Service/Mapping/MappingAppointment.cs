using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.DTOs.Appointment;
using ClinicBookingSystem_Service.Models.Request.Appointment;
using ClinicBookingSystem_Service.Models.Response.Appointment;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingAppointment : Profile
{
    public MappingAppointment()
    {
        //AppointmentDto
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        
        //CRUD Appointment
        CreateMap<Appointment, CreateAppointmentRequest>();
        CreateMap<Appointment, UpdateAppointmentRequest>();
        CreateMap<Appointment, CreateAppointmentResponse>().ReverseMap();
        CreateMap<Appointment, UpdateAppointmentResponse>().ReverseMap();
        CreateMap<Appointment, DeleteAppointmentResponse>().ReverseMap();
        CreateMap<Appointment, GetAppointmentResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Date.DateTime)))

            .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.BusinessService.Name))
            .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.BusinessService.ServiceType))
            .ForMember(dest => dest.SlotName, opt => opt.MapFrom(src => src.Slot.Name))
            .ForMember(dest => dest.StartAt, opt => opt.MapFrom(src => src.Slot.StartAt))
            .ForMember(dest => dest.EndAt, opt => opt.MapFrom(src => src.Slot.EndAt))

            .ForMember(dest => dest.PatientId , opt => opt.MapFrom(src => src.Users.FirstOrDefault(p => p.Role.Name.Equals("CUSTOMER")).Id))
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Users.FirstOrDefault(p => p.Role.Name.Equals("CUSTOMER")).FirstName))
            .ForMember(dest => dest.DentistId , opt => opt.MapFrom(src => src.Users.FirstOrDefault(p => p.Role.Name.Equals("DENTIST")).Id))
            .ForMember(dest => dest.DentistName, opt => opt.MapFrom(src => src.Users.FirstOrDefault(p => p.Role.Name.Equals("DENTIST")).FirstName));
        
        //Customer booking appointment
        CreateMap<Appointment, CustomerBookingAppointmentResponse>().ReverseMap();
        CreateMap<Appointment, CustomerBookingAppointmentRequest>();
    }
}