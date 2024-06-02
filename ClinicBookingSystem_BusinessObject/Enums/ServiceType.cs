using System.ComponentModel;

namespace ClinicBookingSystem_BusinessObject.Enums;

public enum ServiceType
{
    [Description("Examination")]
    Examination = 1,
    [Description("Treatment")]
    Treatment = 2,
}