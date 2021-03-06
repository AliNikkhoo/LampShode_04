using AccountManagement.Configuration;
using DiscountManagement.Configuration;
using InventorManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagement.Configuration;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost
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
            var connectionstring = Configuration.GetConnectionString("LampShadeDb");
            ShopManagementBootstrapper.Configure(services,connectionstring);
            DiscountManagementBootstrapper.Configure(services, connectionstring);
            InventoryManagementBootstrapper.Configure(services,connectionstring);
            AcountManagementBootStrapper.Configure(services, connectionstring);
            services.AddRazorPages();
        }
        //private static void UpdateDatabase(IApplicationBuilder app)
        //{
        //    using (var serviceScope = app.ApplicationServices
        //        .GetRequiredService<IServiceScopeFactory>()
        //        .CreateScope())
        //    {
        //        using (var context = serviceScope.ServiceProvider.GetService<ShopContext>())
        //        {
        //            context.Database.Migrate();
        //        }
        //    }
        //}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          //  UpdateDatabase(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                
            });
        }
    }
}
