using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace demoForMiddleware31.Middlewares
{
    internal class TeslaMiddleware
    {
        readonly RequestDelegate _next;
        readonly ILogger _logger;

        public TeslaMiddleware(RequestDelegate next, ILogger<TeslaMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            using (_logger.BeginScope("TraceIdentifier: {TraceIdentifier}", httpContext.TraceIdentifier))
            {
                _logger.LogDebug("Start Action");

                await _next(httpContext);

                if (!httpContext.Response.HasStarted)
                {
                    await httpContext.Response.WriteAsync("Hello Middleware");
                }

                _logger.LogDebug("End Action");
            }
        }
    }
}
