using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_DataAcessObject.DBContext;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
{
    private readonly ClinicBookingSystemContext _dbContext;
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ITokenRepository _tokenRepository;
    public UnitOfWork(ClinicBookingSystemContext dbContext,
        IUserRepository userRepository, ICustomerRepository customerRepository
        , IRoleRepository roleRepository
        , ITokenRepository tokenRepository



    ) : base(dbContext)
    {
        _userRepository = userRepository;
        _dbContext = dbContext;
        _customerRepository = customerRepository;
        _roleRepository = roleRepository;
        _tokenRepository = tokenRepository;
    }
    public IUserRepository UserRepository => _userRepository;

    public ICustomerRepository CustomerRepository => _customerRepository;

    public IRoleRepository RoleRepository => _roleRepository;

    public ITokenRepository TokenRepository => _tokenRepository;
}