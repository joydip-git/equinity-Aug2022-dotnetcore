using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquinityCommerceApp.Web.Controllers
{
    public class CoverTypesController : Controller
    {
        private readonly IApiService<CoverTypeModel> _coverTypeHttpService;
        private readonly ILogger<CoverTypesController> _logger;

        public CoverTypesController(ILogger<CoverTypesController> logger, IApiService<CoverTypeModel> coverTypeHttpService)
        {
            _logger = logger;
            _coverTypeHttpService = coverTypeHttpService;            
        }

        public async Task<IActionResult> Index()
        {
            var result = await _coverTypeHttpService.GetAllAsync();
            return View(result.Record);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoverTypeModel coverTypeModel)
        {
            var response = await _coverTypeHttpService.AddAsync(coverTypeModel);
            if (response.ResponseCode == System.Net.HttpStatusCode.Created)
            {
                TempData["success"] = response.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response.Message;
                return View(coverTypeModel);
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
                var response = await _coverTypeHttpService.GetAsync(id.Value);
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
        public async Task<IActionResult> Edit(CoverTypeModel coverTypeModel)
        {
            if (!ModelState.IsValid)
            {
                return View(coverTypeModel);
            }

            var response = await _coverTypeHttpService.UpdateAsync(coverTypeModel);
            if (response.ResponseCode == System.Net.HttpStatusCode.Created)
            {
                TempData["success"] = response.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = response.Message;
                return View(coverTypeModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound();
            }
            var response = await _coverTypeHttpService.GetAsync(id.Value);
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
                var response = await _coverTypeHttpService.DeleteAsync(id.Value);
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
