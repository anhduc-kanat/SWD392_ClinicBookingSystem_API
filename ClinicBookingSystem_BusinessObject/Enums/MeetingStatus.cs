using System.ComponentModel;

namespace ClinicBookingSystem_BusinessObject.Enums;

public enum MeetingStatus
{
    [Description("Undone")]
    Undone = 0,
    [Description("Done")]
    Done = 1,
}