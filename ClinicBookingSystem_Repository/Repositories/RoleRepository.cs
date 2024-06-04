using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Repository.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly RoleDAO _roleDAO;
        public RoleRepository(RoleDAO roleDAO) : base(roleDAO)
        {
            _roleDAO = roleDAO;
        }

        public async Task<Role> GetRoleByName(string roleName)
        {
            return await _roleDAO.GetRoleByName(roleName);
        }
    }
}
