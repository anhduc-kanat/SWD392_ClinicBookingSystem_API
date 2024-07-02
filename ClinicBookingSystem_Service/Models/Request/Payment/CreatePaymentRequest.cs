using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_Service.Models.Request.Payment;

public class CreatePaymentRequest
{
    public TransactionType Type { get; set; }
    public long ServicePrice { get; set; }
    public int AppointmentId { get; set; }
    public List<AppointmentBusinessService>? AppointmentBusinessServices { get; set; }
    public string? UserIpAddress { get; set; }
    public string? UserAccountName { get; set; }
    public string? UserAccountPhone { get; set; }
}