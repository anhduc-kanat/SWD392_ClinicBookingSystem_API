﻿using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class Meeting : BaseEntities
{
    public DateTime? Date { get; set; }
    public int? MeetingAttempt { get; set; }
    public MeetingStatus? Status { get; set; }
    public int? DentistId { get; set; }
    public string? DentistName { get; set; }
    
    
    //Appointment Service
    public AppointmentBusinessService? AppointmentBusinessService { get; set; }
}