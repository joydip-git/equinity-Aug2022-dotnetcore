using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filters
{
    
    public class CustomResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            //IAlwaysRunResultFilter alwaysRunResultFilter = null;
            if(context.Result is not EmptyResult)
            {
                await next();
            }
            else
            {
                context.Cancel = true;
            }
        }
    }
}
