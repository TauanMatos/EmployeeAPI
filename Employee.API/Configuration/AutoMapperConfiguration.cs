using Application.DTO;
using Application.DTO.Update;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace API.DependecyInjection
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDto, Employee>().ReverseMap();
                cfg.CreateMap<EmployeeAddressDto, EmployeeAddress>().ReverseMap();
                cfg.CreateMap<CreateEmployeeDto, Employee>();
                cfg.CreateMap<CreateEmployeeAddressDto, EmployeeAddress>();
                cfg.CreateMap<UpdateEmployeeDto, Employee>();
                cfg.CreateMap<UpdateEmployeeAddressDto, EmployeeAddress>();

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
