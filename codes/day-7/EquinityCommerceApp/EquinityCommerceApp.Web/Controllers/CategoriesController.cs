using AutoMapper;
using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquinityCommerceApp.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IApiService<CategoryModel> _categoryHttpService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger, IApiService<CategoryModel> categoryHttpService)
        {
            _logger = logger;
            _categoryHttpService = categoryHttpService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryHttpService.GetAllAsync();
            return View(result.Record);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel category)
        {
            var response =  await _categoryHttpService.AddAsync(category);
            if (response.ResponseCode == System.Net.HttpStatusCode.Created)
            {
                TempData["success"] = response.Message;
                return RedirectToAction("Index");                
            }
            else
            {
                TempData["error"] = response.Message;
                return View(category);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var response = await _categoryHttpService.GetAsync(id.Value);
                if (response.ResponseCode == System.Net.HttpStatusCode.Found)
                {
                    TempData["success"] = response.Message;
                    return View(response.Record);
                }
                else
                {
                    TempData["error"] = response.Message;
                    return NotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var response = await _categoryHttpService.UpdateAsync(category);
            if (response.ResponseCode == System.Net.HttpStatusCode.Created)
            {
                TempData["success"] = response.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response.Message;
                return View(category);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound();
            }
            var response = await _categoryHttpService.GetAsync(id.Value);
            if (response.ResponseCode == System.Net.HttpStatusCode.Found)
            {
                TempData["success"] = response.Message;
                return View(response.Record);
            }
            else
            {
                TempData["error"] = response.Message;
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound();
            }
            else
            {
                var response = await _categoryHttpService.DeleteAsync(id.Value);
                if (response.ResponseCode == System.Net.HttpStatusCode.Found)
                {
                    TempData["success"] = response.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = response.Message;
                    return NotFound();
                }
            }
        }
    }
}
