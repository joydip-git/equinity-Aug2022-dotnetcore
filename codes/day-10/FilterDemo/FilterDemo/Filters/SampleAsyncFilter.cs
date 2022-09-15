using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filters
{
    public class SampleAsyncFilter : IAsyncActionFilter
    {
        private readonly ILogger<SampleAsyncFilter> _logger;

        public SampleAsyncFilter(ILogger<SampleAsyncFilter> logger)
        {
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation($"async: {context.ActionDescriptor.DisplayName} going to get executed");
            await next();
            _logger.LogInformation($"async: {context.ActionDescriptor.DisplayName} got executed");
        }
    }
}
