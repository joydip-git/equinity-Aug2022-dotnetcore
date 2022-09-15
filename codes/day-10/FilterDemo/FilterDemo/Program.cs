using FilterDemo.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    //options.Filters.Add<SampleActionFilter>(1);
    //options.Filters.Add<SampleAsyncFilter>(0);
    options.Filters.Add<CustomExceptionFilter>();
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
