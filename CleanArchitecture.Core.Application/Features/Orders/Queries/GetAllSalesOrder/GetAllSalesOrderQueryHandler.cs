using AutoMapper;
using CleanArchitecture.Core.Application.Contracts.Persistance;
using CleanArchitecture.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Features.Orders.Queries.GetAllSalesOrder
{
    public class GetAllSalesOrderQueryHandler : IRequestHandler<GetAllSalesOrderQuery, IEnumerable<SalesOrderDto>>
    {
        private readonly IAsyncRepository<SalesOrder> _salesOrderRepsository;
        private readonly IMapper _mapper;

        public GetAllSalesOrderQueryHandler(IAsyncRepository<SalesOrder> salesOrderRepsository, IMapper mapper)
        {
            _salesOrderRepsository = salesOrderRepsository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalesOrderDto>> Handle(GetAllSalesOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await _salesOrderRepsository.GetAllAsync();
            return await Task.FromResult(_mapper.Map<IEnumerable<SalesOrderDto>>(result));
        }
    }
}
