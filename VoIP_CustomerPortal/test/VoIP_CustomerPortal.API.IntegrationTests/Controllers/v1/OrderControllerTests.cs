using Newtonsoft.Json;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoIP_CustomerPortal.API.IntegrationTests.Base;
using VoIP_CustomerPortal.Application.Features.Orders.GetOrdersForMonth;
using VoIP_CustomerPortal.Application.Responses;
using Xunit;

namespace VoIP_CustomerPortal.API.IntegrationTests.Controllers.v1
{
    [Collection("Database")]
    public class OrderControllerTests : IClassFixture<WebApplicationFactory>
    {
        private readonly WebApplicationFactory _factory;
        public OrderControllerTests(WebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_OrdersForMonth_ReturnsSuccessResult()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/v1/order?date=2021-08-26&page=1&size=3");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PagedResponse<IEnumerable<OrdersForMonthDto>>>(responseString);

            result.Data.ShouldBeOfType<List<OrdersForMonthDto>>();
            result.Data.ShouldNotBeEmpty();
        }
    }
}
