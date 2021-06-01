using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using FluentValidation.AspNetCore;
using Application.Services.Account;
using Application.Services.Profile;
using Application.Validators.Account;
using Application.Validators.Profile;
using AdminPortal.Filters;

namespace AdminPortal
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
            services.AddDbContext<Data.EF.AdminContext>(option =>
                option.UseSqlServer(@"Server=DESKTOP-I7EOLFR\SQLEXPRESS;Database=AdminPortalDB;Trusted_Connection=True;"));

            services.AddSession();

            services.AddMvc(
                option =>
                { 
                    option.Filters.Add(typeof(ExceptionFilter));
                }
                ).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest)
                .AddFluentValidation(option =>
                {
                    option.RegisterValidatorsFromAssemblyContaining<AccountCreateValidator>();
                    option.RegisterValidatorsFromAssemblyContaining<ProfileChangePasswordValidator>();
                });
            
            services.AddScoped<ModelStateFilter>();
            services.AddScoped<ModelStateAjaxFilter>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/";
                    opt.AccessDeniedPath = "/account/login";
                    opt.ReturnUrlParameter = "returnUrl";
                    opt.LogoutPath = "/logout";
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                });

            services.AddControllersWithViews();
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
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
