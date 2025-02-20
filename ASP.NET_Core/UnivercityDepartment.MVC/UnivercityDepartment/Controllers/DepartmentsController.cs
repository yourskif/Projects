using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnivercityDepartment.Models;

namespace UnivercityDepartment.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly UnivercityContext _context;

        public DepartmentsController(UnivercityContext context)
        {
            _context = context;
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            // Створення списку факультетів для вибору
            ViewBag.FacultyId = new SelectList(_context.Faculties, "FacultyId", "FacultyName");
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentName,FacultyId")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Якщо є помилки в моделі, передаємо факультети для випадаючого списку
            ViewBag.FacultyId = new SelectList(_context.Faculties, "FacultyId", "FacultyName", department.FacultyId);
            return View(department);
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            // Завантажуємо список відділів разом з факультетами
            var departments = await _context.Departments
                .Include(d => d.Faculty)
                .ToListAsync();

            return View(departments);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Faculty)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            // Створення списку факультетів для редагування
            ViewBag.FacultyId = new SelectList(_context.Faculties, "FacultyId", "FacultyName", department.FacultyId);
            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,DepartmentName,FacultyId")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Якщо є помилки в моделі, передаємо факультети для випадаючого списку
            ViewBag.FacultyId = new SelectList(_context.Faculties, "FacultyId", "FacultyName", department.FacultyId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Faculty)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/DeleteConfirmed/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}

