using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnivercityDepartment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace UnivercityDepartment.Controllers
{
    public class TeachersController : Controller
    {
        private readonly UnivercityContext _context;

        public TeachersController(UnivercityContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var teachers = _context.Teachers.Include(t => t.Department).Include(t => t.Faculty);
            return View(await teachers.ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .Include(t => t.Department)
                .Include(t => t.Faculty)
                .FirstOrDefaultAsync(m => m.TeacherId == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Faculties = new SelectList(_context.Faculties, "FacultyId", "FacultyName");
            return View();
        }

        // POST: Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,FirstName,LastName,DepartmentId,FacultyId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", teacher.DepartmentId);
            ViewBag.Faculties = new SelectList(_context.Faculties, "FacultyId", "FacultyName", teacher.FacultyId);
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", teacher.DepartmentId);
            ViewBag.Faculties = new SelectList(_context.Faculties, "FacultyId", "FacultyName", teacher.FacultyId);
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,FirstName,LastName,DepartmentId,FacultyId")] Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Teachers.Any(e => e.TeacherId == id))
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

            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", teacher.DepartmentId);
            ViewBag.Faculties = new SelectList(_context.Faculties, "FacultyId", "FacultyName", teacher.FacultyId);
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .Include(t => t.Department)
                .Include(t => t.Faculty)
                .FirstOrDefaultAsync(m => m.TeacherId == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}







//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using UnivercityDepartment.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Linq;
//using System.Threading.Tasks;

//namespace UnivercityDepartment.Controllers
//{
//    public class TeachersController : Controller
//    {
//        private readonly UnivercityContext _context;

//        public TeachersController(UnivercityContext context)
//        {
//            _context = context;
//        }

//        // GET: Teachers
//        public async Task<IActionResult> Index()
//        {
//            var teachers = _context.Teachers.Include(t => t.Department).Include(t => t.Faculty);
//            return View(await teachers.ToListAsync());
//        }

//        // GET: Teachers/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var teacher = await _context.Teachers
//                .Include(t => t.Department)
//                .Include(t => t.Faculty)
//                .FirstOrDefaultAsync(m => m.TeacherId == id);

//            if (teacher == null)
//            {
//                return NotFound();
//            }

//            return View(teacher);
//        }

//        // GET: Teachers/Create
//        public IActionResult Create()
//        {
//            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
//            ViewBag.Faculties = new SelectList(_context.Faculties, "FacultyId", "FacultyName");
//            return View();
//        }

//        // POST: Teachers/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("TeacherId,FirstName,LastName,DepartmentId,FacultyId")] Teacher teacher)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(teacher);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }

//            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", teacher.DepartmentId);
//            ViewBag.Faculties = new SelectList(_context.Faculties, "FacultyId", "FacultyName", teacher.FacultyId);
//            return View(teacher);
//        }

//        // GET: Teachers/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var teacher = await _context.Teachers.FindAsync(id);
//            if (teacher == null)
//            {
//                return NotFound();
//            }

//            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", teacher.DepartmentId);
//            ViewBag.Faculties = new SelectList(_context.Faculties, "FacultyId", "FacultyName", teacher.FacultyId);
//            return View(teacher);
//        }

//        // POST: Teachers/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,FirstName,LastName,DepartmentId,FacultyId")] Teacher teacher)
//        {
//            if (id != teacher.TeacherId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(teacher);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!_context.Teachers.Any(e => e.TeacherId == id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }

//            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", teacher.DepartmentId);
//            ViewBag.Faculties = new SelectList(_context.Faculties, "FacultyId", "FacultyName", teacher.FacultyId);
//            return View(teacher);
//        }

//        // GET: Teachers/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var teacher = await _context.Teachers
//                .Include(t => t.Department)
//                .Include(t => t.Faculty)
//                .FirstOrDefaultAsync(m => m.TeacherId == id);

//            if (teacher == null)
//            {
//                return NotFound();
//            }

//            return View(teacher);
//        }

//        // POST: Teachers/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var teacher = await _context.Teachers.FindAsync(id);
//            if (teacher != null)
//            {
//                _context.Teachers.Remove(teacher);
//                await _context.SaveChangesAsync();
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}

