using CleanArchitecture.Core.Domain.Entities.Enums;
using System;

namespace CleanArchitecture.Core.Application.Features.Orders.Queries.GetAllSalesOrder
{
    public class SalesOrderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDepracted { get; set; }
        public SalesOrderTypeEnum SalesOrderType { get; set; }
    }
}