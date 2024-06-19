using ClinicBookingSystem_BusinessObject.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClinicBookingSystem_BusinessObject.Entities
{
    public class BaseEntities : IBaseEntities
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
