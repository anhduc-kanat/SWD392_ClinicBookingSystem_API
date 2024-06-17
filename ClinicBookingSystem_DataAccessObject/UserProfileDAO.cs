using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject;

public class UserProfileDAO : BaseDAO<UserProfile>
{
    private readonly ClinicBookingSystemContext _dbContext;
    public UserProfileDAO(ClinicBookingSystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<IEnumerable<UserProfile>> GetUserProfilesByUser(string phone)
    {
        return await _dbContext.UserProfiles.Include(u => u.User)
            .Where(u => u.User.PhoneNumber == phone)
            .ToListAsync();
    }

    public async Task<IEnumerable<UserProfile>> GetUserProfileById(int userId)
    {
        return await GetQueryableAsync()
            .Where(u => u.User.Id == userId)
            .ToListAsync();
    }
    
}