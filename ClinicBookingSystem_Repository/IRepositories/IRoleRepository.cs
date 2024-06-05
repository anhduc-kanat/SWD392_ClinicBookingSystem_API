using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Repository.IRepositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetRoleByName(string roleName);
    }
}
