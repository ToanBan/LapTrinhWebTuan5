﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanStore.Models;

namespace WebBanStore.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IActionResult Index()
        {
            var books = _context.books.Include(b => b.Category).ToList();
            return View(books);
        }

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "CategoryName");
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Book book, IFormFile ImageFile)
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
                book.Image = "/images/" + fileName;
            }

            if (ModelState.IsValid)
            {
                _context.books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var categories = _context.categories.ToList();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "CategoryName");
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var deleteBook = _context.books.FirstOrDefault(book => book.BookId == id);
            if (deleteBook != null)
            {
                _context.books.Remove(deleteBook);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }

        public IActionResult DisPlay(int id)
        {
            var displayBook = _context.books.FirstOrDefault(b => b.BookId == id);
            if (displayBook == null)
            {
                return NotFound();
            }
            return View(displayBook);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(_context.categories, "CategoryId", "CategoryName", book.CategoryId);
            return View(book);
        }


        public IActionResult Edit(int id, Book book, IFormFile ImageFile)
        {
            var existingBook = _context.books.FirstOrDefault(b => b.BookId == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            existingBook.Description = book.Description;
            existingBook.CategoryId = book.CategoryId;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                existingBook.Image = "/images/" + fileName;
            }

            _context.books.Update(existingBook);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
