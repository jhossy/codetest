using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTest.Tests.IntegrationTests
{
    public class DigitsControllerIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public DigitsControllerIntegrationTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(4, "IV")]
        [InlineData(9, "IX")]
        [InlineData(90, "XC")]
        [InlineData(900, "CM")]
        [InlineData(1903, "MCMIII")]
        [InlineData(1997, "MCMXCVII")]
        [InlineData(4000, "MMMM")]
        public async Task ItShouldConvertDigitToNumeral(
            int digit,
            string expected)
        {
            //Arrange

            //Act
            HttpResponseMessage response = await _client.GetAsync($"/api/digits?input={digit}");
            response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            Assert.True(responseString == expected);
        }

        [Theory]
        [InlineData(-1, "")]
        [InlineData(0, "")]
        public async Task ItShouldHandleEdgeCasesGracefully(
            int digit,
            string expected)
        {
            //Arrange

            //Act
            HttpResponseMessage response = await _client.GetAsync($"/api/digits?input={digit}");
            
            string responseString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
            Assert.True(responseString == expected);
        }
    }
}
