using ClinicBookingSystem_BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_BusinessObject.Entities
{
    public class Transaction : BaseEntities
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PaymentStatus Status { get; set; }
        public bool IsPay { get; set; }
        public TimeSpan PayAt { get; set; }
        public string QrLink {get; set; }
        public string BankName { get; set; }

        //Order
        public ICollection<Order> Orders { get; set; }
        //Billing
        public Billing Billing { get; set; }
    }
}
