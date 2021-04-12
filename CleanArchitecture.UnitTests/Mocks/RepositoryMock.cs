using CleanArchitecture.Core.Application.Contracts.Persistance;
using CleanArchitecture.Core.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.UnitTests.Mocks
{
    public class RepositoryMock
    {
        public static Mock<IAsyncRepository<SalesOrder>> GetSalesOrderRepositoryMock()
        {
            var salesOrderList = new List<SalesOrder>()
            {
                SalesOrder.Create("so1"),
                SalesOrder.Create("so2"),
                SalesOrder.Create("so3"),
                SalesOrder.Create("so4")
            };

            //Imperative style of implementation
            var mockSalesOrdeRepository = new Mock<IAsyncRepository<SalesOrder>>();
            //GetAllAsync
            mockSalesOrdeRepository.Setup(w => w.GetAllAsync()).ReturnsAsync(salesOrderList);
            //AddAsync
            mockSalesOrdeRepository.Setup(w => w.AddAsync(It.IsAny<SalesOrder>())).Returns((SalesOrder salesOrder) =>
              {
                  salesOrderList.Add(salesOrder);
                  return Task.CompletedTask;
              });

            return mockSalesOrdeRepository;
        }
    }
}
