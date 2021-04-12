using CleanArchitecture.Core.Application.Contracts.Infrastructure;
using CleanArchitecture.Infrastructure.Mail;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure
{
    public static class CleanArchitectureInfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, MailService>();
            return services;
        }
    }
}
