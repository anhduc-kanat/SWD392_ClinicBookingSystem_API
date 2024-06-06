using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_DataAcessObject.DBContext;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly UserDAO _userDAO;
    public UserRepository(UserDAO userDAO) : base(userDAO)
    {
        _userDAO = userDAO;
    }
    public async Task<IEnumerable<User>> GetAllUser()
    {
        return await _userDAO.GetAllUser();
    }
    public async Task<User> GetUserById(int id)
    {
        return await _userDAO.GetUserById(id);
    }
    public async Task<User> CreateUser(User user)
    {
        return await _userDAO.CreateUser(user);
    }
    public async Task<User> UpdateUser(User user)
    {
        return await _userDAO.UpdateUser(user);
    }
    public async Task<User> DeleteUser(int id)
    {
        return await _userDAO.DeleteUser(id);
    }

    public async Task<User> GetUserByPhone(string phone)
    {
        return await _userDAO.GetUserByPhone(phone);
    }
}