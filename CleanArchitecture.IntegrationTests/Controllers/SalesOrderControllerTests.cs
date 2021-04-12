using CleanArchitecture.API;
using CleanArchitecture.Core.Application.Features.Orders.Queries.GetAllSalesOrder;
using CleanArchitecture.IntegrationTests.SeedWork;
using Newtonsoft.Json;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.IntegrationTests.Controllers
{
    public class SalesOrderControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public SalesOrderControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task SalesOrderController_GetAllAsync_IsSuccess()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/salesOrder");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var salesOrderList = JsonConvert.DeserializeObject<List<SalesOrderDto>>(responseString);
            salesOrderList.ShouldBeOfType<List<SalesOrderDto>>();
            salesOrderList.Count().ShouldBeGreaterThan(0);
            salesOrderList.Count().ShouldBe(1);
            salesOrderList.ElementAt(0).Name.ShouldBe("so1");
        }
    }
}
