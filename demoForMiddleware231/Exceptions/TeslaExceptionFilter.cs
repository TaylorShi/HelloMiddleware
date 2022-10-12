using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace demoForMiddleware231.Exceptions
{
    public class TeslaExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            IKnowException knowException = context.Exception as IKnowException;
            if (knowException == null)
            {
                var logger = context.HttpContext.RequestServices.GetService<ILogger<TeslaExceptionFilterAtttribute>>();
                logger.LogError(context.Exception, context.Exception.Message);
                knowException = KnowException.Unknown;
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            else
            {
                knowException = KnowException.FromKnowException(knowException);
                context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
            }
            context.Result = new JsonResult(knowException)
            {
                ContentType = "application/json"
            };
        }
    }
}
