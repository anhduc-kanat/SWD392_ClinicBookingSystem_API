namespace ClinicBookingSystem_Service.Models.Request.Payment;

public class OrderRequest
{
    public int appointmentId { get; set; }
    public string OrderId { get; set; }
    public long TotalPrice { get; set; }
}