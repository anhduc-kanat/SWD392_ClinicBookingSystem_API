using System.ComponentModel;

namespace ClinicBookingSystem_BusinessObject.Enums;

public enum SlotStatus
{
    [Description("Booked")]
    Booked = 1,
    [Description("Available")]
    Available = 0,
}