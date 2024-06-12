namespace ClinicBookingSystem_Service.Models.Request.Transaction;

public class CreateTransactionRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? QrLink { get; set; }
    public string? BankName { get; set; }
    public IEnumerable<int>? OrderId { get; set; }
}