using MiddlewareDemo.Services;

namespace MiddlewareDemo.Middlewares
{
    public class ConventionalTokenInterceptorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly ITokenInterceptorService _interceptorService;

        public ConventionalTokenInterceptorMiddleware(RequestDelegate next, ILogger<ConventionalTokenInterceptorMiddleware> logger, ITokenInterceptorService tokenInterceptorService)
        {
            _next = next;
            _logger = logger;
            _interceptorService = tokenInterceptorService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            if (_interceptorService.InterceptToken(httpContext))
            {
                await _next(httpContext);               
            }
            else
            {
                await httpContext.Response.WriteAsync("\n no auth header \n");
            }
            //await httpContext.Response.WriteAsync("\n Request: Conventional middleware\n");
            //await _next(httpContext);
            //await httpContext.Response.WriteAsync("\n Response: Conventional middleware\n");
        }
    }
}
