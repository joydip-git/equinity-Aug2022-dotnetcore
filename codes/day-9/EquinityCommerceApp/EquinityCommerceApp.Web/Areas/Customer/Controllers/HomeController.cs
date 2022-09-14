using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services.Base;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EquinityCommerceApp.Web.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var response = await unitOfWork.ProductService.GetAllAsync();
            if (response.ResponseCode == System.Net.HttpStatusCode.Found)
            {
                return View(response.Record);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Details(int? id = 0)
        {
            var response = await unitOfWork.ProductService.GetAsync(id.Value);
            if (response.ResponseCode == System.Net.HttpStatusCode.Found)
            {
                return View(new ShoppingCart { Count = 1, Product = response.Record });
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}