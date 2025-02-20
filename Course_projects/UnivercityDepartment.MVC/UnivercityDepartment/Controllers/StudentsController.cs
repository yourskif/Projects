using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnivercityDepartment.Models;

namespace UnivercityDepartment.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UnivercityContext _context;

        public StudentsController(UnivercityContext context)
        {
            _context = context;
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewBag.FacultyId = new SelectList(_context.Faculties, "FacultyId", "FacultyName");
            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,MiddleName,Gender,FacultyId,DepartmentId,Address,Group")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.FacultyId = new SelectList(_context.Faculties, "FacultyId", "FacultyName", student.FacultyId);
            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.Include(s => s.Faculty).Include(s => s.Department).ToListAsync();
            return View(students);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.FacultyId = new SelectList(_context.Faculties, "FacultyId", "FacultyName", student.FacultyId);
            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,LastName,MiddleName,Gender,FacultyId,DepartmentId,Address,Group")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Students.Any(e => e.StudentId == student.StudentId))
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

            ViewBag.FacultyId = new SelectList(_context.Faculties, "FacultyId", "FacultyName", student.FacultyId);
            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Faculty)
                .Include(s => s.Department)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Delete/14
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students
                .Include(s => s.Faculty) // ����������� Faculty
                .Include(s => s.Department) // ����������� Department
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }



    }
}

