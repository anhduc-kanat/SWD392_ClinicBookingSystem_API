using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_BusinessObject.Entities
{
    public class Order : BaseEntities
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public long? Amount { get; set; }
        //User
        public User? User { get; set; }
        //Services
        public ICollection<BusinessService>? BusinessServices { get; set; }
        //Transaction
        public Transaction? Transaction { get; set; }
    }
}
