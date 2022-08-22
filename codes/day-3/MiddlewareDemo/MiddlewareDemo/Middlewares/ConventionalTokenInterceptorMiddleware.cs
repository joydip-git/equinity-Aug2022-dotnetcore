namespace MiddlewareDemo.Middlewares
{
    public class ConventionalTokenInterceptorMiddleware
    {
        private readonly RequestDelegate _next;

        public ConventionalTokenInterceptorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //httpContext.Request.Headers.Authorization
            await httpContext.Response.WriteAsync("\n Request: Conventional middleware\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("\n Response: Conventional middleware\n");
        }
    }
}
