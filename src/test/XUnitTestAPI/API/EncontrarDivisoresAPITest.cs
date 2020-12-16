using EncontrarDivisores.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace XUnitTestAPI.API
{
    public class EncontrarDivisoresAPITest
    {
        private readonly HttpClient _client;
        public EncontrarDivisoresAPITest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET", 32)]
        public async Task EncontrarDivisoresGetTest(string method, int numeroBase)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), string.Format("api/encontrarDivisores/retornarDivisores?numeroBase={0}", numeroBase));

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
