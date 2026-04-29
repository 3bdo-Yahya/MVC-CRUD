using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visual.Models;
using Visual.Models.Database;
using Visual.Models.ViewModels;

namespace Visual.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Course
        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
            return View(courses);
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            return View(course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View(new CourseFormViewModel());
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    Title = model.Title,
                    Description = model.Description,
                    Hours = model.Hours,
                    Instructor = model.Instructor,
                    Price = model.Price,
                    CreatedAt = DateTime.Now
                };

                _context.Add(course);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Course created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            var model = new CourseFormViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Hours = course.Hours,
                Instructor = course.Instructor,
                Price = course.Price
            };

            return View(model);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseFormViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null) return NotFound();

                try
                {
                    course.Title = model.Title;
                    course.Description = model.Description;
                    course.Hours = model.Hours;
                    course.Instructor = model.Instructor;
                    course.Price = model.Price;

                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Course updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(model.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Course deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id) =>
            _context.Courses.Any(e => e.Id == id);
    }
}
