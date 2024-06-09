using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
{
    private readonly UserProfileDAO _userProfileDAO;
    public UserProfileRepository(UserProfileDAO userProfileDAO) : base(userProfileDAO)
    {
        _userProfileDAO = userProfileDAO;
    }
}