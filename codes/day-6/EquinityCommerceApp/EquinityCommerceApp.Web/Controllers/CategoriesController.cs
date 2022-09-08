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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CategoryModel category)
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
        public IActionResult Edit([FromBody] CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            return View();
        }
    }
}
