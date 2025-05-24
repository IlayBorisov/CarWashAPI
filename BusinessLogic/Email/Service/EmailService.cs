using BusinessLogic.Email.Interface;
using DataAccess.Repositories.User;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace BusinessLogic.Email.Service;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public EmailService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task SendEmailAsync(string to, string subject, string body, bool updateNotificationStatus = false)
    {
        try
        {
            var emailSettings = _configuration.GetSection("EmailSettings");
        
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(
                emailSettings["FromName"], 
                emailSettings["FromAddress"]));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;

            message.Body = new TextPart("html") { Text = body };

            using var client = new SmtpClient();
        
            // Таймаут подключения 10 секунд
            await client.ConnectAsync(
                emailSettings["SmtpHost"], 
                int.Parse(emailSettings["SmtpPort"]), 
                false, 
                cancellationToken: new CancellationTokenSource(10000).Token);

            if (updateNotificationStatus)
            {
                await _userRepository.MarkNotificationSentAsync(to);
            }
            
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            Console.WriteLine($"Error sending email: {ex.Message}");
            throw; 
        }
    }
}