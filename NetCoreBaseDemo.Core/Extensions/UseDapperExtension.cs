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
    public static class UseDapperExtension
    {
        public static IServiceCollection AddDapper(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnection>((sp) =>
            {
                //采用MiniProfiler 用于性能分析
                var client = new ProfiledDbConnection(new SqlConnection(connectionString), MiniProfiler.Current);
                client.Open();
                return client;
            });
            return services;
        }


    }
}
