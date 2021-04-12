
using CleanArchitecture.Core.Application.Exceptions;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Behaviours
{
    public class CommandValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public CommandValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(w => w.Validate(context))
                .SelectMany(m => m.Errors)
                .Where(w => w != null)
                .ToList();


            if (errors.Count() > 0)
            {
                var result = new ValidationResult(errors);
                throw new Exceptions.ValidationException(result);
            }

            return next();
        }
    }

}
