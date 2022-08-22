namespace MiddlewareDemo.Services
{
    public interface ITokenInterceptorService
    {
        bool InterceptToken(HttpContext context);
    }
}