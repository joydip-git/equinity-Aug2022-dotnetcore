using EquinityCommerceApp.Web.Mapping;
using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services;
using EquinityCommerceApp.Web.Services.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder);
var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureMiddlewarePipeline(app);

app.Run();

static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.Configure<ApiUrls>(builder.Configuration.GetSection(ApiUrls.API_URL_SECTION));
    builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
    //builder.Services.AddHttpClient();
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