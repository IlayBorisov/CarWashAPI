namespace BusinessLogic.Email.Interface;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body, bool updateNotificationStatus);
}