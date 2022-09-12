using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquinityCommerceApp.Web.Controllers
{
    public class CoverTypesController : Controller
    {
        //private readonly IApiService<CoverTypeModel> _coverTypeHttpService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CoverTypesController> _logger;

        //public CoverTypesController(ILogger<CoverTypesController> logger, IApiService<CoverTypeModel> coverTypeHttpService)
        public CoverTypesController(ILogger<CoverTypesController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            //_coverTypeHttpService = coverTypeHttpService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            //var result = await _coverTypeHttpService.GetAllAsync();
            var result = await _unitOfWork.CoverTypeService.GetAllAsync();
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
            //var response = await _coverTypeHttpService.AddAsync(coverTypeModel);
            var response = await _unitOfWork.CoverTypeService.AddAsync(coverTypeModel);
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
                //var response = await _coverTypeHttpService.GetAsync(id.Value);
                var response = await _unitOfWork.CoverTypeService.GetAsync(id.Value);
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

            //var response = await _coverTypeHttpService.UpdateAsync(coverTypeModel);
            var response = await _unitOfWork.CoverTypeService.UpdateAsync(coverTypeModel);
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
            //var response = await _coverTypeHttpService.GetAsync(id.Value);
            var response = await _unitOfWork.CoverTypeService.GetAsync(id.Value);
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
                //var response = await _coverTypeHttpService.DeleteAsync(id.Value);
                var response = await _unitOfWork.CoverTypeService.DeleteAsync(id.Value);
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
