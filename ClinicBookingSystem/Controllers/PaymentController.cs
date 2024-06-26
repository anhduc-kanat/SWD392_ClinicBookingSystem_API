using System.Net;
using System.Net.Sockets;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem.Common;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;
[ApiController]
[Route("api/payment")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly GetUserIpAddress _getUserIpAddress;
    
    public PaymentController(IPaymentService paymentService,
        GetUserIpAddress getUserIpAddress)
    {
        _paymentService = paymentService;
        _getUserIpAddress = getUserIpAddress;
    }
    
    [HttpGet]
    [Route("get-vnpay-payment-url")]
    public string GetVnPayUrl(int appointmentId)
    {
        string ipAddress = _getUserIpAddress.GetIpAddress();

        return ipAddress;
        /*return _paymentService.CreateVnPayPaymentUrl(1);*/
    }
}