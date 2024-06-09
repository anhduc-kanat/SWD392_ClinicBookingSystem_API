namespace ClinicBookingSystem_Service.Models.Request.Billing;

public class CreateBillingRequest
{
    public string name { get; set;  }
    public long? total { get; set; }
    public string? description { get; set; }
}