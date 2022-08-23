using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WebConfigurations.Models;

namespace WebConfigurations.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConnectionStringMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<AppDbConstr> _options;
        private readonly IOptions<SampleConfig> _sampleOptions;
        private readonly ILogger<ConnectionStringMiddleware> _logger;

        public ConnectionStringMiddleware(RequestDelegate next, IOptions<AppDbConstr> options, IOptions<SampleConfig> sampleOptions, ILoggerFactory loggerFactory)
        {
            _next = next;
            _options = options;
            _sampleOptions = sampleOptions;
            _logger = loggerFactory.CreateLogger<ConnectionStringMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync(_options.Value.ToString());
            await _next(httpContext);
            //await httpContext.Response.WriteAsync(_sampleOptions.Value.ToString());
            try
            {
                var sampleConfig = _sampleOptions.Value;
                await httpContext.Response.WriteAsync(_sampleOptions.Value.ToString());
            }
            catch (OptionsValidationException ex)
            {
                ex.Failures.ToList<string>().ForEach(e => _logger.LogError(e));
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConnectionStringMiddlewareExtensions
    {
        public static IApplicationBuilder UseConnectionStringMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConnectionStringMiddleware>();
        }
    }
}
