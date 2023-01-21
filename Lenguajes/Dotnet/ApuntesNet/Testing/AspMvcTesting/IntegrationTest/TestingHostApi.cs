using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace AspMvcTesting.IntegrationTest
{
    [Collection("Identificador")]
    public class TestingHostApi
    {
        private readonly TestConfigurationToFixture _fixture;

        public TestingHostApi(TestConfigurationToFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task When_Get_All_ApiWeatherForecast_Then_Return_ValueAsync()
        {
            var response = await _fixture.Client.GetStringAsync("WeatherForecast");

            Assert.NotNull(response);
            Assert.True(response is string);
        }
    }
}
