using CustomAttributedFilter.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CustomAttributedFilter.Controllers
{
    [SampleAsyncFilterAttribute(nameof(SampleController))]
    //[SampleActionFilterAttribute(nameof(HomeController))]
    [TypeFilter(typeof(SampleActionFilterAttribute), Arguments = new object[] { nameof(HomeController) })]
    public class SampleController : Controller
    {
        public string Index()
        {
            return $"Hello from {nameof(SampleController)}";
        }
    }
}
