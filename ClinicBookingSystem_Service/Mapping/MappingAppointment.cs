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
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.UserTreatmentName))
            .ForMember(dest => dest.PatientAddress, opt =>
                opt.MapFrom(src =>
                    src.Users.FirstOrDefault(p =>
                        p.Id == src.UserAccountId).UserProfiles.FirstOrDefault(p =>
                        p.Id == src.UserTreatmentId).Address))
            .ForMember(dest => dest.PatientGender, opt =>
                opt.MapFrom(src =>
                    src.Users.FirstOrDefault(p =>
                        p.Id == src.UserAccountId).UserProfiles.FirstOrDefault(p =>
                        p.Id == src.UserTreatmentId).Gender))
            .ForMember(dest => dest.PatientType, opt =>
                opt.MapFrom(src =>
                    src.Users.FirstOrDefault(p =>
                        p.Id == src.UserAccountId).UserProfiles.FirstOrDefault(p =>
                        p.Id == src.UserTreatmentId).Type))
            .ForMember(dest => dest.PatientPhoneNumber, opt =>
                opt.MapFrom(src =>
                    src.Users.FirstOrDefault(p =>
                        p.Id == src.UserAccountId).UserProfiles.FirstOrDefault(p =>
                        p.Id == src.UserTreatmentId).PhoneNumber))
            .ForMember(dest => dest.PatientDateOfBirth, opt =>
                opt.MapFrom(src =>
                    src.Users.FirstOrDefault(p =>
                        p.Id == src.UserAccountId).UserProfiles.FirstOrDefault(p =>
                        p.Id == src.UserTreatmentId).DateOfBirth))
            .ForMember(dest => dest.PatientCCCD, opt =>
                opt.MapFrom(src =>
                    src.Users.FirstOrDefault(p =>
                        p.Id == src.UserAccountId).UserProfiles.FirstOrDefault(p =>
                        p.Id == src.UserTreatmentId).CCCD));
        //Customer booking appointment
        CreateMap<Appointment, CustomerBookingAppointmentResponse>().ReverseMap();
        CreateMap<Appointment, CustomerBookingAppointmentRequest>();
        //Get appointment by user id
        CreateMap<Appointment, UserGetAppointmentResponse>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Date.DateTime)))
            .ForMember(dest => dest.SlotName, opt => opt.MapFrom(src => src.Slot.Name))
            .ForMember(dest => dest.StartAt, opt => opt.MapFrom(src => src.Slot.StartAt))
            .ForMember(dest => dest.EndAt, opt => opt.MapFrom(src => src.Slot.EndAt))

            .ForMember(dest => dest.DentistTreatmentName,
                opt => opt.MapFrom(src => src.DentistTreatmentName))
            .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.BusinessService.Name))
            .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.BusinessService.ServiceType))
            .ForMember(dest => dest.UserTreatmentName, opt => opt.MapFrom(src => src.UserTreatmentName));
        //Check-in
        CreateMap<StaffUpdateAppointmentStatusResponse, Appointment>().ReverseMap();
    }
}