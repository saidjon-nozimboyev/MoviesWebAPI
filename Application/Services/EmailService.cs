using Application.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;

namespace Application.Services;

public class EmailService(IConfiguration configuration) : IEmailService
{
    private readonly IConfiguration _config = configuration.GetSection("Email");

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config["EmailAddress"]));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.CompressedRichText) { Text = body};

        var smtp = new SmtpClient();
        await smtp.ConnectAsync(_config["Host"], 587, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_config["EmailAddress"], _config["Password"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
