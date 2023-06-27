using App.Api.Models;
using App.Api.Services.Email;
using App.Api.Services.Template;

namespace App.Api.Services.ApplicationEmail;

// This is a facade service
public class ApplicationEmailService : IApplicationEmailService
{
    private readonly IEmailService _emailService;
    private readonly ITemplateService _templateService;
    
    public ApplicationEmailService(IEmailService emailService, ITemplateService templateService)
    {
        _emailService = emailService;
        _templateService = templateService;
    }

    public async Task SendUserCreatedEmail(string to, User user)
    {
        var subject = this.CreateEmailSubject(user);
        var htmlBody = this.CreateEmailBody(user);

        await _emailService.SendAsync(to, subject, htmlBody);
    }

    private string CreateEmailBody(User user)
    {
        var template = Path.Combine("Services", "Template", "Templates","UserCreatedTemplate.cshtml");

        return _templateService.GetTemplateAsString(template, new
            {
                Title = $"New User - {user.Name}",
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                CreatedAt = DateTime.UtcNow.ToString("dd/MM/yyyy - hh:mm")
            });
    }

    private string CreateEmailSubject(User user)
    {
        return $"New User - {user.Name}";
    }
}