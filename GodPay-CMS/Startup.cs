using GodPay_CMS.Common.Filiters;
using GodPay_CMS.Repositories.Implements;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.Implements;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace GodPay_CMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Atuo mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Cookie Register
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.LoginPath = new PathString("/Signin");
                option.LogoutPath = new PathString("/SigninOperate/SignOut");
                // �L�v�����ɭԡA��즹���}
                option.AccessDeniedPath = new PathString("/Signin");
                option.ReturnUrlParameter = "ret";
                option.Cookie.Name = "ascc-gpb";
            });

            // HttpContext
            services.AddHttpContextAccessor();
           
            // Repository
            services.AddScoped<IRepostioryWrapper, RepostioryWrapper>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFuncClassRepository, FuncClassRepository>();
            services.AddScoped<IFuncRepository, FuncRepository>();
            services.AddScoped<IInsiderRepository, InsiderRepository>();

            // Service
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISigninService, SigninService>();
            services.AddScoped<IAuthorityService, AuthorityService>();
            services.AddScoped<IBusinessManagementService, BusinessManagementService>();

            // Bundle
            services.AddWebOptimizer(pipeline =>
            {
                pipeline.AddCssBundle(
                     "/site-css/bundle.css",
                     "/lib/dash-ui/css/theme.css",
                     "/site-css/bootstrap-custom.css",
                     "/lib/bootstrap-icons/font/bootstrap-icons.css",
                     "/lib/primevue/resources/themes/saga-green/theme.css",
                     "/lib/primevue/resources/primevue.min.css",
                     "/lib/primeicons/primeicons.css",
                     "/site-css/site.css"
                );

                pipeline.AddJavaScriptBundle(
                     "/site-js/bundle.js",
                     "/lib/dash-ui/js/main.js",
                     "/lib/dash-ui/js/feather.js",
                     "/lib/dash-ui/js/sidebarMenu.js"
                );
            });

            services.AddControllersWithViews(options =>
                    {
                        // �Τ@�^��ModelState
                        options.Filters.Add<ModelStateValidationFilter>();
                    })
                    // �w�]���|�^�Ƕ}�Y�p�g���ݩ�,��������Json.Text���]�w
                    // ���p�d�U�n��axios�ǧA�n��NewtonsoftJson�A�d�U�O�Τ��ت��|�����D
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseWebOptimizer();

            app.UseStaticFiles();

            // �B�~�W�[�R�A���e�ɮ�
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "StaticFiles")),
                RequestPath = "/StaticFiles"
            });

            app.UseRouting();

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.None,
            };

            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
