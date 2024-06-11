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

            return await _context.Users.Include(s => s.BusinessServices)
                .Where(a => a.BusinessServices.Any(b=>b.Name.ToLower() == serviceName.ToLower()) && a.Role.Name =="DENTIST")
                .ToListAsync();
        }
        public async Task<IEnumerable<string>> GetAllFreeDaysOfDentist(string phone)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var endDay = today.AddMonths(2);
            var allDay = Enumerable.Range(0, (endDay.DayNumber - today.DayNumber) + 1)
                .Select(d => today.AddDays(d))
                .ToList();
/*
            var bookedDate = await _context.Appointments
                .Where(a => a.Users.PhoneNumber == phone && a.App)*/
            return null;
        }
      
    }

}
