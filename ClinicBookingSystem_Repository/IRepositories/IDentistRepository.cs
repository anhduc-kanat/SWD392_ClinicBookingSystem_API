using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Repository.IRepositories
{
    public interface IDentistRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetDentistsByRole();
        Task<IEnumerable<User>> GetDentistsByService(string serviceName);

    }
}
