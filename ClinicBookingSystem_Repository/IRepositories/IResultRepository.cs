﻿using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface IResultRepository : IBaseRepository<Result>
{
    Task<Result> GetResultByAppointmentId(int appointmentId);
    Task<Result> GetResultById(int resultId);
}