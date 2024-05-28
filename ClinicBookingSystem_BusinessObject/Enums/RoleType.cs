using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_BusinessObject.Enums
{
    public enum RoleType
    {
        [Description("Clinic Owner")]
        ClinicOwner = 0,
        [Description("Staff")]
        Staff = 1,
        [Description("Dentist")]
        Dentist = 2,
        [Description("Customer")]
        Customer = 3,
    }
}
