using CachingDemo.ClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;
using DistributedCacheHelper;

namespace CachingDemo.ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDistributedCache _distributedCache;

        public HomeController(ILogger<HomeController> logger, IDistributedCache distributedCache) =>
       (_logger, _distributedCache) = (logger, distributedCache);

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = null;
            products = await _distributedCache.GetDataAsync<IEnumerable<Product>>("ProductRecordsList");
            if (products == null)
            {
                using (var client = new HttpClient())
                {
                    products = await client.GetFromJsonAsync<IEnumerable<Product>>("https://localhost:7140/api/Products");

                }
                await _distributedCache.SetDataAsync<IEnumerable<Product>>("ProductRecordsList", products, TimeSpan.FromSeconds(60));
                TempData["message"] = "From Database";
            }
            else
            {
                TempData["message"] = "From Cache";
            }
            return View(products);
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