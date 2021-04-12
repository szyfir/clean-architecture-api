using CleanArchitecture.Infrastructure.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CleanArchitecture.IntegrationTests.SeedWork
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public CustomWebApplicationFactory()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var oldDbContext = services.SingleOrDefault(w => w.ServiceType == typeof(DbContextOptions<CleanArchitectureDbContext>));

                services.Remove(oldDbContext);


                services.AddDbContext<CleanArchitectureDbContext>(opts =>
                {
                    opts.UseInMemoryDatabase("CleanArchitectureDbContextInMemoryTest");
                });

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<CleanArchitectureDbContext>();

                    context.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeInMemoryDatabase(context);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            });
        }
    }
}
