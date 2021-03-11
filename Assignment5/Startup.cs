using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Assignment5.Models;

namespace Assignment5
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

            services.AddMvc().AddRazorRuntimeCompilation();

            services.AddDbContext<DaintreeDBContext>(options =>
            {
                //options.UseSqlServer(Configuration["ConnectionStrings:DaintreeBooksConnection"]);
                options.UseSqlite(Configuration.GetConnectionString("DaintreeBooksConnection"));
            });

            services.AddScoped<IDaintreeRepository, EFDaintreeRepository>();

            //Enable Razor Pages
            services.AddRazorPages();

            //Sets up the in-memory data store
            services.AddDistributedMemoryCache();

            //Registers the services used to access session data
            services.AddSession();

            //Specifies that the same object should be used to satisfy related requests for Cart instances
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

            //Specifies that the same object should always be used
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

            //Allows the session system to automatically associate requests with sessions
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pg:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("pg",
                    "{pg:int}",
                    new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapControllerRoute("pagination",
                    "/P{pg}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            SeedDatabase.EnsurePopulated(app);
        }
    }
}
