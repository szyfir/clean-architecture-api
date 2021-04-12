using CleanArchitecture.API.Middleware;
using CleanArchitecture.Core.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.GraphQL;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Persistance;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Infrastructure.GraphQL.Schemas;
using CleanArchitecture.Infrastructure.GraphQL.Types;
using CleanArchitecture.Infrastructure.GraphQL.Queries;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace CleanArchitecture.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // IIS
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddControllers();
            services.AddApplicationSercices();
            services.AddInfrastructurePersistanceServices(Configuration);
            services.AddIdentityServices(Configuration);
            services.AddInfrastructureServices();
            services.AddGrahQLConfiguration();
            services.AddScoped<SalesOrderSchema>(); services.AddGraphQL()
                .AddSystemTextJson()
                .AddNewtonsoftJson()
                             .AddGraphTypes(ServiceLifetime.Scoped);


            services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Clean Architecure API v1",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseGraphQL<SalesOrderSchema>();
            app.UseGraphQLPlayground();

            app.UseSwagger();
            app.UseSwaggerUI(opts =>
            {
                opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
