using API.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.Configuration
{
    public static class MvcConfiguration
    {
        public static void AddMvcConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<CreateEmployeeAddressValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<CreateEmployeeValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<EmployeeAddressValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<EmployeeValidator>();
                })
                .AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }
    }
}
