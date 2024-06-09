using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject;

public class ServiceDAO : BaseDAO<Service>
{
    private readonly ClinicBookingSystemContext _context;
    public ServiceDAO(ClinicBookingSystemContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Service>> GetAllServices()
    {
        return await _context.Services.ToListAsync();
    }
    //
    public async Task<Service> GetServiceById(int id)
    {
        var service = await _context.Services.FindAsync(id);

        return service;
    }
    //
    public async Task<Service> CreateService(Service service)
    {
        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        return service;
    }

    public async Task<Service> UpdateService(Service service)
    {
        var existingService = await GetServiceById(service.Id);
        _context.Services.Update(existingService);
        await _context.SaveChangesAsync();
        return existingService;
    }
    //
    public async Task<Service> DeleteService(int id)
    {
        var existingService = await GetServiceById(id);
        _context.Services.Remove(existingService);
        await _context.SaveChangesAsync();
        return existingService;
    }
}