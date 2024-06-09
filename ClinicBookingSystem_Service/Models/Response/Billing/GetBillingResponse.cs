using ClinicBookingSystem_Service.Models.Response.Transaction;

namespace ClinicBookingSystem_Service.Models.Response.Billing;

public class GetBillingResponse
{
    public int Id { get; set; }
    public long Total { get; set; }
    public string Description { get; set; }
    public ICollection<GetTransactionResponse> Transactions { get; set; }
    
}