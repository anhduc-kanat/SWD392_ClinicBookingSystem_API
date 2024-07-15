using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject;

public class MeetingDAO : BaseDAO<Meeting>
{
    private readonly ClinicBookingSystemContext _dbContext;
    public MeetingDAO(ClinicBookingSystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Meeting>> GetMeetingByToday(DateTime date)
    {
        return await GetQueryableAsync()
            .Where(x => x.Date!.Value.Year == date.Year &&
                        x.Date.Value.Month == date.Month &&
                        x.Date.Value.Day == date.Day)
            .ToListAsync();
    }
    public async Task<Meeting> GetMeetingById(int id)
    {
        return await GetQueryableAsync()
            .Include(p => p.AppointmentBusinessService)
            .ThenInclude(p => p.Appointment)
            .Include(p => p.AppointmentBusinessService)
            .ThenInclude(p => p.BusinessService)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }
    
    public async Task<Meeting> GetTreatmentMeetingQueue(int appointmentId, DateTime date)
    {
        return await GetQueryableAsync()
            .Include(p => p.AppointmentBusinessService)
            .ThenInclude(p => p.Appointment)
            .Where(x => x.AppointmentBusinessService.Appointment.Id == appointmentId)
            .Where(x => x.Date.Value.Year == date.Year &&
                        x.Date.Value.Month == date.Month &&
                        x.Date.Value.Day == date.Day)
            .Where(p => p.AppointmentBusinessService.ServiceType == ServiceType.Treatment)
            .Where(p => p.Status == MeetingStatus.CheckIn)
            .Where(p => p.AppointmentBusinessService.Appointment.IsFullyPaid == true)
            .FirstOrDefaultAsync();
    }

    public async Task<Meeting> GetTreatmentMeetingQueueByMeetingId(int meetingId, DateTime date)
    {
        return await GetQueryableAsync()
            .Include(p => p.AppointmentBusinessService)
            .ThenInclude(p => p.Appointment)
            .Where(x => x.Id == meetingId)
            .Where(x => x.Date.Value.Year == date.Year &&
                        x.Date.Value.Month == date.Month &&
                        x.Date.Value.Day == date.Day)
            .Where(p => p.AppointmentBusinessService.ServiceType == ServiceType.Treatment)
            .Where(p => p.Status == MeetingStatus.CheckIn)
            .Where(p => p.AppointmentBusinessService.Appointment.IsFullyPaid == true)
            .FirstOrDefaultAsync();
    }

}