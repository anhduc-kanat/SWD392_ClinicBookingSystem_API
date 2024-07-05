﻿using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_BusinessObject.Enums;
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


        public async Task<User> CreateNewDentist(User user, List<BusinessService>services)
        {

              await _context.Users.AddAsync(user);
              user.BusinessServices = services;
              return user;
        }


        public async Task<IEnumerable<User>> GetDentistsByRole()
        {
            return await GetQueryableAsync()
                .Include(u => u.Role)
                .Where(u => u.Role.Name == "DENTIST")
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetDentistByService(string serviceName)
        {

            return await GetQueryableAsync()
                .Include(s => s.BusinessServices)
                .Where(a => a.BusinessServices.Any(b=>b.Name.ToLower() == serviceName.ToLower()) && a.Role.Name =="DENTIST")
                .ToListAsync();
        }
        public async Task<IEnumerable<DateTime>> GetAllFreeDaysOfDentist(int id)
        {
            var targetStatus = AppointmentStatus.Scheduled;
            var today = DateTime.Today;
            var endDay = today.AddMonths(2);

            IEnumerable<DateTime> allDays = Enumerable.Range(0, (endDay - today).Days + 1)
                                .Select(d => today.AddDays(d))
                                .ToList();
            int slot = await _context.Slots.CountAsync();

            var bookedDates = await _context.Appointments
                .Where(a => a.Users.Any(u => u.Id == id) && a.Date >= today && a.Date <= endDay && a.Status == targetStatus )
                .GroupBy(a => a.Date.Date)
                .Where(g => g.Count() >= slot)
                .Select(a => a.Key)
                .ToListAsync();

            return bookedDates;
        }

        public async Task<IEnumerable<User>> GetDentistsByServiceId(int serviceId)
        {
            return await GetQueryableAsync()
                .Include(s => s.BusinessServices)
                .Where(a => a.BusinessServices.Any(p => p.Id == serviceId && a.Role.Name =="DENTIST"))
                .ToListAsync();
        }
    }

}
