using demoForMiddleware231.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace demoForMiddleware231
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
            //services.AddMvc(mvcOptions =>
            //{
            //    mvcOptions.Filters.Add<TeslaExceptionFilter>();
            //}).AddJsonOptions(jsonOptions =>
            //{
            //    jsonOptions.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            //});

            //services.AddMvc(mvcOptions =>
            //{

            //}).AddJsonOptions(jsonOptions =>
            //{
            //    jsonOptions.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            //});

            services.AddMvc(mvcOptions =>
            {
                mvcOptions.Filters.Add<TeslaExceptionFilterAtttribute>();
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseExceptionHandler("/error");

            //app.UseExceptionHandler(applicationBuilder =>
            //{
            //    applicationBuilder.Run(async httpContext =>
            //    {
            //        var exceptionHandlerPathFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
            //        var ex = exceptionHandlerPathFeature?.Error;
            //        IKnowException knowException = ex as IKnowException;
            //        if (knowException == null)
            //        {
            //            var logger = httpContext.RequestServices.GetService<ILogger<TeslaExceptionFilterAtttribute>>();
            //            logger.LogError(ex, ex.Message);
            //            knowException = KnowException.Unknown;
            //            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //        }
            //        else
            //        {
            //            knowException = KnowException.FromKnowException(knowException);
            //            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            //        }

            //        var jsonOptions = httpContext.RequestServices.GetService<IOptions<JsonOptions>>();
            //        httpContext.Response.ContentType = "application/json";
            //        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(knowException, jsonOptions.Value.JsonSerializerOptions));
            //    });
            //});

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
