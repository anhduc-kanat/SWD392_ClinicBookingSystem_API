using System.ComponentModel;

namespace ClinicBookingSystem_BusinessObject.Enums;

public enum TransactionType
{
    [Description("BookingFee")]
    BookingType = 1,
    [Description("ServiceFee")]
    ServiceType= 2,
}