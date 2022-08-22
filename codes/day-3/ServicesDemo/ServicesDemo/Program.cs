using ServicesDemo.Services;
using ServicesDemo.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITransientOperationService, OperationService>();
builder.Services.AddScoped<IScopedOperationService, OperationService>();
builder.Services.AddSingleton<ISingletionOperationService, OperationService>();


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var providerOfTheScope = scope.ServiceProvider;
    var dependencyFactor = providerOfTheScope.GetRequiredService<IScopedOperationService>();
    var dependencyFactor1 = providerOfTheScope.GetRequiredService<ITransientOperationService>();
    var dependencyFactor2 = providerOfTheScope.GetRequiredService<ISingletionOperationService>();
    dependencyFactor.WriteMessage();
    dependencyFactor1.WriteMessage();
    dependencyFactor2.WriteMessage();
}

app.UseOpeartionServiceMiddleware();
app.UseAnotherOpeartionServiceMiddleware();
app.MapGet("/", () => "Hello World!");

app.Run();
