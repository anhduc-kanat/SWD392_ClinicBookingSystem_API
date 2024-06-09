using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface ISalaryRepository : IBaseRepository<Salary>
{
    public Task<IEnumerable<Salary>> GetAllSalaries();
    public Task<Salary> GetSalaryById(int id);
    public Task<Salary> CreateSalary(Salary salary);
    public Task<Salary> UpdateSalary(Salary salary);
    public Task<Salary> DeleteSalary(int id);
}