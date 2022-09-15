using CustomAttributedFilter.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    //options.Filters.Add<SampleAsyncFilterAttribute>();
    //options.Filters.Add<SampleAsyncFilter>(0);    
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
