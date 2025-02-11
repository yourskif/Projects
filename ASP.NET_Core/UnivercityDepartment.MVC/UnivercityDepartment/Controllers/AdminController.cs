using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnivercityDepartment.Models;

namespace UnivercityDepartment.Controllers
{
    public class AdminController : Controller
    {
        private readonly UnivercityContext _context;

        public AdminController(UnivercityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Отримуємо список всіх департаментів з їх факультетами
            var departments = await _context.Departments
                                            .Include(d => d.Faculty) // Завантажуємо факультет для кожного департаменту
                                            .ToListAsync();

            // Передаємо список департаментів в представлення
            return View(departments);
        }
    }
}
