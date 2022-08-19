using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_v5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);
            IHost host = builder.Build();//ConfigureServices is called now
            host.Run();//Configure method gets called now
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var defaultHostBuilder = Host.CreateDefaultBuilder(args);
            var reconfiguredHostBuilder = defaultHostBuilder
                .ConfigureWebHostDefaults(
               (IWebHostBuilder webBuilder) =>
            {
                webBuilder.UseStartup<Startup>();
            });
            return reconfiguredHostBuilder;
        }
    }
}
