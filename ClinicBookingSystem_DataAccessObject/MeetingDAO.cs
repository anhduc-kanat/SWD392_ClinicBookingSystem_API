using ClinicBookingSystem_BusinessObject.Entities;
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
}