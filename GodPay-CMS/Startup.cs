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
            // appsettings
            services.Configure<SettingConfig>(Configuration.GetSection("SettingConfig"));

            // Atuo mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Cookie Register
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.LoginPath = new PathString("/Signin");
                option.LogoutPath = new PathString("/SigninApi/SignOut");
                // �L�v�����ɭԡA��즹���}
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

            //Helper
            services.AddSingleton<IDecipherHelper, DecipherHelper>();

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

            services.AddOpenApiDocument(config =>
            {
                config.DocumentName = "v2";
                config.Version = "0.0.1";
                config.Title = "iPass API Document";
                config.Description = "��I���߫�x API Document";
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
                        document.Info.Title += " (�}�o����)";
                        document.Info.Version += "-dev";
                    }
                    if (env.IsStaging())
                    {
                        document.Info.Title += " (��������)";
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
