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
    private readonly IClinicOwnerRepository _clinicOwnerRepository;
    public UnitOfWork(ClinicBookingSystemContext dbContext,
        ISlotRepository slotRepository,
        IUserRepository userRepository,
        IClinicOwnerRepository clinicOwnerRepository
        ) : base(dbContext) 
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
        _slotRepository = slotRepository;
        _clinicOwnerRepository = clinicOwnerRepository;
    }

    public ISlotRepository SlotRepository => _slotRepository;
    public IUserRepository UserRepository => _userRepository;
    public IClinicOwnerRepository ClinicOwnerRepository => _clinicOwnerRepository;
    

}