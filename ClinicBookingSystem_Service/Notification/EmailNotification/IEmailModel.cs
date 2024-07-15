namespace ClinicBookingSystem_Service.Notification.EmailNotification;

public interface IEmailModel
{
    string To { get; set; }
    string Subject { get; set; }
    string Title { get; set; }
    string Body { get; set; }
}