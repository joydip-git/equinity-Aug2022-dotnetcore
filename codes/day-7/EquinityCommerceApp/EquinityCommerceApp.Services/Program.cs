using EquinityCommerceApp.Core.Repositories;
using EquinityCommerceApp.DataAccess.Data;
using EquinityCommerceApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureAPIServices(builder);

var app = builder.Build();

await CreateAndSeedDatabase(app);
ConfigureAPIMiddlewarePipeline(app);

app.Run();

static void ConfigureAPIServices(WebApplicationBuilder builder)
{
    var conStr = builder.Configuration.GetConnectionString("EquinityDbConStr");
    builder.Services.AddDbContext<EquinityAppDbContext>(
        options =>
        {
            options.UseSqlServer(conStr);
        });
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

static void ConfigureAPIMiddlewarePipeline(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

static async Task CreateAndSeedDatabase(WebApplication app)
{
    var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
    try
    {
        var serviceProvider = app.Services.GetRequiredService<IServiceProvider>();
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<EquinityAppDbContext>();
            await EquinityAppDbContextSeed.SeedAsync(dbContext, loggerFactory, 3);
        }
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger("Application");
        logger.LogError(ex.Message);
        throw;
    }
}