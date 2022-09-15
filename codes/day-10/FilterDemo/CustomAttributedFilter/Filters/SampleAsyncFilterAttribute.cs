using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomAttributedFilter.Filters
{
    public class SampleAsyncFilterAttribute : ActionFilterAttribute
    {
        //private readonly ILogger<SampleAsyncFilterAttribute> _logger;

        private readonly string _controllerName;

        public SampleAsyncFilterAttribute()
        {

        }

        public SampleAsyncFilterAttribute(string controllerName) => (_controllerName) = (controllerName);

        //public SampleAsyncFilterAttribute(ILogger<SampleAsyncFilterAttribute> logger)
        //{
        //    _logger = logger;
        //}
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //_logger.LogInformation($"async: {context.ActionDescriptor.DisplayName} going to get executed");
            Console.WriteLine($"async:{_controllerName??_controllerName} , {context.ActionDescriptor.DisplayName} going to get executed");
            await next();
            //_logger.LogInformation($"async: {context.ActionDescriptor.DisplayName} got executed");
            Console.WriteLine($"async: {_controllerName ?? _controllerName},  {context.ActionDescriptor.DisplayName} got executed");
        }
    }
}
