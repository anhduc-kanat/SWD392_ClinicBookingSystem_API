namespace ClinicBookingSystem_DataAccessObject.IBaseDAO;

public interface IBaseDAO<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IQueryable<T>> GetQueryableAsync();
}