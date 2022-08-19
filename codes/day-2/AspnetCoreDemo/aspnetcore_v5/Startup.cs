using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_v5
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //RequestDelegate: public delegate Task RequestDelegate(HttpContext context);
            app.Use(
               async (context, next) =>
                {
                    await context.Response.WriteAsync("1. middleware1 request\n");
                    await next();
                    await context.Response.WriteAsync("2. middleware1 response\n");
                }
                );
            app.Use(
               async (context, next) =>
               {
                   await context.Response.WriteAsync("3. middleware2 request\n");
                   await next();
                   await context.Response.WriteAsync("4. middleware2 response\n");
               }
                );


            app.Run(
               async (context) =>
                {
                    await context.Response.WriteAsync("Hello World!\n");
                }
                );
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!\n");
            //    });
            //});
        }
    }
}
