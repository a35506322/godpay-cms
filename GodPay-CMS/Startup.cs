using GodPay_CMS.Common.Filiters;
using GodPay_CMS.Common.Helpers.Decipher;
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
using GodPay_CMS.Common;
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
            // appsettings
            services.Configure<SettingConfig>(Configuration.GetSection("SettingConfig"));

            // Atuo mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Cookie Register
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.LoginPath = new PathString("/signin");
                option.LogoutPath = new PathString("/signinapi/signout");
                // 無權限的時候，轉到此網址
                option.AccessDeniedPath = new PathString("/");
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
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPersonnelRepository, PersonnelRepository>();

            // Service
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISigninService, SigninService>();
            services.AddScoped<IAuthorityService, AuthorityService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IEnumService, EnumService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPersonnelService, PersonnelService>();
            services.AddScoped<IGLBDOperationAndTransactionRecordService, GLBDOperationAndTransactionRecordService>();

            // Helper
            services.AddSingleton<IDecipherHelper, DecipherHelper>();

            // HttpClient


            services.AddHttpClient("godapi", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetSection("SettingConfig:Urls:GodApiUrl").Value);
                //// Github API versioning
                //c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                //// Github requires a user-agent
                //c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });

            // Bundle
            services.AddWebOptimizer(pipeline =>
            {
                pipeline.AddCssBundle(
                     "/site-css/bundle.css",
                     "/lib/dash-ui/css/theme.css",                  
                     "/lib/bootstrap-icons/font/bootstrap-icons.css",
                     "/lib/primevue/resources/themes/saga-green/theme.css",
                     "/lib/primevue/resources/primevue.min.css",
                     "/lib/primeicons/primeicons.css",
                     "/site-css/bootstrap-custom.css",
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
                        // 統一回傳ModelState
                        options.Filters.Add<ModelStateValidationFilter>();
                    })
                    // 巨雷千萬要用axios傳你要用NewtonsoftJson，千萬別用內建的會有問題
                    .AddNewtonsoftJson();

            services.AddOpenApiDocument(config =>
            {
                config.DocumentName = "v2";
                config.Version = "0.0.1";
                config.Title = "iPass API Document";
                config.Description = "支付中心後台 API Document";
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

            app.UseOpenApi(config =>
            {
                config.Path = "/swagger/v2/swagger.json";
                config.DocumentName = "v2";
                config.PostProcess = (document, http) =>
                {
                    if (env.IsDevelopment() || env.IsEnvironment("Testing"))
                    {
                        document.Info.Title += " (開發環境)";
                        document.Info.Version += "-dev";
                    }
                    if (env.IsStaging())
                    {
                        document.Info.Title += " (測試環境)";
                        document.Info.Version += "-test";
                    }
                };
            });

            app.UseSwaggerUi3(config =>
            {
                config.DocumentTitle = "iPass API Document";
                config.DocExpansion = "list";
                config.DefaultModelsExpandDepth = -1;
            });

            app.UseWebOptimizer();

            app.UseStaticFiles();

            // 額外增加靜態內容檔案
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
