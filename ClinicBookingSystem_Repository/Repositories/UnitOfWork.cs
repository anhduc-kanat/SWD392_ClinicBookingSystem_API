using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_DataAcessObject.DBContext;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
{
    private readonly ClinicBookingSystemContext _dbContext;
    private readonly IUserRepository _userRepository;
    private readonly IApplicationRepository _applicationRepository;
    public UnitOfWork(ClinicBookingSystemContext dbContext,
        IUserRepository userRepository,
        IApplicationRepository applicationRepository
    ) : base(dbContext)
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
        _applicationRepository = applicationRepository;
    }
    public IUserRepository UserRepository => _userRepository;
    public IApplicationRepository ApplicationRepository => _applicationRepository;
}