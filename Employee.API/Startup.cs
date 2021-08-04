using API.Configuration;
using API.DependecyInjection;
using API.Extensions;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API
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
            services.AddMvcConfiguration();
            services.AddSwggerConfiguration();
            services.AddDatabaseConfiguration();
            services.AddAutoMapperConfiguration();
            services.AddIoCConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EmployeeDbContext context)
        {
            app.UseGlobalExceptionHandler();
            app.UseHttpsRedirection();
            app.UseSimulatedLatency(min: TimeSpan.FromMilliseconds(100), max: TimeSpan.FromMilliseconds(500));
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
