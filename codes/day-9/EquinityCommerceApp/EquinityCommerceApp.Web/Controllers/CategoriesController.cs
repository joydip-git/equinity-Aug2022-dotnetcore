using AutoMapper;
using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace EquinityCommerceApp.Web.Controllers
{
    public class CategoriesController : Controller
    {        
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<CategoriesController> _logger;
       
        public CategoriesController(ILogger<CategoriesController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;   
        }

        public async Task<IActionResult> Index()
        {
            var result = await unitOfWork.CategoryService.GetAllAsync();
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
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "Name and DisplayOrder should not be same");
            }
            if (ModelState.IsValid)
            {
                var response = await unitOfWork.CategoryService.AddAsync(category);
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
            else
                return View(category);
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
                var response = await unitOfWork.CategoryService.GetAsync(id.Value);
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
            var response = await unitOfWork.CategoryService.UpdateAsync(category);
            if (response.ResponseCode == System.Net.HttpStatusCode.OK)
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
            var response = await unitOfWork.CategoryService.GetAsync(id.Value);
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
                var response = await unitOfWork.CategoryService.DeleteAsync(id.Value);
                if (response.ResponseCode == System.Net.HttpStatusCode.OK)
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
