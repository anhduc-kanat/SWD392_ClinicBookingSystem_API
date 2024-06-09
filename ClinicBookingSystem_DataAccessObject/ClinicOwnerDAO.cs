using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAcessObject.DBContext;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using Microsoft.EntityFrameworkCore;
namespace ClinicBookingSystem_DataAccessObject;

public class ClinicOwnerDAO : BaseDAO<User>
{
    private readonly ClinicBookingSystemContext _context;

    public ClinicOwnerDAO(ClinicBookingSystemContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetClinicOwnerByRole()
    {
        return await _context.Users.Include(u => u.Role).Where(u => u.Role.Name == "CLINIC_OWNER").ToListAsync();
    }
    
}    
