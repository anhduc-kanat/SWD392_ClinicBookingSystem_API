using System.Collections;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject;

public class AppointmentBusinessServiceDAO : BaseDAO<AppointmentBusinessService>
{
    private readonly ClinicBookingSystemContext _dbContext;
    public AppointmentBusinessServiceDAO(ClinicBookingSystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<AppointmentBusinessService>> GetAppointmentBusinessServiceByAppointmentId(int appointmentId)
    {
        return await GetQueryableAsync()
            .Include(p => p.BusinessService)
            .Include(p => p.Meetings)
            .Where(p => p.Appointment.Id == appointmentId)
            .ToListAsync();
    }
    public async Task<IEnumerable<AppointmentBusinessService>> GetUnPaidAppointmentBusinessServiceByAppointmentId(int appointmentId)
    {
        return await GetQueryableAsync()
            .Include(p => p.BusinessService)
            .Include(p => p.Meetings)
            .Where(p => p.IsPaid == false)
            .Where(p => p.Appointment.Id == appointmentId)
            .ToListAsync();
    }
    public async Task<AppointmentBusinessService> GetAppointmentBusinessServiceByDentistInThatTask(int dentistId, int appointmentBusinessServiceId)
    {
        return await GetQueryableAsync()
            .Include(p => p.BusinessService)
            .Include(p => p.Meetings)
            .Where(p => p.DentistId == dentistId && p.Id == appointmentBusinessServiceId)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<AppointmentBusinessService>> GetUnPaidAppointmentBusiness(int appointmentId)
    {
        return await GetQueryableAsync()
            .Include(p => p.Meetings)
            .Include(p => p.Appointment)
            .Where(p => p.Appointment.Id == appointmentId && p.Appointment.IsClinicalExamPaid == true)
            .Where(p => p.IsPaid == false)
            .Where(p => p.Appointment.IsFullyPaid == false || p.Appointment.IsFullyPaid == null)
            .ToListAsync();
    }
}