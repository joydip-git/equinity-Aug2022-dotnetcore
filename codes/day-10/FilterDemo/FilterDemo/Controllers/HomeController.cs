using FilterDemo.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FilterDemo.Controllers
{
    //[TypeFilter(typeof(CustomExceptionFilter))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[TypeFilter(typeof(CustomExceptionFilter))]
        public int Divide()
        {
            int first = 12;
            int second = 0;
            int result = first / second;
            return result;
        }
    }
}
