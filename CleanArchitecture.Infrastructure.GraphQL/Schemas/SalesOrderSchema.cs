using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using CleanArchitecture.Infrastructure.GraphQL.Queries;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Infrastructure.GraphQL.Mutations;

namespace CleanArchitecture.Infrastructure.GraphQL.Schemas
{
    public class SalesOrderSchema : Schema
    {
        public SalesOrderSchema(IServiceProvider services) : base(services)
        {
            Query = services.GetRequiredService<SalesOrderQuery>();
            Mutation = services.GetRequiredService<SalesOrderMutation>();
        }
    }
}
