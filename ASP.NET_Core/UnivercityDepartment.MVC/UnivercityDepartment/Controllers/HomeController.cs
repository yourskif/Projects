using Microsoft.AspNetCore.Mvc;
using UnivercityDepartment.Models;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using UnivercityDepartment.Services;
using System.Linq;

namespace UnivercityDepartment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UniversityService _universityService;
        private readonly FacultyService _facultyService;

        public HomeController(ILogger<HomeController> logger, UniversityService universityService, FacultyService facultyService)
        {
            _logger = logger;
            _universityService = universityService;
            _facultyService = facultyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                if (Path.GetExtension(file.FileName).ToLower() != ".json")
                {
                    TempData["Error"] = "Будь ласка, виберіть файл формату JSON.";
                    return RedirectToAction("Index");
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", file.FileName);
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Data"));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var json = System.IO.File.ReadAllText(filePath);
                var universityData = JsonSerializer.Deserialize<UnivercityData>(json);

                _universityService.SaveUniversityData(universityData);

                TempData["Message"] = "Файл успішно завантажено і збережено в базі даних.";
            }
            else
            {
                TempData["Error"] = "Будь ласка, виберіть файл.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "UnivercityData.json");

            if (System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                var fileName = "UnivercityData.json";

                return File(fileBytes, "application/json", fileName);
            }
            else
            {
                TempData["Error"] = "Файл не знайдено.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ImportFaculties()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "faculties.json");

            await _facultyService.ImportFacultiesFromJsonAsync(filePath);

            TempData["Message"] = "Факультети успішно імпортовані.";
            return RedirectToAction("Index");
        }





    }
}


