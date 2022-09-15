using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filters
{
    public class SampleActionFilter : IActionFilter
    {
        private readonly ILogger<SampleActionFilter> _logger;

        public SampleActionFilter(ILogger<SampleActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"{context.ActionDescriptor.DisplayName} got executed");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"{context.ActionDescriptor.DisplayName} going to get executed");
        }
    }
}
