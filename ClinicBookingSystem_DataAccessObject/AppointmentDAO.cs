using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject;

public class AppointmentDAO : BaseDAO<Appointment>
{
    private readonly ClinicBookingSystemContext _dbContext;
    public AppointmentDAO(ClinicBookingSystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointment()
    {
        return await _dbContext.Appointments.Include(p => p.Slot)
            .Include(p => p.Users)
            .ThenInclude(p => p.Role)
            .Include(p => p.BusinessService)
            .ToListAsync();
    }
    
}