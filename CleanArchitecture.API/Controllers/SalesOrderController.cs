using CleanArchitecture.Core.Application.Features.Orders.Commands.AddSalesOrder;
using CleanArchitecture.Core.Application.Features.Orders.Queries.GetAllSalesOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<SalesOrderDto>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var salesOrderList = await _mediator.Send(new GetAllSalesOrderQuery());
            return Ok(salesOrderList);
        }

        [HttpPost("{name}")]
        public async Task<IActionResult> AddAsync([FromRoute] string name)
        {
            await _mediator.Send(new AddSalesOrderCommand(name));
            return NoContent();
        }
    }
}
