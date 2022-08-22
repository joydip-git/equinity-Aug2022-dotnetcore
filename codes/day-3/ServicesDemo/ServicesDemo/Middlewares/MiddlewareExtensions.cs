namespace ServicesDemo.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseOpeartionServiceMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OperationServiceMiddleware>();
        }
        public static IApplicationBuilder UseAnotherOpeartionServiceMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnotherOperationServiceMiddleware>();
        }
    }
}
