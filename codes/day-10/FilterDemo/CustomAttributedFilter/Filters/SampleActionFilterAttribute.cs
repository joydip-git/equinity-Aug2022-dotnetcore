using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomAttributedFilter.Filters
{
    public class SampleActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger<SampleActionFilterAttribute> _logger;
        private readonly string _controllerName;

        public SampleActionFilterAttribute()
        {

        }
        public SampleActionFilterAttribute(ILogger<SampleActionFilterAttribute> logger, string controllerName) => (_logger, _controllerName) = (logger, controllerName);

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"{_controllerName ?? _controllerName}, {context.ActionDescriptor.DisplayName} got executed");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"{_controllerName ?? _controllerName}, {context.ActionDescriptor.DisplayName} going to get executed");
        }
    }
}
