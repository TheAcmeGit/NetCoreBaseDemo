using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCoreBaseDemo.Core.Extensions;
using NetCoreBaseDemo.Core.Filters;
using NetCoreBaseDemo.Dapper.Repository;
using NetCoreBaseDemo.IRepository;

namespace NetCoreBaseApiDemo
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services.AddSwagger(xmlPath);
            services.AddDapper(Configuration.GetConnectionString("DefaultConnection"));
            services.AddAutoMapper_Cus();
            services.AddRedis_Cus();
            services.AddMiniProfiler_Cus();

            services.AddCors(options =>
            {
                options.AddPolicy("all", builder =>
                {
                    builder.WithOrigins("http://192.168.16.27:9528").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
            
            

            services.AddControllers(options=> {
                options.Filters.Add<MyActionFilter>();
            
            }).ConfigureApiBehaviorOptions(options=> {
                //关闭自带的模型验证
                options.SuppressModelStateInvalidFilter = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseSwagger_Cus();
            app.UseMiniProfiler_Cus();
            app.UseCors("all");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AopRegister();

            //builder.RegisterType<SysAccountRepository>().As<ISysAccountRepository>().InstancePerLifetimeScope(); 
            // 在这里添加服务注册
            // builder.RegisterType<TopicService>();
        }
    }
}
