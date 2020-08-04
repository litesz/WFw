using Example.Core.Account;
using Example.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WFw;


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
            services.AddSqlSugar(Option =>
            {
                Option.ConnectionString = "Data Source=D:\\DB.db";
                Option.DatabaseType = "sqlite";
            });

            //添加当前用户信息，审计基于此内容
            services.AddWFwCurrentUser();

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
                var accountService = scope.ServiceProvider.GetService<IAccountService>();
                accountService.InitTable();

            });
        }
    }
}
