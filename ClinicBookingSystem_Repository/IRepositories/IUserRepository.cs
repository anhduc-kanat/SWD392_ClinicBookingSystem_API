using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<IEnumerable<User>> GetAllUser();
    Task<User> GetUserById(int id);
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(User user);
    Task<User> DeleteUser(int id);

    Task<User> GetUserByPhone(string phone);

    
}