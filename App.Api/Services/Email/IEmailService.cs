namespace App.Api.Services.Email;

public interface IEmailService
{
    public Task SendAsync(string to, string subject, string htmlBody);
}