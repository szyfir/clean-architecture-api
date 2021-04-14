using CleanArchitecture.Core.Application.Contracts.Persistance;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistance.Repositories
{
    public class SalesOrderRepository : BasicRepository<SalesOrder>, ISalesOrderRepsository
    {
        public SalesOrderRepository(CleanArchitectureDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<SalesOrder>> GetDepractedSalesOrderList()
        {
            throw new NotImplementedException();
        }

        public async Task SetSalesOrderTypeAsync(Guid salesOrderId, SalesOrderTypeEnum salesOrderType)
        {
            var context = await _dbContext.SalesOrders.FirstOrDefaultAsync(w => w.Id == salesOrderId);
            context.SetType(salesOrderType);
            await _dbContext.SaveChangesAsync();
        }
    }
}
