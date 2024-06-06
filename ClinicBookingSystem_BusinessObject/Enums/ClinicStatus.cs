using System.ComponentModel;

namespace ClinicBookingSystem_BusinessObject.Enums;

public enum ClinicStatus
{
    [Description("UnderMaintenance")]
    Maintaining = 2,
    [Description("ShutDown")]
    ShutDown = 3,
    [Description("Opening")]
    Opening = 1,
    [Description("Closed")]
    Closed = 0,
}