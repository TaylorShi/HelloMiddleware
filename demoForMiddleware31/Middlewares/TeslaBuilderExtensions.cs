using Microsoft.AspNetCore.Builder;

namespace demoForMiddleware31.Middlewares
{
    public static class TeslaBuilderExtensions
    {
        public static IApplicationBuilder UseTeslaMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<TeslaMiddleware>();
        }
    }
}
