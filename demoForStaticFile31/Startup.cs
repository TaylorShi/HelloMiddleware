using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace demoForStaticFile31
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
            //services.AddDirectoryBrowser();
        }

        const int BufferSize = 64 * 1024;

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //app.UseDefaultFiles();

            //app.UseDirectoryBrowser();

            //app.UseStaticFiles();

            app.MapWhen(httpContext =>
            {
                return !httpContext.Request.Path.Value.StartsWith("/api");
            }, applicationBuilder =>
            {
                var rewriteOptions = new RewriteOptions();
                rewriteOptions.AddRewrite(".*", "/index.html", true);

                applicationBuilder.UseRewriter(rewriteOptions);
                applicationBuilder.UseStaticFiles();

                //applicationBuilder.Run(async httpContext =>
                //{
                //    var indexFile = env.WebRootFileProvider.GetFileInfo("index.html");
                //    httpContext.Response.ContentType = "text/html";
                //    using (var fileStream = new FileStream(indexFile.PhysicalPath, FileMode.Open, FileAccess.Read))
                //    {
                //        await StreamCopyOperation.CopyToAsync(fileStream, httpContext.Response.Body, null, BufferSize, httpContext.RequestAborted);
                //    }
                //});
            });

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    RequestPath = "/Assets",
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Assets"))
            //});

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
