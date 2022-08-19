WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

WebApplication app = builder.Build();
//var host = builder.Host;

app.MapGet("/", () => "Hello World!");

app.Run();
