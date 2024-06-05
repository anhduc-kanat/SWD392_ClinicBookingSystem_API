using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_DataAcessObject.DBContext;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
{
    private readonly ClinicBookingSystemContext _dbContext;
    private readonly IUserRepository _userRepository;
    private readonly IDentistRepository _dentistRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IStaffRepository _staffRepository;
    public UnitOfWork(ClinicBookingSystemContext dbContext,
        IUserRepository userRepository,
        IDentistRepository dentistRepository,
        IRoleRepository roleRepository,
        IStaffRepository staffRepository
    ) : base(dbContext)
    {
        _userRepository = userRepository;
        _dentistRepository = dentistRepository;
        _roleRepository = roleRepository;
        _staffRepository = staffRepository;
        _dbContext = dbContext;
    }
    public IUserRepository UserRepository => _userRepository;

    public IDentistRepository DentistRepository => _dentistRepository;

    public IRoleRepository RoleRepository => _roleRepository;

    public IStaffRepository StaffRepository => _staffRepository;
}