using ClinicBookingSystem_DataAcessObject.DBContext;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.BaseRepositories;

public class BaseUnitOfWork : IBaseUnitOfWork
{
    private readonly ClinicBookingSystemContext _dbContext;
    public BaseUnitOfWork(ClinicBookingSystemContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}