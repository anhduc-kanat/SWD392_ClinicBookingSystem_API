using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface IServiceRepository : IBaseRepository<Service>
{
    public Task<IEnumerable<Service>> GetAllServices();
    public Task<Service> GetServiceById(int id);
    public Task<Service> CreateService(Service service);
    public Task<Service> UpdateService(Service service);
    public Task<Service> DeleteService(int id);
}