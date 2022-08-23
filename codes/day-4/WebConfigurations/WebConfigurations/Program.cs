//using Microsoft.Extensions.Options;
using WebConfigurations.Models;
using WebConfigurations.Middlewares;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
//UseIIS() => w3wp.exe (IIS) or iisexpress.exe (IIS Express)

//v1.
//var appDbConstr = new AppDbConstr();
//var connectionSection = builder.Configuration.GetSection("AppDbConstr");
//connectionSection.Bind(appDbConstr);

//v2.
//var connectionSection = builder.Configuration.GetSection(AppDbConstr.APPDB_CONSTR);
//var appDbConstr = connectionSection.Get<AppDbConstr>()

//v3.
var connectionSection = builder.Configuration.GetSection(AppDbConstr.APPDB_CONSTR);
builder.Services.Configure<AppDbConstr>(connectionSection);

var sampleSection = builder.Configuration.GetSection(SampleConfig.SAMPLE_CONFIG_SECTION_NAME);
//builder.Services.Configure<SampleConfig>(sampleSection);
builder.Services
    .AddOptions<SampleConfig>()
    .Bind(sampleSection)
    .ValidateDataAnnotations()
    .Validate(config =>
            {
                if (config.Key2.ToString() == config.Key1)
                {
                    return false;
                }
                return true;
            }, "Key 1 and Key2 values should not be same");
//OptionsBuilder<SampleConfig> optionsBuilder = builder.Services.AddOptions<SampleConfig>();
//optionsBuilder = optionsBuilder.Bind(sampleSection);
//optionsBuilder = optionsBuilder.ValidateDataAnnotations();

var app = builder.Build();

//AppDbConstr appDbConstr = null;
//using (var scope = app.Services.CreateScope())
//{
//    var configuredInstance = scope.ServiceProvider.GetRequiredService<IOptions<AppDbConstr>>();
//    appDbConstr = configuredInstance.Value;
//}

app.UseConnectionStringMiddleware();
app.Run(
    async (context) =>
    {
        await context.Response.WriteAsync("\nThat's the connection string\n");
    });

//app.MapGet("/", () => System.Diagnostics.Process.GetCurrentProcess().ProcessName);
//app.MapGet("/", () => builder.Configuration.GetConnectionString("DefaultConnection"));
//app.MapGet("/", () => appDbConstr??=new AppDbConstr());

app.Run();
