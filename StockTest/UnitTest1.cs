using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net.Http;
using FluentAssertions;
using System.Net;


namespace StockTest
{
    public class StockControllerTest : IClassFixture<WebApplicationFactory<StockApi.Startup>>
    {
        public HttpClient client {get; set;}

        public StockControllerTest(WebApplicationFactory<StockApi.Startup> fixture)
        {
            client = fixture.CreateClient();
        }

        [Fact]
        public async Task GetStocks()
        {
            var response = await client.GetAsync("/api/stocks");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetBrokers()
        {
            var response = await client.GetAsync("/api/brokers");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetExchanges()
        {
            var response = await client.GetAsync("/api/exchanges");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
