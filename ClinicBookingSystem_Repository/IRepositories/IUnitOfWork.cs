using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface IUnitOfWork : IBaseUnitOfWork
{
    IUserRepository UserRepository { get; }
    IApplicationRepository ApplicationRepository { get; }
    IDentistRepository DentistRepository { get; }
    IRoleRepository RoleRepository { get; }
    IStaffRepository StaffRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    ITokenRepository TokenRepository { get; }
    ISlotRepository SlotRepository { get; }
}