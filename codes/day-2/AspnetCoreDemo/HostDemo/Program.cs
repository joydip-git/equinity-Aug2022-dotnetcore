using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//Action<IServiceCollection> serviceCollection;
using IHost host = Host.CreateDefaultBuilder(args)   
    .ConfigureServices((hostContext, services) =>
    {        
        services.AddHostedService<Sample>();
    })
    .Build();
//host.Services.GetRequiredService<Sample>();
//host.Start
await host.RunAsync();
/*
namespace HostDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var builder = Host.CreateDefaultBuilder(args);
            builder = builder.ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Sample>();
            });
            var host = builder.Build();
            host.RunAsync();
        }
    }
*/
