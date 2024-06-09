using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface IUnitOfWork : IBaseUnitOfWork
{
    IUserRepository UserRepository { get; }
    ISlotRepository SlotRepository { get; }
    IClinicOwnerRepository ClinicOwnerRepository { get; }
}