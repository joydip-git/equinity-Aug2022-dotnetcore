using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services.Base;
using EquinityCommerceApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EquinityCommerceApp.Web.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductsController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsController(ILogger<ProductsController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id = 0)
        {
            var categoryList = await GetCategoriesAsSelecList();
            var coverTypeyList = await GetCoverTypesAsSelecList();
            UpsertViewModel viewModel = new UpsertViewModel
            {
                CategoryList = categoryList,
                CoverTypeyList = coverTypeyList
            };
            if (!id.HasValue || id == 0)
            {
                //create
                return View(viewModel);
            }
            else
            {
                //update
                var response = await unitOfWork.ProductService.GetAsync(id.Value);
                if (response.ResponseCode == System.Net.HttpStatusCode.Found)
                {
                    viewModel.Product = response.Record;
                    return View(viewModel);
                }
                else
                    return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UpsertViewModel vm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file is not null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploadFilePath = Path.Combine(webHostEnvironment.WebRootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName);

                    if (vm.Product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(webHostEnvironment.WebRootPath, vm.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var stream = new FileStream(Path.Combine(uploadFilePath, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var imageUrl = $@"\images\products\{fileName}{extension}";
                    vm.Product.ImageUrl = imageUrl;
                }
                ApiResponseModel<ProductModel> response = null;
                if (vm.Product.Id == 0)
                {
                    response = await unitOfWork.ProductService.AddAsync(vm.Product);
                }
                else
                {
                    response = await unitOfWork.ProductService.UpdateAsync(vm.Product);
                }

                if (response.ResponseCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["success"] = response.Message;
                    return RedirectToAction("Index");
                }
                else if (response.ResponseCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["success"] = response.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = response.Message;
                    return View(vm);
                }
            }
            else
                return View(vm);
        }


        #region API Calls
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await unitOfWork.ProductService.GetAllAsync();
            return Json(new { data = response.Record });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRecord(int? id = 0)
        {
            var result = await unitOfWork.ProductService.GetAsync(id.Value);
            if (result.Record == null)
            {
                return Json(new { success = false, message = result.Message });
            }
            var response = await unitOfWork.ProductService.DeleteAsync(id.Value);
            if (response.ResponseCode == System.Net.HttpStatusCode.OK)
            {
                var oldImagePath = Path.Combine(webHostEnvironment.WebRootPath, response.Record.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
                return Json(new { success = true, message = response.Message });
            }
            else
            {
                return Json(new { success = false, message = response.Message });
            }

        }
        #endregion

        #region Helper Methods
        private async Task<IEnumerable<SelectListItem>> GetCategoriesAsSelecList()
        {
            var response = await unitOfWork.CategoryService.GetAllAsync();
            if (response.ResponseCode == System.Net.HttpStatusCode.Found)
            {
                return response.Record.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            }
            return null;
        }
        private async Task<IEnumerable<SelectListItem>> GetCoverTypesAsSelecList()
        {
            var response = await unitOfWork.CoverTypeService.GetAllAsync();
            if (response.ResponseCode == System.Net.HttpStatusCode.Found)
            {
                return response.Record.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            }
            return null;
        }
        #endregion
    }
}
