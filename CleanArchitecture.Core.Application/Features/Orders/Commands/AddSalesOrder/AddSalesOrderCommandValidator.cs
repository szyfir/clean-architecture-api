using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Application.Features.Orders.Commands.AddSalesOrder
{
    public class AddSalesOrderCommandValidator : AbstractValidator<AddSalesOrderCommand>
    {
        public AddSalesOrderCommandValidator()
        {
            RuleFor(w => w.Name)
                .NotEmpty().WithMessage("Property is required")
                .MaximumLength(60).WithMessage("Property must not exceed 60 characters");
        }
    }
}
