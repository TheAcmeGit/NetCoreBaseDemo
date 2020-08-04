using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.Core.Extensions
{
   public static class AddRedisExtension
    {
        public static IServiceCollection AddRedis_Cus(this IServiceCollection services, string redisConnenctionString="127.0.0.1:6379")
        {
            services.AddSingleton<IConnectionMultiplexer>((sp) =>
            {
                var config = new ConfigurationOptions
                {
                    AbortOnConnectFail = false,
                    AllowAdmin = true,
                    ConnectTimeout = 15000,//改成15s
                    SyncTimeout = 5000,
                    //Password = "Pwd",//Redis数据库密码
                    EndPoints = { redisConnenctionString }// connectionString 为IP:Port 如”192.168.2.110:6379”
                };
                return ConnectionMultiplexer.Connect(config);
            });
            return services;
        }
    }
}
