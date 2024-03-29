using Example.Core.Account;
using Example.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WFw;
using WFw.GeTui.Services;
using System.Linq;
using System.Collections.Generic;
using WFw.DbContext;
using WFw.IDbContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WFw.Redis;

namespace Example
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



            services.AddControllersWithViews();

            //添加sqlsugar
            services.AddWFwSqlSugar(Option =>
            {
                Option.ConnectionString = "Data Source=D:\\DB1.db";
                Option.DatabaseType = "sqlite";
            });



            //添加当前用户信息，审计基于此内容
            services.AddWFwCurrentUser();
            services.AddYsApiClient(Configuration);
            services.AddTencentStsClient(Configuration);
            //services.AddSmsChineseClient(Configuration);
            services.AddTencentSmsClient(Configuration);
            services.AddTencentOcrClient(Configuration);
            services.ConfigureModelStateResponse(Configuration);
            services.AddWFwRedis(act =>
            {
                act.Configuration = "127.0.0.1:6379";
            });
            //添加Cookier认证服务
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.LoginPath = "/Identity/SignIn";
                });

            services.AddScoped<IAccountService, AccountService>();
            services.AddSingleton<SingletonConfigModel>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //错误捕捉，统一返回
            app.UseErrorHandling();

            app.UseStaticFiles();

            app.UseRouting();


            //顺序不能反，UseAuthentication必须在上
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseWFwCurrentUser();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Init(scope =>
            {


                var d = scope.ServiceProvider.GetService<SingletonConfigModel>();
                d.VisitNum++;

                var c = scope.ServiceProvider.GetService<IRedisCache>();
                var bb = c.GeoDist("zza", "b", "c", GeoUnit.ft);
                //var accountService = scope.ServiceProvider.GetService<IAccountService>();
                //accountService.InitTable();


            });
        }
    }
}
