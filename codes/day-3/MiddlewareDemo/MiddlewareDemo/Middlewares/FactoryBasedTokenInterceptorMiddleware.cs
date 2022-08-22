namespace MiddlewareDemo.Middlewares
{
    //IMiddlewareFactory
    public class FactoryActivatedTokenInterceptorMiddleware : IMiddleware
    {
        public FactoryActivatedTokenInterceptorMiddleware()
        {

        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nRequest: Factory based middleware\n");
            await next(context);
            await context.Response.WriteAsync("\nResponse: Factory based middleware\n");
        }
    }
}
