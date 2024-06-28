using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject;

public class UserDAO : BaseDAO<User>
{
    private readonly ClinicBookingSystemContext _dbContext;

    public UserDAO(ClinicBookingSystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetUserByPhone(string phone)
    {
        User user = await _dbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(a => a.PhoneNumber == phone);
        return user;
    }

    public async Task<User> GetMyProfile(int userId)
    {
        return await GetQueryableAsync()
            .Include(p => p.Role)
            .Include(p => p.Specifications)
            .Include(p => p.BusinessServices)
            .FirstOrDefaultAsync(p => p.Id == userId);
    }

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*public async Task<IEnumerable<User>> GetAllUser()
    {
        IEnumerable<User> users =  await _dbContext.Users.ToListAsync();
        return users;
    }
    public async Task<User> GetUserById(int id)
    {
        User user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }
    public async Task<User> CreateUser(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return user;
    }
    public async Task<User> UpdateUser(User user)
    {
        _dbContext.Users.Update(user);
        return user;
    }
    public async Task<User> DeleteUser(int id)
    {
        User user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        _dbContext.Users.Remove(user);
        return user;
    }*/

    
}