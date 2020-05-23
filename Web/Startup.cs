using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shop.Web.Helpers.Mapping;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Web.Middleware;
using Web.Extensions;
using Lamar;

namespace Shop.Web
{
    public class Startup
    {
        public IConfiguration _config { get; }
        private readonly string _connString;

        public Startup(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetSection("ConfigSetting:ConnectionStrings")["DbConnectionString"];
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //ServiceRegistry is from Lamar IOC - it implements IServiceCollection
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(_connString));
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddApplicationServices();
            services.AddSwaggerDocumentation();

            services.AddCors(options =>
           {
               options.AddPolicy("CorsPolicy",
               builder =>
               {
                   builder.AllowAnyHeader()
                          .AllowAnyMethod()
                          .WithOrigins("https://localhost:4200");
               });
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionMiddleware();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            //     endpoints.MapFallbackToController("Index", "Fallback");
            // });

        }
    }
}
