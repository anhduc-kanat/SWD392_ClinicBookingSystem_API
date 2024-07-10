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
    Future = 4,
    [Description("In Queue")]
    InQueue = 5,
    [Description("Waiting for Dentist")]
    WaitingDentist = 6,
    [Description("In Treatment")]
    InTreatment = 7,
}