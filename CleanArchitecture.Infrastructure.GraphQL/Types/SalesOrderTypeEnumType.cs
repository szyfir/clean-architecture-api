using CleanArchitecture.Core.Domain.Entities.Enums;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.GraphQL.Types
{
    public class SalesOrderTypeEnumType : EnumerationGraphType<SalesOrderTypeEnum>
    {
        public SalesOrderTypeEnumType()
        {
            Name = "Type";
        }
    }
}
