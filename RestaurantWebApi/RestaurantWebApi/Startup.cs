using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestaurantWebApi.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApi.Repositories;
using Microsoft.AspNetCore.Http;

namespace RestaurantWebApi
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

            var connectionString = Configuration["connectionStrings:restaurantDBConnectionString"];
            services.AddDbContext<RestaurantContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, RestaurantContext RestaurantContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler( appBuilder => {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Unexpected Fault Happend, Please Try Again Later");
                    });
                });
            }

            RestaurantContext.EnsureSeedDataForContext();
            app.UseMvc();
        }
    }
}
