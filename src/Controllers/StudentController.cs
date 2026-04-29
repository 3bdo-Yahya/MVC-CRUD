using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visual.Models;
using Visual.Models.Database;
using Visual.Models.ViewModels;

namespace Visual.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View(new StudentFormViewModel());
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = model.Name,
                    Age = model.Age,
                    Email = model.Email,
                    Phone = model.Phone,
                    CreatedAt = DateTime.Now
                };

                _context.Add(student);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Student created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            var model = new StudentFormViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                Email = student.Email,
                Phone = student.Phone
            };

            return View(model);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentFormViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null) return NotFound();

                try
                {
                    student.Name = model.Name;
                    student.Age = model.Age;
                    student.Email = model.Email;
                    student.Phone = model.Phone;

                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Student updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(model.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Student deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id) =>
            _context.Students.Any(e => e.Id == id);
    }
}

