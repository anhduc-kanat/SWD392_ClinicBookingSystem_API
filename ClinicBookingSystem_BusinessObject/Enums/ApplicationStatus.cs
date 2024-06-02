using System.ComponentModel;

namespace ClinicBookingSystem_BusinessObject.Enums;

public enum ApplicationStatus
{
    [Description("In Progress")]
    Pending = 2,
    [Description("Approved")]
    Approved = 1,
    [Description("Rejected")]
    Rejected = 0
}