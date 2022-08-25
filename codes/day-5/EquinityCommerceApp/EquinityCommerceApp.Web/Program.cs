using EquinityCommerceApp.Web.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureMiddlewarePipeline(app);

app.Run();

static void ConfigureServices(WebApplicationBuilder builder)
{
    var conStr = builder.Configuration.GetConnectionString("EquinityDbConStr");
    builder.Services.AddDbContext<EquinityAppDbContext>(
        options =>
        {
            options.UseSqlServer(conStr);
        });
    builder.Services.AddControllersWithViews();
}

static void ConfigureMiddlewarePipeline(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}",
        defaults: new { controller = "Home", action = "Index" });
}