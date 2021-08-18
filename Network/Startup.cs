using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Domain.Models;
using Network.Data;
using Network.Account;
using Network.DTO;
using Network.Repository;
using AutoMapper;
using Network.Services.Tariff;
using Network.Services.Operator;
using Network.Services.PhoneNumber;
using Network.Services.User;

namespace Network
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
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<ApplicationRepository>();
            services.AddTransient<DepartmentRepository>();
            services.AddTransient<OperatorRepository>();
            services.AddTransient<TariffRepository>();
            services.AddTransient<PhoneNumberRepository>();
            services.AddTransient<PrefixRepository>();
            services.AddTransient<UserRepository>();
            services.AddTransient<IApplicationService,ApplicationService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<ITariffService, TariffService>();
            services.AddTransient<IOperatorService, OperatorService>();
            services.AddTransient<IPhoneService, PhoneService>();
            services.AddTransient<IUserService, UserService>();
            services.AddControllersWithViews();
          

            services.AddDbContext<DataContext>(options => options.UseSqlite(Configuration.GetConnectionString("Default")).UseLazyLoadingProxies());
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.AllowedUserNameCharacters += "יצףךוםדרשחץתפûגאןנמכהז‎ÿקסלטעüב‏"; 
            }).AddEntityFrameworkStores<DataContext>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddAuthorization();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/SignIn";   //example login - ‎ךרם  Sign - Controller
                options.AccessDeniedPath = "/Home/Index";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
            });
           
            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=SignIn}/{id?}");
                endpoints.MapAreaControllerRoute("AdminArea", Domain.Constants.Roles.Admin, "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
