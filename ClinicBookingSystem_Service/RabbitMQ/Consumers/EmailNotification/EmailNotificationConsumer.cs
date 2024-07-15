using ClinicBookingSystem_Service.Notification.EmailNotification;
using ClinicBookingSystem_Service.Notification.EmailNotification.IService;
using ClinicBookingSystem_Service.RabbitMQ.Events.EmailNotification;
using MassTransit;

namespace ClinicBookingSystem_Service.RabbitMQ.Consumers.EmailNotification;

public class EmailNotificationConsumer : IConsumer<EmailNotificationEvent>
{
    private readonly IEmailService _emailService;
    public EmailNotificationConsumer(IEmailService emailService)
    {
        _emailService = emailService;
    }
    public async Task Consume(ConsumeContext<EmailNotificationEvent> context)
    {
        var message = context.Message;
        NotificationEmailModel emailNotificationEvent = new NotificationEmailModel
        {
            To = message.To,
            Subject = message.Subject,
            Title = message.Title,
            Body = message.Body
        };
        await _emailService.SendEmailAsync<EmailNotificationEvent>(message, message.ViewUrl);
    }
}