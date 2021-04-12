using CleanArchitecture.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Domain.Entities
{
    public class SalesOrder : AuditableEntity
    {
        public Guid Id { get; }
        public string Name { get; }
        public bool IsDepracted { get; }

        private SalesOrder()
        {
        }

        private SalesOrder(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsDepracted = false;
        }

        public static SalesOrder Create(string name) => new SalesOrder(name);
    }
}
