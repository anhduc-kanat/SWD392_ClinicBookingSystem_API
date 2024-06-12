using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_BusinessObject.Entities
{
    public class Billing : BaseEntities
    {
        public string? Name { get; set; }
        public long? Total { get; set; }
        public string? Description { get; set; }
        //User
        public User? User { get; set; }
    }
}
