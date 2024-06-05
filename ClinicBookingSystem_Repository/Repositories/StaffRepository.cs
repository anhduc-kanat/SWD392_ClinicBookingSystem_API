using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Repository.Repositories
{
    public class StaffRepository : BaseRepository<User>, IStaffRepository
    {
        private readonly StaffDAO _staffDAO;
        public StaffRepository(StaffDAO staffDAO) : base(staffDAO)
        {
            _staffDAO = staffDAO;
        }

        public async Task<IEnumerable<User>> GetStaffsByRole()
        {
            return await _staffDAO.GetStaffsByRole();
        }
    }
}
