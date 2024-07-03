using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject;

public class ResultDAO : BaseDAO<Result>
{
    private readonly ClinicBookingSystemContext _dbContext;
    public ResultDAO(ClinicBookingSystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result> GetResultByAppointmentId(int appointmentId)
    {
        return await GetQueryableAsync()
            .Include(p => p.Medicines)
            .Include(p => p.UserProfile)
            .Include(p => p.Notes)
            .FirstOrDefaultAsync(p => p.AppointmentId == appointmentId);
    }
    public async Task<Result> GetResultById(int resultId)
    {
        return await GetQueryableAsync()
            .Include(p => p.Medicines)
            .Include(p => p.UserProfile)
            .Include(p => p.Notes)
            .FirstOrDefaultAsync(p => p.Id == resultId);
    }
}