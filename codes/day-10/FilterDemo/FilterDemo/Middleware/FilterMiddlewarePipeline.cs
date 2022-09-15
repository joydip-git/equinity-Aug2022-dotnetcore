namespace FilterDemo.Middleware
{
    public class FilterMiddlewarePipeline
    {
        public void Configure(IApplicationBuilder appBuilder)
        {
            appBuilder.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("hello from filter middleware");
                Console.WriteLine("hello from filter middleware");
                await next();
            });
        }
    }
}
