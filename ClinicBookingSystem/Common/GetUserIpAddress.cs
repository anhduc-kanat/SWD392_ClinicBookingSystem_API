using System.Net;
using System.Net.Sockets;

namespace ClinicBookingSystem.Common;

public class GetUserIpAddress
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IWebHostEnvironment _env;

    public GetUserIpAddress(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
    {
        _httpContextAccessor = httpContextAccessor;
        _env = env;
    }
    public string GetIpAddress()
    {
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
            ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                ipAddress = _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].ToString().Split(',')[0];
            }
        }

        return ipAddress;
    }
}