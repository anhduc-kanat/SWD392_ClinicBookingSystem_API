using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_BusinessObject.Entities
{
    public class Role : BaseEntities
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        //User
        public ICollection<User>? Users { get; set; }
        //Claim
        public ICollection<Claim>? Claims { get; set; }
        
    }
}
