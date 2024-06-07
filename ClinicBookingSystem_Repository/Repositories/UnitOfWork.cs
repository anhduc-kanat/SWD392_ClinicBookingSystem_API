using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_DataAcessObject.DBContext;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
{
    private readonly ClinicBookingSystemContext _dbContext;
    private readonly IUserRepository _userRepository;
    private readonly ISlotRepository _slotRepository;
    private readonly IApplicationRepository _applicationRepository;
    private readonly IDentistRepository _dentistRepository;
    private readonly IStaffRepository _staffRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ITokenRepository _tokenRepository;

    public UnitOfWork(ClinicBookingSystemContext dbContext,
        IUserRepository userRepository,
        ICustomerRepository customerRepository,
        IRoleRepository roleRepository,
        ITokenRepository tokenRepository,
        IApplicationRepository applicationRepository,
        IDentistRepository dentistRepository,
        IStaffRepository staffRepository,
        ISlotRepository slotRepository
        ) : base(dbContext) 
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
        _dentistRepository = dentistRepository;
        _roleRepository = roleRepository;
        _staffRepository = staffRepository;
        _applicationRepository = applicationRepository;
        _customerRepository = customerRepository;
        _tokenRepository = tokenRepository;
        _slotRepository = slotRepository;
    }
    public IUserRepository UserRepository => _userRepository;
    public IDentistRepository DentistRepository => _dentistRepository;
    public IRoleRepository RoleRepository => _roleRepository;
    public IStaffRepository StaffRepository => _staffRepository;
    public IApplicationRepository ApplicationRepository => _applicationRepository;

    public ICustomerRepository CustomerRepository => _customerRepository;

    public ITokenRepository TokenRepository => _tokenRepository;
    public ISlotRepository SlotRepository => _slotRepository;

}