using MiddlewareDemo.Middlewares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//depndency injection (here)
//ConfigureServices(builder);
//IServiceCollection services = builder.Services;

builder.Services.AddTransient<FactoryActivatedTokenInterceptorMiddleware>();

WebApplication app = builder.Build();

//configure HTTP request pipeline (here)
//ConfigureHttpRequestPipepline(app);
app.UseConventionalTokenInterceptor();
app.UseFactoryBasedTokenInterceptor();
app.Use(
       async (context, next) =>
       {
           await context.Response.WriteAsync("1. middleware1 request\n");
           await next();
           await context.Response.WriteAsync("2. middleware1 response\n");
       }
    );
app.Use(
   async (context, next) =>
   {
       await context.Response.WriteAsync("3. middleware2 request\n");
       await next();
       await context.Response.WriteAsync("4. middleware2 response\n");
   }
);


app.Run(
   async (context) =>
   {
       await context.Response.WriteAsync("Hello World!\n");
   }
);



app.Run();

//void ConfigureServices(WebApplicationBuilder builder)
//{

//}
//void ConfigureHttpRequestPipepline(WebApplication app)
//{

//}


