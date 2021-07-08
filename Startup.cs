using Candystore.Data;
using Candystore.Repository;
using Candystore.Repository.Interfaces;
using Candystore.Service;
using Candystore.Service.Interfaces;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore
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
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("CandyStoreConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();
            services.AddRazorPages();


            //Repositories

            services.AddTransient<IApetisaniRepository, ApetisaniRepository>();
            services.AddTransient<ICandyTypesRepository, CandyTypesRepository>();
            services.AddTransient<ICoffeTypesRepository, CoffeTypesRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddTransient<IWishlistRepository, WishlistRepository>();



            //Services

            services.AddTransient<IApetisaniService, ApetisaniService>();
            services.AddTransient<ICandyTypesService, CandyTypesService>();
            services.AddTransient<ICoffeTypesService, CoffeTypesService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<IWishlistService, WishlistService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
