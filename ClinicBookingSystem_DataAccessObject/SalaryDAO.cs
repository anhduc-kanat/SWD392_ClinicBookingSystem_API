using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject;

public class SalaryDAO : BaseDAO<Salary>
{
    private readonly ClinicBookingSystemContext _context;
    public SalaryDAO(ClinicBookingSystemContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Salary>> GetAllSalary()
    {
        return await _context.Salaries.ToListAsync();
    }
    //
    public async Task<Salary> GetSalaryById(int id)
    {
        var salary = await _context.Salaries.FindAsync(id);

        return salary;
    }
    //
    public async Task<Salary> CreateSalary(Salary salary)
    {
        _context.Salaries.Add(salary);
        await _context.SaveChangesAsync();

        return salary;
    }

    public async Task<Salary> UpdateSalary(Salary salary)
    {
        var existingSalary = await GetSalaryById(salary.Id);
        _context.Salaries.Update(existingSalary);
        await _context.SaveChangesAsync();
        return existingSalary;
    }
    //
    public async Task<Salary> DeleteSalary(int id)
    {
        var existingSalary = await GetSalaryById(id);
        _context.Salaries.Remove(existingSalary);
        await _context.SaveChangesAsync();
        return existingSalary;
    }
}