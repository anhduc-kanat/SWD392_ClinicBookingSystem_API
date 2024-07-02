﻿using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Models.Request.Service
{
    public class CreateServiceRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ExpectedDurationInMinute { get; set; }
        [DefaultValue("false")]
        public bool? IsPreBooking { get; set; }
        public long Price { get; set; }
        public ServiceType? ServiceType { get; set; }

    }
}
