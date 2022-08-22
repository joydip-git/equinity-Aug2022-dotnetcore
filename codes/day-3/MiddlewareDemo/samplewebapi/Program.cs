var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Configure the host using middlewares
// builder.Host.UseConsoleLifetime();

//builder.Services.AddTransient<>();
//builder.Services.AddScoped<>();
//builder.Services.AddSingleton<>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
