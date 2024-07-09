using System.ComponentModel;

namespace ClinicBookingSystem_BusinessObject.Enums;

public enum MeetingStatus
{
    [Description("Done")]
    Done = 1,
    [Description("Check In")]
    CheckIn = 2,
    [Description("Waiting")]
    Waiting = 3,
    [Description("Future")]
    Future = 4
}