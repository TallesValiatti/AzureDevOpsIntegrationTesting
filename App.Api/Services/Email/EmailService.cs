using System.Net;
using System.Net.Mail;

namespace App.Api.Services.Email;
class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendAsync(string to, string subject, string htmlBody)
    {
        var host = _configuration.GetSection("Application:StmpHost").Value;
        var userName = _configuration.GetSection("Application:StmpUserName").Value;
        var password = _configuration.GetSection("Application:StmpPassword").Value;
        var from = _configuration.GetSection("Application:StmpSenderAddress").Value;
        var port = Convert.ToInt32(_configuration.GetSection("Application:StmpPort").Value);
        var enableSsl = Convert.ToBoolean(_configuration.GetSection("Application:StmpEnableSsl").Value);

        var smtpClient = new SmtpClient(host)
        {
            Port = port,
            Credentials = new NetworkCredential(userName, password),
            EnableSsl = enableSsl,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(from!),
            Subject = subject,
            Body = htmlBody,
            IsBodyHtml = true,
        };

        mailMessage.To.Add(to);

        await smtpClient.SendMailAsync(mailMessage);
    }
}