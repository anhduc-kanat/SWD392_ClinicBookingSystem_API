using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    private readonly ServiceDAO _serviceDAO;
    public ServiceRepository(ServiceDAO serviceDAO) : base(serviceDAO)
    {
        _serviceDAO = serviceDAO;
    }

    public async Task<Service> CreateService(Service service)
    {
        return await _serviceDAO.CreateService(service);
    }

    public async Task<Service> DeleteService(int id)
    {
        return await _serviceDAO.DeleteService(id);
    }

    public async Task<IEnumerable<Service>> GetAllServices()
    {
        return await _serviceDAO.GetAllServices();
    }

    public async Task<Service> GetServiceById(int id)
    {
        return await _serviceDAO.GetServiceById(id);
    }

    public async Task<Service> UpdateService(Service service)
    {
        return await _serviceDAO.UpdateService(service);
    }
}