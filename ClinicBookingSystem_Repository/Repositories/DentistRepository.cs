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
    public class DentistRepository : BaseRepository<User>, IDentistRepository
    {
        private readonly DentistDAO _dentistDAO;

        public DentistRepository(DentistDAO dentistDAO) : base(dentistDAO)
        {
            _dentistDAO = dentistDAO;
        }

        public async Task<IEnumerable<DateTime>> GetAvailableDate(int id)
        {
            return await _dentistDAO.GetAllFreeDaysOfDentist(id);
        }

        public async Task<IEnumerable<User>> GetDentistsByRole()
        {
            return await _dentistDAO.GetDentistsByRole();
        }

        public async Task<IEnumerable<User>> GetDentistsByService(string serviceName)
        {
            return await _dentistDAO.GetDentistByService(serviceName);

        }
    }
}
