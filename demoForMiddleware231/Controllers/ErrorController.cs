using demoForMiddleware231.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace demoForMiddleware231.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error")]
        public IActionResult Index()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = exceptionHandlerPathFeature?.Error;
            IKnowException knowException = ex as IKnowException;
            if(knowException == null)
            {
                var logger = HttpContext.RequestServices.GetService<ILogger<TeslaExceptionFilterAtttribute>>();
                logger.LogError(ex, ex.Message);
                knowException = KnowException.Unknown;
            }
            else
            {
                knowException = KnowException.FromKnowException(knowException);
            }
            return View(knowException);
        }
    }
}
