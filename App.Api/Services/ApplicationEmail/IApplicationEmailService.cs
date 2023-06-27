using App.Api.Models;

namespace App.Api.Services.ApplicationEmail;

public interface IApplicationEmailService
{
    public Task SendUserCreatedEmail(string to, User user);
}