using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class SalaryRepository : BaseRepository<Salary>, ISalaryRepository
{
    private readonly SalaryDAO _salaryDao;
    public SalaryRepository(SalaryDAO salaryDao) : base(salaryDao)
    {
        _salaryDao = salaryDao;
    }

    public async Task<Salary> CreateSalary(Salary salary)
    {
        return await _salaryDao.CreateSalary(salary);
    }

    public async Task<Salary> DeleteSalary(int id)
    {
        return await _salaryDao.DeleteSalary(id);
    }

    public async Task<IEnumerable<Salary>> GetAllSalaries()
    {
        return await _salaryDao.GetAllSalary();
    }

    public async Task<Salary> GetSalaryById(int id)
    {
        return await _salaryDao.GetSalaryById(id);
    }

    public async Task<Salary> UpdateSalary(Salary salary)
    {
        return await _salaryDao.UpdateSalary(salary);
    }
}