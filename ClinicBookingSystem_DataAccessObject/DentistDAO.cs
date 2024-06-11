using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_DataAccessObject
{
    public class DentistDAO : BaseDAO<User>
    {
        private readonly ClinicBookingSystemContext _context;
        public DentistDAO(ClinicBookingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetDentistsByRole()
        {
            return await _context.Users.Include(u => u.Role).Where(u => u.Role.Name == "DENTIST").ToListAsync();
        }

        public async Task<IEnumerable<User>> GetDentistByService(string serviceName)
        {

            return await _context.Users.Include(s => s.Services)
                .Where(a => a.Services.Any(b=>b.Name.ToLower() == serviceName.ToLower()) && a.Role.Name =="DENTIST")
                .ToListAsync();
        }
        
    }

}
