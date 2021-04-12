using CleanArchitecture.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.IntegrationTests.SeedWork
{
    public static class Utilities
    {
        public static void InitializeInMemoryDatabase(CleanArchitectureDbContext context)
        {
            context.SalesOrders.Add(Core.Domain.Entities.SalesOrder.Create("so1"));
            context.SaveChanges();
        }
    }
}
