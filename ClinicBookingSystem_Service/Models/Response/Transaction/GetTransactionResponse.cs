using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_Service.Models.Response.Transaction;

public class GetTransactionResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public TransactionStatus Status { get; set; }
    public bool IsPaid { get; set; }
    public string QrLink { get; set; }
    public string BankName { get; set; }
    public DateTime PayAt { get; set; }
}