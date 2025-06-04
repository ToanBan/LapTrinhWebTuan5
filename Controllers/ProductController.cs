using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanStore.Models;

namespace WebBanStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");

            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Product product, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var imageDirectory = Path.Combine("wwwroot", "images");
                if (!Directory.Exists(imageDirectory))
                {
                    Directory.CreateDirectory(imageDirectory);
                }

                var filePath = Path.Combine(imageDirectory, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }
                product.ImageUrl = "/images/" + fileName;
            }
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var categories = _context.Categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var deleteProduct = _context.Products.FirstOrDefault(x=>x.Id == id);
            if (deleteProduct != null)
            {
                _context.Products.Remove(deleteProduct);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products
                    .Include(p => p.Category)
                    .FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = _context.Categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        public IActionResult Edit(int id, Product product, IFormFile ImageFile)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var imageDirectory = Path.Combine("wwwroot", "images");

                if (!Directory.Exists(imageDirectory))
                {
                    Directory.CreateDirectory(imageDirectory);
                }

                var filePath = Path.Combine(imageDirectory, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                existingProduct.ImageUrl = "/images/" + fileName;
            }

            _context.Products.Update(existingProduct);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Display(int id)
        {
            var product = _context.Products.FirstOrDefault(x=> x.Id == id);
            if(product == null) { return NotFound(); }  
            return View(product);
        }
    }

}
