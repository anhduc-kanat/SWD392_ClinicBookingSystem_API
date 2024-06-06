using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Models.Request.Customer
{
    public class UpdateCustomerRequest
    {
        public string? PhoneNumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? DateOfBirth { get; set; }

        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
