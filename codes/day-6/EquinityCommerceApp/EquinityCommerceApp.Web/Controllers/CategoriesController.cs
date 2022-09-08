using AutoMapper;
using EquinityCommerceApp.Web.Entities;
using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EquinityCommerceApp.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly EquinityAppDbContext _context;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;

        public CategoriesController(EquinityAppDbContext context, ILogger<CategoriesController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList<Category>();
            var result = _mapper.Map<IEnumerable<CategoryModel>>(categories);
            return View(result);
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
            await _context.Categories.AddAsync(_mapper.Map<Category>(category));
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                TempData["error"] = "Could not add category";
                return View(category);
            }
            else
            {
                TempData["success"] = "category added sucessfully";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);
            return View(_mapper.Map<CategoryModel>(category));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //update the category model to include the categoryid, passed to this action through 'id' route data, since it is not being bound to any element in the view, hence will not be present in the model by default
        //public async Task<IActionResult> Edit(CategoryModel category, int? id=0)

        //use the hidden field to include categoryid also, since it is not being bound to any element in the view, hence will not be present in the model by default
        public async Task<IActionResult> Edit(CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Update(_mapper.Map<Category>(category));
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                TempData["error"] = "Could not update category";
                return View(category);
            }
            else
            {
                TempData["success"] = "category updated sucessfully";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id == 0)
            {
                return NotFound();
            }
            else
            {
                var found = await _context.Categories.FindAsync(id);
                var category = _mapper.Map<CategoryModel>(found);
                return View(category);
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
                var found = await _context.Categories.FindAsync(id);
                _context.Categories.Remove(found);
               var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    TempData["error"] = "Could not delete category";
                    return View(_mapper.Map<CategoryModel>(found));
                }
                else
                {
                    TempData["success"] = "category deleted sucessfully";
                    return RedirectToAction("Index");
                }
            }
        }
    }
}
