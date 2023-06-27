using App.IntegrationTests.Services.Models;

namespace App.IntegrationTests.Services
{
    public interface ILocalEmailServerService
    {
        public Task<EmailsInfo> GetEmailsInfos();
        public Task DeletAllAsync();
    }
}