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
        public async Task ItShouldConvertDigitToNumeral(
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
    }
}
