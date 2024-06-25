using System.ComponentModel;

namespace ClinicBookingSystem_BusinessObject.Enums;

public enum AppointmentBusinessServiceStatus
{
    [Description("Done")]
    Done = 1,
    [Description("Undone")]
    Undone = 2,
}