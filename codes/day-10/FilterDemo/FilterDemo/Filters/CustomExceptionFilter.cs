using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filters
{
    public class CustomExceptionFilter : IExceptionFilter//IAsyncExceptionFilter
    {
        private readonly IHostEnvironment _environment;

        public CustomExceptionFilter(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            if (!_environment.IsDevelopment())
            {
                return;
            }
            context.Result = new ContentResult
            {
                Content = $"Message: {context.Exception.Message}, {Environment.NewLine}Details: {context.Exception.StackTrace}"
            };
        }

        //public Task OnExceptionAsync(ExceptionContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
