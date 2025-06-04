using Microsoft.AspNetCore.Mvc;
using WebBanStore.Models;

namespace WebBanStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        

        public IActionResult Create(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                ModelState.AddModelError("categoryName", "Tên danh mục không được để trống.");
                return View("Create");
            }

            var category = new Category
            {
                Name = categoryName
            };

            _context.Categories.Add(category);
            _context.SaveChanges(); 

            return RedirectToAction("Index");

        }
    }
}
