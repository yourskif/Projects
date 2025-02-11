using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnivercityDepartment.Models;
using System.Linq;
using System.Threading.Tasks;

namespace UnivercityDepartment.Controllers
{
    public class FacultiesController : Controller
    {
        private readonly UnivercityContext _context;

        public FacultiesController(UnivercityContext context)
        {
            _context = context; // Ініціалізація контексту бази даних
        }

        // Список факультетів
        public async Task<IActionResult> Index()
        {
            var faculties = await _context.Faculties
                .Include(f => f.Departments) // Включаємо відділи факультетів
                .ToListAsync();
            return View(faculties);
        }

        // GET: Faculties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faculties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacultyName")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faculty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }

        // Деталі факультету
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties
                .Include(f => f.Departments) // Включаємо відділи
                .FirstOrDefaultAsync(f => f.FacultyId == id);

            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }

            // Отримуємо список відділів для випадаючого списку
            ViewData["Departments"] = await _context.Departments.ToListAsync();

            return View(faculty);
        }

        // POST: Faculties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacultyId,FacultyName,SelectedDepartmentId")] Faculty faculty)
        {
            if (id != faculty.FacultyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Faculties.Any(f => f.FacultyId == id))
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
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties
                .FirstOrDefaultAsync(f => f.FacultyId == id);

            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}






//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using UnivercityDepartment.Models;
//using System.Linq;
//using System.Threading.Tasks;

//namespace UnivercityDepartment.Controllers
//{
//    public class FacultiesController : Controller
//    {
//        private readonly UnivercityContext _context;

//        public FacultiesController(UnivercityContext context)
//        {
//            _context = context; // Залишаємо без змін
//        }

//        // Список факультетів
//        public async Task<IActionResult> Index()
//        {
//            var faculties = await _context.Faculties
//                .Include(f => f.Departments)
//                .ToListAsync();
//            return View(faculties);
//        }

//        // GET: Faculties/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Faculties/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("FacultyName")] Faculty faculty)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(faculty);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(faculty);
//        }

//        // Деталі факультету
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var faculty = await _context.Faculties
//                .Include(f => f.Departments)
//                .FirstOrDefaultAsync(f => f.FacultyId == id);

//            if (faculty == null)
//            {
//                return NotFound();
//            }

//            return View(faculty);
//        }

//        // GET: Faculties/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var faculty = await _context.Faculties.FindAsync(id);
//            if (faculty == null)
//            {
//                return NotFound();
//            }
//            return View(faculty);
//        }

//        // POST: Faculties/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("FacultyId,FacultyName")] Faculty faculty)
//        {
//            if (id != faculty.FacultyId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(faculty);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!_context.Faculties.Any(f => f.FacultyId == id))
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
//            return View(faculty);
//        }

//        // GET: Faculties/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var faculty = await _context.Faculties
//                .FirstOrDefaultAsync(f => f.FacultyId == id);
//            if (faculty == null)
//            {
//                return NotFound();
//            }

//            return View(faculty);
//        }

//        // POST: Faculties/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var faculty = await _context.Faculties.FindAsync(id);
//            if (faculty != null)
//            {
//                _context.Faculties.Remove(faculty);
//                await _context.SaveChangesAsync();
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}

