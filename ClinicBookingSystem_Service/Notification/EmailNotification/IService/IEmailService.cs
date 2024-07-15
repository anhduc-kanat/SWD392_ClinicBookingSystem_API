namespace ClinicBookingSystem_Service.Notification.EmailNotification.IService;

public interface IEmailService
{
    Task SendEmailAsync<T>(T emailModel, string pageUrl) where T : IEmailModel;
    
}