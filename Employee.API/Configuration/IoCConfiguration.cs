using Application.ApplicationServices;
using Application.ApplicationServices.Interfaces;
using Domain.Common.RepositoryInterface;
using Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.DependecyInjection
{
    public static class IoCConfiguration
    {
        public static void AddIoCConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
