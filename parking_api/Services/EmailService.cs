using parking_api.Models.SettingModels;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace parking_api.Services;

public interface IEmailService
{
    Task<bool> SendEmail(string to, string firstName, string subject, string htmlBody);
}

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;
    private readonly SmtpClient _smtpClient;

    public EmailService(IOptions<EmailSettings> emailSettings, SmtpClient smtpClient)
    {
        _emailSettings = emailSettings.Value;
        _smtpClient = smtpClient;
    }

    public async Task<bool> SendEmail(string to, string firstName, string subject, string htmlBody)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Username));
        email.To.Add(new MailboxAddress(firstName, to));
        email.Subject = subject;

        var builder = new BodyBuilder
        {
            // Set the HTML body
            HtmlBody = htmlBody
        };

        email.Body = builder.ToMessageBody();

        await _smtpClient.SendAsync(email);
        await _smtpClient.DisconnectAsync(true);

        return true;
    }
}
