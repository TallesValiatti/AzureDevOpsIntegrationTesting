using System.Text;
using System.Text.Json;
using App.Api.Models;
using App.IntegrationTests.Services;
using FluentAssertions;

namespace App.IntegrationTests;

public class UserControllerTests : BaseTestingController<Program>
{
    public UserControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task Post_WithValidUser_ShouldReturnOkResultAndSendEmail()
    {
        // Arrange
        var localEmailServerService = GetRequiredService<ILocalEmailServerService>();

        var url = "/User";
        var user = new User("Talles Valiatti", 29);

        var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

        var expectedEmailSubject = $"New User - {user.Name}";
        var expectedEmailCount = 1;

        // Act
        var response = await _client.PostAsync(url, content);

        // Assert
        var emailsInfo = await localEmailServerService.GetEmailsInfos();
        response.EnsureSuccessStatusCode();

        emailsInfo.Total.Should().Be(expectedEmailCount);
        emailsInfo.Subjects.Should().AllBe(expectedEmailSubject);
    }
}