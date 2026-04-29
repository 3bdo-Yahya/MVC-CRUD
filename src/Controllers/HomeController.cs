using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visual.Models;
using Visual.Models.Database;
using Visual.Models.ViewModels;

namespace Visual.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeDashboardViewModel
            {
                TotalBooks = await _context.Books.CountAsync(),
                AvailableCopies = await _context.Books.SumAsync(b => b.CopiesAvailable),
                UniqueGenres = await _context.Books.Select(b => b.Genre).Distinct().CountAsync(),
                RecentBooks = await _context.Books
                    .OrderByDescending(b => b.CreatedAt)
                    .Take(5)
                    .ToListAsync()
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}