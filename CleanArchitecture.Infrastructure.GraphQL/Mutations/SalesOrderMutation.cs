using CleanArchitecture.Core.Application.Contracts.Persistance;
using CleanArchitecture.Core.Application.Features.Orders.Commands.AddSalesOrder;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Infrastructure.GraphQL.Types;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.GraphQL.Mutations
{
    public class SalesOrderMutation : ObjectGraphType
    {
        public SalesOrderMutation(ISalesOrderRepsository salesOrderRepsository)
        {
            FieldAsync<SalesOrderType>("createSalesOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<SalesOrderInputType>> { Name = "salesOrder" }
                ),
                resolve: async context =>
                {
                    var salesOrderInputType = context.GetArgument<AddSalesOrderCommand>("salesOrder");
                    var salesOrder = SalesOrder.Create(salesOrderInputType.Name);
                    await salesOrderRepsository.AddAsync(salesOrder);
                    return salesOrder;
                });
        }
    }
}
