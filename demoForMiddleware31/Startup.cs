using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using demoForMiddleware31.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace demoForMiddleware31
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
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (httpcontext, next) =>
            //{
            //    await next();
            //    await httpcontext.Response.WriteAsync("Hello Middleware");
            //});

            //app.Map("/abc", applicationBuilder =>
            //{
            //    applicationBuilder.Use(async (httpcontext, next) =>
            //    {
            //        await next();
            //        await httpcontext.Response.WriteAsync("Hello Middleware");
            //    });
            //}); 

            //app.MapWhen(httpContext => 
            //{
            //    return httpContext.Request.Query.Keys.Contains("abc");
            //}, applicationBuilder =>
            //{
            //    applicationBuilder.Run(async httpcontext =>
            //    {
            //        await httpcontext.Response.WriteAsync("Hello Middleware");
            //    });
            //});

            app.UseTeslaMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
