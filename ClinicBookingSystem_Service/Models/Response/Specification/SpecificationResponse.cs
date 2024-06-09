using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Models.Response.Specification
{
    public class SpecificationResponse
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public string? ImageUrl { get; set; }
        public string? AwaredAt { get; set; }

        //User
        public int? UserId { get; set; }
    }
}
