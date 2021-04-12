using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Application.Features.Orders.Commands.AddSalesOrder
{
    public class AddSalesOrderCommand : IRequest
    {
        public AddSalesOrderCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
