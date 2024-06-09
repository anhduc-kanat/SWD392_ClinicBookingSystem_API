using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Models.Response.Salary
{
    public class SalaryResponse
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int amount { get; set; }
    }
}
