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

        //// Додати методи для підтвердження видалення студентів
        //[HttpGet]
        //public IActionResult DeleteStudent(int id)
        //{
        //    var student = _universityService.GetStudentById(id);  // Метод для отримання студента
        //    if (student == null)
        //    {
        //        TempData["Error"] = "Студента не знайдено.";
        //        return RedirectToAction("Index");
        //    }

        //    return View(student);  // Відображаємо сторінку підтвердження видалення
        //}

        //[HttpPost, ActionName("DeleteStudent")]
        //public IActionResult DeleteConfirmedStudent(int id)
        //{
        //    var student = _universityService.GetStudentById(id);
        //    if (student != null)
        //    {
        //        _universityService.DeleteStudent(id);  // Видалення студента
        //        TempData["Message"] = "Студента успішно видалено.";
        //    }
        //    else
        //    {
        //        TempData["Error"] = "Не вдалося видалити студента.";
        //    }

        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public IActionResult DeleteStudent(int id)
        //{
        //    var student = _universityService.GetStudentById(id);  // Метод для отримання студента
        //    if (student == null)
        //    {
        //        TempData["Error"] = "Студента не знайдено.";
        //        return RedirectToAction("Index");
        //    }

        //    return View(student);  // Відображаємо сторінку підтвердження видалення
        //}

        //[HttpPost, ActionName("DeleteStudent")]
        //public IActionResult DeleteConfirmedStudent(int id)
        //{
        //    var student = _universityService.GetStudentById(id);
        //    if (student != null)
        //    {
        //        _universityService.DeleteStudent(id);  // Видалення студента
        //        TempData["Message"] = "Студента успішно видалено.";
        //    }
        //    else
        //    {
        //        TempData["Error"] = "Не вдалося видалити студента.";
        //    }

        //    return RedirectToAction("Index");
        //}


        // Додати методи для підтвердження видалення вчителів
        //[HttpGet]
        //public IActionResult DeleteTeacher(int id)
        //{
        //    var teacher = _universityService.GetTeacherById(id);  // Метод для отримання вчителя
        //    if (teacher == null)
        //    {
        //        TempData["Error"] = "Вчителя не знайдено.";
        //        return RedirectToAction("Index");
        //    }

        //    return View(teacher);  // Відображаємо сторінку підтвердження видалення
        //}

        //[HttpPost, ActionName("DeleteTeacher")]
        //public IActionResult DeleteConfirmedTeacher(int id)
        //{
        //    var teacher = _universityService.GetTeacherById(id);
        //    if (teacher != null)
        //    {
        //        _universityService.DeleteTeacher(id);  // Видалення вчителя
        //        TempData["Message"] = "Вчителя успішно видалено.";
        //    }
        //    else
        //    {
        //        TempData["Error"] = "Не вдалося видалити вчителя.";
        //    }

        //    return RedirectToAction("Index");
        //}



    }
}




//using Microsoft.AspNetCore.Mvc;
//using UnivercityDepartment.Models;
//using System.IO;
//using System.Threading.Tasks;
//using System.Text.Json;
//using UnivercityDepartment.Services;

//namespace UnivercityDepartment.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;
//        private readonly UniversityService _universityService;  // Замінили на правильний сервіс
//        private readonly FacultyService _facultyService;

//        public HomeController(ILogger<HomeController> logger, UniversityService universityService, FacultyService facultyService)
//        {
//            _logger = logger;
//            _universityService = universityService;  // Правильний сервіс для роботи з даними університету
//            _facultyService = facultyService;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> UploadFile(IFormFile file)
//        {
//            if (file != null && file.Length > 0)
//            {
//                if (Path.GetExtension(file.FileName).ToLower() != ".json")
//                {
//                    TempData["Error"] = "Будь ласка, виберіть файл формату JSON.";
//                    return RedirectToAction("Index");
//                }

//                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", file.FileName);
//                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Data"));

//                using (var stream = new FileStream(filePath, FileMode.Create))
//                {
//                    await file.CopyToAsync(stream);
//                }

//                var json = System.IO.File.ReadAllText(filePath);
//                var universityData = JsonSerializer.Deserialize<UnivercityData>(json);

//                // Викликаємо метод SaveUniversityData через правильний сервіс
//                _universityService.SaveUniversityData(universityData);

//                TempData["Message"] = "Файл успішно завантажено і збережено в базі даних.";
//            }
//            else
//            {
//                TempData["Error"] = "Будь ласка, виберіть файл.";
//            }

//            return RedirectToAction("Index");
//        }

//        [HttpGet]
//        public IActionResult DownloadFile()
//        {
//            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "UnivercityData.json");

//            if (System.IO.File.Exists(filePath))
//            {
//                var fileBytes = System.IO.File.ReadAllBytes(filePath);
//                var fileName = "UnivercityData.json";

//                return File(fileBytes, "application/json", fileName);
//            }
//            else
//            {
//                TempData["Error"] = "Файл не знайдено.";
//                return RedirectToAction("Index");
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> ImportFaculties()
//        {
//            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "faculties.json");

//            await _facultyService.ImportFacultiesFromJsonAsync(filePath);

//            TempData["Message"] = "Факультети успішно імпортовані.";
//            return RedirectToAction("Index");
//        }
//    }
//}




////using Microsoft.AspNetCore.Mvc;
////using UnivercityDepartment.Models;
////using System.IO;
////using System.Threading.Tasks;
////using System.Text.Json;
////using UnivecityDepartment.Models;
////using UnivercityDepartment.Services;

////namespace UnivercityDepartment.Controllers
////{
////    public class HomeController : Controller
////    {
////        private readonly ILogger<HomeController> _logger;
////        private readonly UnivercityContext _universityService;
////        private readonly FacultyService _facultyService; // Додаємо FacultyService

////        // Оновлений конструктор для інжекції залежностей
////        public HomeController(ILogger<HomeController> logger, UnivercityContext universityService, FacultyService facultyService)
////        {
////            _logger = logger;
////            _universityService = universityService;
////            _facultyService = facultyService; // Ініціалізація FacultyService
////        }

////        // Головна сторінка
////        public IActionResult Index()
////        {
////            return View();
////        }

////        // Метод для завантаження файлів (JSON)
////        [HttpPost]
////        public async Task<IActionResult> UploadFile(IFormFile file)
////        {
////            if (file != null && file.Length > 0)
////            {
////                if (Path.GetExtension(file.FileName).ToLower() != ".json")
////                {
////                    TempData["Error"] = "Будь ласка, виберіть файл формату JSON.";
////                    return RedirectToAction("Index");
////                }

////                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", file.FileName);
////                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Data"));

////                using (var stream = new FileStream(filePath, FileMode.Create))
////                {
////                    await file.CopyToAsync(stream);
////                }

////                // Завантажуємо дані з JSON
////                var json = System.IO.File.ReadAllText(filePath);
////                var universityData = JsonSerializer.Deserialize<UnivercityData>(json);

////                // Зберігаємо дані в базі
////                _universityService.SaveUniversityData(universityData);

////                TempData["Message"] = "Файл успішно завантажено і збережено в базі даних.";
////            }
////            else
////            {
////                TempData["Error"] = "Будь ласка, виберіть файл.";
////            }

////            return RedirectToAction("Index");
////        }

////        // Метод для завантаження файлів з сервера
////        [HttpGet]
////        public IActionResult DownloadFile()
////        {
////            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "UnivercityData.json");

////            if (System.IO.File.Exists(filePath))
////            {
////                var fileBytes = System.IO.File.ReadAllBytes(filePath);
////                var fileName = "UnivercityData.json";

////                return File(fileBytes, "application/json", fileName);
////            }
////            else
////            {
////                TempData["Error"] = "Файл не знайдено.";
////                return RedirectToAction("Index");
////            }
////        }

////        // Метод для імпорту факультетів з JSON
////        [HttpPost]
////        public async Task<IActionResult> ImportFaculties()
////        {
////            // Вказуємо шлях до вашого JSON файлу
////            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "faculties.json");

////            // Викликаємо метод для імпорту факультетів
////            await _facultyService.ImportFacultiesFromJsonAsync(filePath);

////            // Після імпорту повертаємо на головну сторінку
////            TempData["Message"] = "Факультети успішно імпортовані.";
////            return RedirectToAction("Index");
////        }
////    }
////}



