namespace MiddlewareDemo.Services
{
    public class TokenInterceptorService : ITokenInterceptorService
    {

        public bool InterceptToken(HttpContext context)
        {
            return true;
        }
    }
}
