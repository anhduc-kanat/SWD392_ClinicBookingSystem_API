namespace ClinicBookingSystem_Service.Models.Request.Payment;

public class OrderRequest
{
    public string OrderId { get; set; }
    public long TotalPrice { get; set; }
}