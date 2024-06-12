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
        CreateMap<Appointment, GetAppointmentResponse>().ReverseMap();
        
        //Customer booking appointment
        CreateMap<Appointment, CustomerBookingAppointmentResponse>().ReverseMap();
        CreateMap<Appointment, CustomerBookingAppointmentRequest>();
    }
}