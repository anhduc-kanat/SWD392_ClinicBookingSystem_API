using ClinicBookingSystem_BusinessObject.IEntities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.BaseRepositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntities
{
    private readonly BaseDAO<T> _baseDao;
    public BaseRepository(BaseDAO<T> baseDao)
    {
        _baseDao = baseDao;
    }
    public async Task<IQueryable<T>> GetQueryableAsync()
    {
        return await Task.FromResult(_baseDao.GetQueryableAsync());
    }
    public async Task<IQueryable<T>> GetAllAsync()
    {
        return await Task.FromResult(_baseDao.GetAllAsync());
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _baseDao.GetByIdAsync(id);
    }
    public async Task<T> AddAsync(T entity)
    {
        return await _baseDao.AddAsync(entity);
    }
    public async Task<T> UpdateAsync(T entity)
    {
        return await _baseDao.UpdateAsync(entity);
    }
    public async Task<T> DeleteAsync(T entity)
    {
        return await _baseDao.DeleteAsync(entity);
    }
    public async Task<IEnumerable<T>> GetAllAsyncPagination(int pageNumber, int pageSize)
    {
        return await _baseDao.GetAllAsyncPagination(pageNumber, pageSize);
    }
}