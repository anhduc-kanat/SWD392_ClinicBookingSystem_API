namespace ClinicBookingSystem_Repository.IBaseRepository;

public interface IBaseUnitOfWork
{
    Task<int> SaveChangesAsync();
    void Dispose();
}