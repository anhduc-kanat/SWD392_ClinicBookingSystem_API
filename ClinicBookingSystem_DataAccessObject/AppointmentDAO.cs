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
        return await GetAllAsync()
            .Include(p => p.Slot)
            .Include(p => p.Users)
            .ThenInclude(p => p.Role)
            .Include(p => p.Users)
            .ThenInclude(p => p.UserProfiles)
            .ToListAsync();
    }
    public async Task<Appointment> GetAppointmentById(int Id)
    {
        return await GetQueryableAsync()
            .Include(p => p.Slot)
            .Include(p => p.Users)
            .ThenInclude(p => p.Role)
            .Include(p => p.Users)
            .ThenInclude(p => p.UserProfiles)
            .FirstOrDefaultAsync(p => p.Id == Id);
    }
    public async Task<IEnumerable<Appointment>> GetAllAppointmentPagination(int pageNumber, int pageSize)
    {
        return await GetQueryableAsync()
            .Include(p => p.Slot)
            .Include(p => p.Users)
            .ThenInclude(p => p.Role)
            .Include(p => p.Users)
            .ThenInclude(p => p.UserProfiles)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<IEnumerable<Appointment>> GetAppointmentByUserId(int userId, int pageNumber, int pageSize)
    {
        return await GetQueryableAsync()
            .Include(p => p.Slot)
            .Include(p => p.Users)
            .ThenInclude(p => p.Role)
            .Include(p => p.Users)
            .ThenInclude(p => p.UserProfiles)
            .Where(p => p.Users.Any(p => p.Id == userId))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> CountUserAppointment(int userId)
    {
        return await GetQueryableAsync()
            .Include(p => p.Slot)
            .Include(p => p.Users)
            .ThenInclude(p => p.Role)
            .Where(p => p.Users.Any(p => p.Id == userId))
            .CountAsync();
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentByDayPagination(int pageNumber, int pageSize, DateOnly date)
    {
        return await GetQueryableAsync()
            .Include(p => p.Slot)
            .Include(p => p.Users)
            .ThenInclude(p => p.Role)
            .Include(p => p.Users)
            .ThenInclude(p => p.UserProfiles)
            .Where(p => p.Date.Year == date.Year && p.Date.Month == date.Month && p.Date.Day == date.Day)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}