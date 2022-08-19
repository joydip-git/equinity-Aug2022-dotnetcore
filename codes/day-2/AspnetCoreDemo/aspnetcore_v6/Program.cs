var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
var host = builder.Host;

app.MapGet("/", () => "Hello World!");

app.Run();
