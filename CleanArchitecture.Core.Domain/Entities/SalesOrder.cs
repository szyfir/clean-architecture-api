using CleanArchitecture.Core.Domain.Common;
using CleanArchitecture.Core.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Domain.Entities
{
    public class SalesOrder : AuditableEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDepracted { get; private set; }
        public SalesOrderType SalesOrderType { get; private set; }

        private SalesOrder()
        {
        }

        private SalesOrder(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsDepracted = false;
            SalesOrderType = SalesOrderType.Normal;
        }

        public static SalesOrder Create(string name) => new SalesOrder(name);

        public void SetType(SalesOrderType salesOrderType)
        {
            SalesOrderType = salesOrderType;
        }
    }
}
