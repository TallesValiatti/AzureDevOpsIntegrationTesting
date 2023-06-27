using System.Text.Json;
using App.IntegrationTests.Services.Models;

namespace App.IntegrationTests.Services
{
    public class LocalEmailServerService : ILocalEmailServerService
    {
        private readonly HttpClient _client;

        public LocalEmailServerService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:8025");
        }

        public async Task<EmailsInfo> GetEmailsInfos()
        {
            var response = await this.GetAllEmailsAsync();

            return new EmailsInfo
            {
                Total = response.Total,
                Subjects = response.Items!
                    .SelectMany(x => x.Content!.Headers!.Subject!)
            };
        }


        public async Task DeletAllAsync()
        {
            await _client.DeleteAsync("/api/v1/messages");
        }

        private async Task<Response> GetAllEmailsAsync()
        {
            var resultString = await _client.GetStringAsync("/api/v2/messages?limit=50");
            var result = JsonSerializer.Deserialize<Response>(resultString)!;
            return result;
        }        
    }
}

