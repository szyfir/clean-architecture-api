﻿using CleanArchitecture.Infrastructure.GraphQL.Queries;
using CleanArchitecture.Infrastructure.GraphQL.Schemas;
using CleanArchitecture.Infrastructure.GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.GraphQL
{
    public static class GraphQLConfiguration
    {
        public static IServiceCollection AddGrahQLConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<SalesOrderType>();
            services.AddSingleton<SalesOrderTypeEnumType>();
            services.AddScoped<SalesOrderQuery>();
            services.AddSingleton<SalesOrderSchema>();
            return services;
        }
    }
}
