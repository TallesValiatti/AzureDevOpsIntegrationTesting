using System;
using App.IntegrationTests.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace App.IntegrationTests
{
	public abstract class BaseTestingController<T> :
        IAsyncLifetime,
        IClassFixture<CustomWebApplicationFactory<T>> where T : class

    {
        protected readonly HttpClient _client;
        protected readonly CustomWebApplicationFactory<T> _factory;
        private IServiceScope? _serviceScope;

        public BaseTestingController(
            CustomWebApplicationFactory<T> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        public W GetRequiredService<W>() where W : class
        {
            if (_serviceScope is null)
            {
                var scope = _factory.Services.CreateScope();
                _serviceScope = scope;
            }

            return _serviceScope.ServiceProvider.GetRequiredService<W>();
        }

        public async Task ReinitializeEmailServerForTestsAsync()
        {
            var localEmailServerService = GetRequiredService<ILocalEmailServerService>();
            await localEmailServerService.DeletAllAsync();
        }

        public async Task DisposeAsync()
        {
            await ReinitializeEmailServerForTestsAsync();
            _serviceScope?.Dispose();
        }

        public async Task InitializeAsync()
        {
            await ReinitializeEmailServerForTestsAsync();
        }
    }
}

