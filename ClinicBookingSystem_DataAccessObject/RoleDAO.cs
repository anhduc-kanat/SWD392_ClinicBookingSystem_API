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
    public class RoleDAO : BaseDAO<Role>
    {
        private readonly ClinicBookingSystemContext _dbContext;
        public RoleDAO(ClinicBookingSystemContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Role> GetRoleByName(string roleName)
        {
            Role role = await _dbContext.Roles.FirstOrDefaultAsync(a=> a.Name == roleName);
            return role;
        }
    }
}
