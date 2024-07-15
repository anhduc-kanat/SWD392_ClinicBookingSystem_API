namespace ClinicBookingSystem_Service.Notification.EmailNotification;

public class NotificationEmailModel : IEmailModel
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}