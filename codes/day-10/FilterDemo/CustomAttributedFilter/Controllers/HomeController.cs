using CustomAttributedFilter.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CustomAttributedFilter.Controllers
{
    [SampleAsyncFilterAttribute(nameof(HomeController))]
    //[SampleActionFilterAttribute(nameof(HomeController))]
    [TypeFilter(typeof(SampleActionFilterAttribute), Arguments = new object[] { nameof(HomeController) }, Order = 0)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
