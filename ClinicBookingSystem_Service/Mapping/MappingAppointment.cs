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
        CreateMap<Appointment, CreateAppointmentRequest>();
        CreateMap<Appointment, UpdateAppointmentRequest>();
        CreateMap<Appointment, CreateAppointmentResponse>().ReverseMap();
        CreateMap<Appointment, UpdateAppointmentResponse>().ReverseMap();
        CreateMap<Appointment, DeleteAppointmentResponse>().ReverseMap();    
        CreateMap<Appointment, GetAppointmentResponse>().ReverseMap();
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
    }
}