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

        
    }
}
