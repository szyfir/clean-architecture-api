using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.GraphQL.Types
{
    public class SalesOrderInputType : InputObjectGraphType
    {
        public SalesOrderInputType()
        {
            Name = "salesOrderInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
