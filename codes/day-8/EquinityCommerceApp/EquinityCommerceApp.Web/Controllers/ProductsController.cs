using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace EquinityCommerceApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(int? id = 0)
        {
            if (!id.HasValue || id == 0)
            {
                //create
                return View(new ProductModel());
            }
            else
            {
                //update
                return View(new ProductModel { Id = id.Value });
            }
        }

        public IActionResult Delete(int? id = 0)
        {
            return View();
        }

        #region API Calls
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await unitOfWork.ProductService.GetAllAsync();
            return Json(new { data = response.Record });
        }
        #endregion
    }
}
