using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NetCoreBaseDemo.Core.Extensions
{
    public static class UseMiniProfilerExtension
    {
        public static IServiceCollection AddMiniProfiler_Cus(this IServiceCollection services)
        {
            services.AddMiniProfiler(options =>
                 options.RouteBasePath = "/profiler"
             );
            return services;
        }
        public static IApplicationBuilder UseMiniProfiler_Cus(this IApplicationBuilder app)
        {
            app.UseMiniProfiler();
            return app;
        }


    }
}
