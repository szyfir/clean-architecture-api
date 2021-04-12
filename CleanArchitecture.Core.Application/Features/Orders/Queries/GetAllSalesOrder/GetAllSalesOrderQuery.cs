using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Application.Features.Orders.Queries.GetAllSalesOrder
{
    public class GetAllSalesOrderQuery : IRequest<IEnumerable<SalesOrderDto>>
    {
    }
}
