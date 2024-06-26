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
            .Where(p => p.Appointment.Id == appointmentId)
            .ToListAsync();
    }
}