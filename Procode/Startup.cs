using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Procode.Data;
using Procode.Data.Interfaces;
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

            services.AddMvc(options =>
                options.EnableEndpointRouting = false
            );
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{tag?}");
            });

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //            name: "custom",
            //            template: "{name}/{id}/{title}",
            //            defaults: new { controller = "Products" });
            //});
        }
    }
}
