﻿using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface INoteRepository : IBaseRepository<Note>
{
    Task<Note> GetNoteByAppointmentId(int appointmentId);
}