using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_DataAcessObject.DBContext;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
{
    private readonly ClinicBookingSystemContext _dbContext;
    private readonly IUserRepository _userRepository;
    public UnitOfWork(ClinicBookingSystemContext dbContext,
        IUserRepository userRepository
    ) : base(dbContext)
    {
        _userRepository = userRepository;
        _dbContext = dbContext;
    }
    public IUserRepository UserRepository => _userRepository;
                
}