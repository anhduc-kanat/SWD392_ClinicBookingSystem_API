using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_Service.Models.Request.Payment;

public class CreatePaymentTransactionRequest
{
    public int AppointmentId { get; set; }
    public List<AppointmentBusinessService>? AppointmentBusinessServices { get; set; }
    public TransactionType Type { get; set; }
}