using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface IUnitOfWork : IBaseUnitOfWork
{
    IUserRepository UserRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IRoleRepository RoleRepository { get; }
    ITokenRepository TokenRepository { get; }
}