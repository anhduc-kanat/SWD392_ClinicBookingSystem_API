using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Models.Request.Authen
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public string? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
        public string? Email { get; set; }




    }

}
