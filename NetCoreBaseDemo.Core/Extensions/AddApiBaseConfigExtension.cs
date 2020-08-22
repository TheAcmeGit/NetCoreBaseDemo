using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;


namespace NetCoreBaseDemo.Core.Extensions
{
   public static class AddApiBaseConfigExtension
    {
        public static IServiceCollection AddApiBaseConfig(this IServiceCollection services)
        {
            // 采用小写的 URL 路由模式  
            services.AddRouting(options => { options.LowercaseUrls = true; });


            return services;
        }
    }
}
