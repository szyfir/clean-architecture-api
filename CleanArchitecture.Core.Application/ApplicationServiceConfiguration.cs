using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using CleanArchitecture.Core.Application.Behaviours;
using CleanArchitecture.Core.Application.Features.Orders.Commands.AddSalesOrder;
using CleanArchitecture.Core.Application.Profiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CleanArchitecture.Core.Application
{
    public static class ApplicationServiceConfiguration
    {
        public static IServiceCollection AddApplicationSercices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehaviour<,>));
            services.AddTransient<IValidator<AddSalesOrderCommand>, AddSalesOrderCommandValidator>();

            return services;
        }
    }
}
