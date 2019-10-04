using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HomeCare.Application.AutoMapper;
using HomeCare.Application.Implementation;
using HomeCare.Application.Interfaces;
using HomeCare.Data.EF;
using HomeCare.Data.EF.Repositories;
using HomeCare.Data.IRepositories;
using HomeCare.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace HomeCare
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


            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    o => o.MigrationsAssembly("HomeCare.Data.EF")));


            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromHours(3);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddHttpContextAccessor();

            //use this configuration instead of AutoMapperConfig.cs
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });


            services.AddAutoMapper();


            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            services.AddTransient<DbInitializer>();

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));

            //Repositories
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IBillRepository, BillRepository>();
            services.AddTransient<IHelperRepository, HelperRepository>();
            services.AddTransient<IHelperCheckRepository, HelperCheckRepository>();
            services.AddTransient<IBillOptionRepository, BillOptionRepository>();
            services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddTransient<IBillCancelNumberRepository, BillCancelNumberRepository>();
            services.AddTransient<IHelperNumberRepository, HelperNumberRepository>();
            services.AddTransient<IBillOptionHelperNumberRepository, BillOptionHelperNumberRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<IAppAdminModRepository, AppAdminModRepository>();
            services.AddTransient<IFunctionRepository, FunctionRepository>();
            services.AddTransient<IAppAdminModRoleRepository, AppAdminModRoleRepository>();
            services.AddTransient<IHelperImageRepository, HelperImageRepository>();

            //Services
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IHelperService, HelperService>();
            services.AddTransient<IHelperCheckService, HelperCheckService>();
            services.AddTransient<IBillCancelNumberService, BillCancelNumberService>();
            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IAppAdminModService, AppAdminModService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IHelperImageService, HelperImageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/tedu-{Date}.txt");

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
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();


            app.UseMvc(routes =>
            {

                routes.MapAreaRoute(
                    name: "AreaAdmin",
                    areaName: "Admin",
                    template: "Admin/{controller=LoginLogout}/{action=Index}/{id?}");


                routes.MapAreaRoute(
                    name: "AreaHelper",
                    areaName: "Helper",
                    template: "Helper/{controller=Login}/{action=Index}/{id?}");


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");

            });
        }
    }
}
