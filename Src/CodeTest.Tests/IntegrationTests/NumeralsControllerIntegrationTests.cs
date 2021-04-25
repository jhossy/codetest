using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CodeTest.Tests.IntegrationTests
{
    public class NumeralsControllerIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public NumeralsControllerIntegrationTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Theory]
        [InlineData("I", "1")]
        [InlineData("IV", "4")]
        [InlineData("IX", "9")]
        [InlineData("MCMIII", "1903")]
        [InlineData("MCMXCVII", "1997")]
        [InlineData("MMMM", "4000")]
        public async Task ItShouldConvertNumeralToDigit(
            string numeral,
            string expected) 
        {
            //Arrange

            //Act
            HttpResponseMessage response = await _client.GetAsync($"/api/numerals?input={numeral}");
            response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            Assert.True(responseString == expected);
        }

        [Theory]
        [InlineData("A", "Invalid input")]
        [InlineData("a", "Invalid input")]
        [InlineData("!#&(/=", "Invalid input")]
        [InlineData("-1", "Invalid input")]
        [InlineData("0", "Invalid input")]
        public async Task ItShouldHandleEdgeCasesGracefully(
            string numeral,
            string expected)
        {
            //Arrange

            //Act
            HttpResponseMessage response = await _client.GetAsync($"/api/numerals?input={numeral}");

            string responseString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
            Assert.True(responseString == expected);
        }
    }
}
