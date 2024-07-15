using ClinicBookingSystem_Service.Notification.EmailNotification;

namespace ClinicBookingSystem_Service.RabbitMQ.Events.EmailNotification;

public class EmailNotificationEvent : IEmailModel
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string ViewUrl { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}