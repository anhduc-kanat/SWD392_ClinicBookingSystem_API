using System.Net.Mail;
using ClinicBookingSystem_Service.Common.Utils;
using ClinicBookingSystem_Service.Notification.EmailNotification.IService;
using Microsoft.Extensions.Configuration;

namespace ClinicBookingSystem_Service.Notification.EmailNotification.Service;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly RazorViewToStringRenderer _razorViewToStringRenderer;
    private readonly IConfiguration _configuration;
    
    public EmailService(SmtpClient smtpClient, 
        RazorViewToStringRenderer razorViewToStringRenderer,
        IConfiguration configuration)
    {
        _smtpClient = smtpClient;
        _razorViewToStringRenderer = razorViewToStringRenderer;
        _configuration = configuration;
    }

    public async Task SendEmailAsync<T>(T emailModel, string pageUrl) where T : IEmailModel
    {
        var username = _configuration["Email:Username"];
        var body = await _razorViewToStringRenderer.RenderViewToStringAsync(pageUrl, emailModel);

        MailMessage mailMessage = new MailMessage
        {
            From = new MailAddress(username ?? throw new InvalidOperationException()),
            Subject = emailModel.Subject,
            Body = body,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(emailModel.To);
        await _smtpClient.SendMailAsync(mailMessage);
    }
}