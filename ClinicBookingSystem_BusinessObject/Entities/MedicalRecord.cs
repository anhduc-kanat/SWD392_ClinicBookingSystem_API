using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_BusinessObject.Entities
{
    public class MedicalRecord : BaseEntities
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; }

        //Result
        public ICollection<Result>? Results { get; set; }
        //User
        public User? User { get; set; }
    }
}
