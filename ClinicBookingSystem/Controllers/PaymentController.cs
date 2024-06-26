using ClinicBookingSystem_Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;
[ApiController]
[Route("api/payment")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    
    [HttpGet]
    [Route("get-vnpay-payment-url")]
    public string GetVnPayUrl(int appointmentId)
    {
        string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

        return ipAddress;
        /*
        return _paymentService.CreateVnPayPaymentUrl(1);
    */
    }
}