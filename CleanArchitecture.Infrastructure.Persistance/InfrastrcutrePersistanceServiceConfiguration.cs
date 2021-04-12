using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.Core.Application.Contracts.Persistance;
using CleanArchitecture.Infrastructure.Persistance.Repositories;

namespace CleanArchitecture.Infrastructure.Persistance
{
    public static class InfrastrcutrePersistanceServiceConfiguration
    {
        public static IServiceCollection AddInfrastructurePersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanArchitectureDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("CleanArchitectureDb")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BasicRepository<>));
            services.AddScoped<ISalesOrderRepsository, SalesOrderRepository>();
            return services;
        }
    }
}
