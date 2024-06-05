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
        
    }

}
