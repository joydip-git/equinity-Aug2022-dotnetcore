using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filters
{
    public class CustomFactoryFilterFactory : Attribute, IFilterFactory
    {
        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) => new InternalCustomFilter();


        private class InternalCustomFilter : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
                Console.WriteLine($"{context.ActionDescriptor.DisplayName} got executed");
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                Console.WriteLine($"{context.ActionDescriptor.DisplayName} going to get executed");
            }
        }
    }
}
