using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_Service.Models.Response.Transaction;

public class CreateTransactionResponse
{
    public TransactionType Type { get; set; }
    public long ServicePrice { get; set; }
    public int AppointmentId { get; set; }
    public string UserIpAddress { get; set; }
    public string UserAccountName { get; set; }
    public string UserAccountPhone { get; set; }
}