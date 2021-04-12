using CleanArchitecture.Core.Application.Contracts.Persistance;
using CleanArchitecture.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Features.Orders.Commands.AddSalesOrder
{
    public class AddSalesOrderCommandHandler : IRequestHandler<AddSalesOrderCommand>
    {
        private readonly IAsyncRepository<SalesOrder> _salesOrderRepository;

        public AddSalesOrderCommandHandler(IAsyncRepository<SalesOrder> salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<Unit> Handle(AddSalesOrderCommand request, CancellationToken cancellationToken)
        {
            var salesOrder = SalesOrder.Create(request.Name);
            await _salesOrderRepository.AddAsync(salesOrder);
            return Unit.Value;
        }
    }
}
