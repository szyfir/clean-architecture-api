using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Entities.Enums;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.GraphQL.Types
{
    public class SalesOrderType : ObjectGraphType<SalesOrder>
    {
        public SalesOrderType()
        {
            Field(w => w.Id).Description("Specified identificator");
            Field(w => w.Name);
            Field<SalesOrderTypeEnumType>("Type");
        }
    }
}
