using FilterDemo.Filters;
using FilterDemo.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace FilterDemo.Controllers
{
    [CustomFactoryFilterFactory]
    [MiddlewareFilter(typeof(FilterMiddlewarePipeline))]
    public class SampleController : Controller
    {
        public string Index()
        {
            return $"Hello from {nameof(SampleController)}";
        }
    }
}
