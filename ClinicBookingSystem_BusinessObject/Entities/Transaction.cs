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
        public string Name { get; set; }
        public string? Description { get; set; }
        public TransactionStatus Status { get; set; }
        public bool? IsPay { get; set; }
        public DateTime? PayAt { get; set; }
        public string? QrLink {get; set; }
        public string? BankName { get; set; }
        //Appointment
        public Appointment Appointment { get; set; }
        //Billing
        public Billing? Billing { get; set; }
    }
}
