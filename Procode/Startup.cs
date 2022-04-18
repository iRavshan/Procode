using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Procode.Data;
using Procode.Data.Interfaces;
using Procode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode
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
            services.AddControllersWithViews();

            services.AddHttpClient<ISpeakerRepository, SpeakerRepository>(client =>
            {
                client.BaseAddress = new Uri("https://procodeapi.herokuapp.com/api/");
            });

            services.AddHttpClient<IContentRepository, ContentRepository>(client =>
            {
                client.BaseAddress = new Uri("https://procodeapi.herokuapp.com/api/");
            });

            services.AddHttpClient<IFeedbackRepository, FeedbackRepository>(client =>
            {
                client.BaseAddress = new Uri("https://procodeapi.herokuapp.com/api/");
            });

            services.AddHttpClient<IUserRepository, UserRepository>(client =>
            {
                client.BaseAddress = new Uri("https://procodeapi.herokuapp.com/api/");
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Expiration = TimeSpan.FromHours(6);
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
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
                app.UseHsts();
            }
 
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthorization();
            app.UseAuthentication();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{tag?}");
            });
        }
    }
}
