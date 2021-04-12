using AutoMapper;
using CleanArchitecture.Core.Application.Contracts.Persistance;
using CleanArchitecture.Core.Application.Features.Orders.Queries.GetAllSalesOrder;
using CleanArchitecture.Core.Application.Profiles;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistance.Repositories;
using CleanArchitecture.UnitTests.Mocks;
using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.UnitTests.SalesOrders.Queries
{
    public class GetAllSalesOrderQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<SalesOrder>> _mockSalesOrderRepository;

        public GetAllSalesOrderQueryHandlerTests()
        {
            _mockSalesOrderRepository = RepositoryMock.GetSalesOrderRepositoryMock();
            var configurationProvider = new MapperConfiguration(w =>
              {
                  w.AddProfile<MappingProfile>();
              });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetAllSalesOrderQueryTest()
        {
            var handler = new GetAllSalesOrderQueryHandler(_mockSalesOrderRepository.Object, _mapper);
            var result = await handler.Handle(new GetAllSalesOrderQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<SalesOrderDto>>();
            result.Count().ShouldBe(4);
        }
    }
}
