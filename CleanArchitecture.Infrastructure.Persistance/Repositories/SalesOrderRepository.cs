using CleanArchitecture.Core.Application.Contracts.Persistance;
using CleanArchitecture.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Persistance.Repositories
{
    public class SalesOrderRepository : BasicRepository<SalesOrder>, ISalesOrderRepsository
    {
        public SalesOrderRepository(CleanArchitectureDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<SalesOrder> GetDepractedSalesOrderList()
        {
            throw new NotImplementedException();
        }
    }
}
