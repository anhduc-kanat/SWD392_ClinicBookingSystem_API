using System.ComponentModel;

namespace ClinicBookingSystem_BusinessObject.Enums;

public enum AppointmentStatus
{
    [Description("Rejected")]
    Rejected = 4,
    [Description("Scheduled")]
    Scheduled = 3,
    [Description("OnGoing")]
    OnGoing = 2,
    [Description("Done")]
    Done = 1,
    [Description("Cancelled")]
    Cancelled = 0,
    [Description("Pending")]
    Pending = 5,
    [Description("OnTreatment")]
    OnTreatment = 6,
    [Description("Queued")]
    Queued = 7,
    [Description("Waiting")]
    Waiting = 8,
}