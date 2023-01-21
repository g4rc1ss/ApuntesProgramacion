using System;
using System.Net.Http;
using AspMvcTesting.Configuration;

namespace AspMvcTesting
{
    public class TestConfigurationToFixture
    {
        public HttpClient Client { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        public TestConfigurationToFixture()
        {
            var webHost = new WebApplicationFactoryWeatherForecast();
            ServiceProvider = webHost.Services;
            Client = webHost.CreateClient();
        }
    }
}
