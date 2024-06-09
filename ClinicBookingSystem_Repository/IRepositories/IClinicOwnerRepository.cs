using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface IClinicOwnerRepository : IBaseRepository<User>
{
    Task<IEnumerable<User>> GetClinicOwnerByRole();
}