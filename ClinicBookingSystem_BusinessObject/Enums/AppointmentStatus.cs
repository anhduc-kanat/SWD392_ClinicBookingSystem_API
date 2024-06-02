using System.ComponentModel;

namespace ClinicBookingSystem_BusinessObject.Enums;

public enum AppointmentStatus
{
    [Description("Scheduled")]
    Scheduled = 3,
    [Description("OnGoing")]
    OnGoing = 2,
    [Description("Done")]
    Done = 1,
    [Description("Cancelled")]
    Cancelled = 0
}