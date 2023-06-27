using App.Api.Models;
using App.Api.Services.ApplicationEmail;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IApplicationEmailService _applicationEmailService;

    public UserController(IApplicationEmailService applicationEmailService)
    {
        _applicationEmailService = applicationEmailService;
    }

    [HttpPost(Name = "AddUser")]
    public async Task<IActionResult> Post(User user)
    {
        // ...
        // Do some things
        // ...

        // Send email to admin
        var adminEmail = "test@tests.com";
        await _applicationEmailService.SendUserCreatedEmail(adminEmail, user);

        return Ok();
    }
}
