using System.Net;
using System.Net.Sockets;
using ClinicBookingSystem_Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;
[ApiController]
[Route("api/payment")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IWebHostEnvironment _env;
    public PaymentController(IPaymentService paymentService, IWebHostEnvironment env)
    {
        _paymentService = paymentService;
        _env = env;
    }
    
    [HttpGet]
    [Route("get-vnpay-payment-url")]
    public string GetVnPayUrl(int appointmentId)
    {
        /*string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

        // Check if the request was forwarded by a proxy
        if (HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
        {
            ipAddress = HttpContext.Request.Headers["X-Forwarded-For"].ToString().Split(',')[0];
        }

        return ipAddress;*/
        
        
        /*string hostName = Dns.GetHostName(); // get container id
        string ipAddress = Dns.GetHostEntry(hostName).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();

        return ipAddress;*/
        string ipAddress;

        if (_env.IsDevelopment())
        {
            // Get local network IP address
            string hostName = Dns.GetHostName();
            ipAddress = Dns.GetHostEntry(hostName).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
        }
        else
        {
            // Get remote IP address
            ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        }

        return ipAddress;
        /*return _paymentService.CreateVnPayPaymentUrl(1);*/
    }
}