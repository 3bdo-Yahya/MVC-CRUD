using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visual.Models;
using Visual.Models.Database;
using Visual.Models.ViewModels;

namespace Visual.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchTerm)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();
                query = query.Where(b => b.Title.ToLower().Contains(term) || b.Author.ToLower().Contains(term));
            }

            ViewData["SearchTerm"] = searchTerm;
            var books = await query.OrderByDescending(b => b.CreatedAt).ToListAsync();
            return View(books);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult Create()
        {
            return View(new BookFormViewModel { PublishedYear = DateTime.UtcNow.Year, CopiesAvailable = 1 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var book = new Book
            {
                Title = model.Title.Trim(),
                Author = model.Author.Trim(),
                Genre = model.Genre.Trim(),
                PublishedYear = model.PublishedYear,
                CopiesAvailable = model.CopiesAvailable,
                CreatedAt = DateTime.UtcNow
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Book created successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var model = new BookFormViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear,
                CopiesAvailable = book.CopiesAvailable
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookFormViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = model.Title.Trim();
            book.Author = model.Author.Trim();
            book.Genre = model.Genre.Trim();
            book.PublishedYear = model.PublishedYear;
            book.CopiesAvailable = model.CopiesAvailable;

            await _context.SaveChangesAsync();
            TempData["Success"] = "Book updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Book deleted successfully.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
