using CachingDemo.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CachingDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static IEnumerable<Product> products = new List<Product>
        {
            new Product{ Id=1, Name="Dell XPS", Price=10000},
            new Product{ Id=2, Name="LenovoS", Price=20000}
        };
        [HttpGet]
        public ActionResult<Product> GetAll()
        {
            return Ok(products);
        }
    }
}
