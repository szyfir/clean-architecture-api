
using CleanArchitecture.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Application.Contracts.Persistance
{
    public interface ISalesOrderRepsository : IAsyncRepository<SalesOrder>
    {
        IEnumerable<SalesOrder> GetDepractedSalesOrderList();
    }
}
