using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
{
    private readonly UserProfileDAO _relativeDAO;
    public UserProfileRepository(UserProfileDAO relativeDAO) : base(relativeDAO)
    {
        _relativeDAO = relativeDAO;
    }
}