using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Models.Request.Slot
{
    public class UpdateSlotRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? StartAtHour { get; set; }
        public int? StartAtMinute { get; set; }
        public int? EndAtHour { get; set; }
        public int? EndAtMinute { get; set; }
    }
}
