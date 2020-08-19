using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace NetCoreBaseDemo.Core.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapper_Cus(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfiles).Assembly);
            return services;
        }
    }
}
