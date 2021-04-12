using CleanArchitecture.Core.Application.Contracts.Persistance;
using CleanArchitecture.Infrastructure.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.GraphQL.Queries
{
    public class SalesOrderQuery : ObjectGraphType
    {
        public SalesOrderQuery(ISalesOrderRepsository salesOrderRepsository)
        {
            FieldAsync<ListGraphType<SalesOrderType>>("salesOrders", resolve: (async w => await salesOrderRepsository.GetAllAsync()));
        }
    }
}
