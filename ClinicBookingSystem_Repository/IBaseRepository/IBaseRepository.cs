using ClinicBookingSystem_DataAccessObject.IBaseDAO;

namespace ClinicBookingSystem_Repository.IBaseRepository;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<IQueryable> GetQueryableAsync();
}