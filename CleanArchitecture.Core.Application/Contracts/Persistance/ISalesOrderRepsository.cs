
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Contracts.Persistance
{
    public interface ISalesOrderRepsository : IAsyncRepository<SalesOrder>
    {
        Task<IEnumerable<SalesOrder>> GetDepractedSalesOrderList();
        Task SetSalesOrderTypeAsync(Guid salesOrderId, SalesOrderTypeEnum salesOrderType);
    }
}
