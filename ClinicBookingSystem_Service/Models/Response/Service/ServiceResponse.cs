using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Models.Response.Service
{
    public class ServiceResponse
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ExpectedDurationInMinute { get; set; }

        public ServiceType ServiceType { get; set; }

        //Specification
        public int? SpecificationId { get; set; }
    }
}
