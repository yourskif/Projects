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
                    TempData["Error"] = "���� �����, ������� ���� ������� JSON.";
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

                TempData["Message"] = "���� ������ ����������� � ��������� � ��� �����.";
            }
            else
            {
                TempData["Error"] = "���� �����, ������� ����.";
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
                TempData["Error"] = "���� �� ��������.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ImportFaculties()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "faculties.json");

            await _facultyService.ImportFacultiesFromJsonAsync(filePath);

            TempData["Message"] = "���������� ������ �����������.";
            return RedirectToAction("Index");
        }

<<<<<<< HEAD

=======
        //// ������ ������ ��� ������������ ��������� ��������
        //[HttpGet]
        //public IActionResult DeleteStudent(int id)
        //{
        //    var student = _universityService.GetStudentById(id);  // ����� ��� ��������� ��������
        //    if (student == null)
        //    {
        //        TempData["Error"] = "�������� �� ��������.";
        //        return RedirectToAction("Index");
        //    }

        //    return View(student);  // ³��������� ������� ������������ ���������
        //}

        //[HttpPost, ActionName("DeleteStudent")]
        //public IActionResult DeleteConfirmedStudent(int id)
        //{
        //    var student = _universityService.GetStudentById(id);
        //    if (student != null)
        //    {
        //        _universityService.DeleteStudent(id);  // ��������� ��������
        //        TempData["Message"] = "�������� ������ ��������.";
        //    }
        //    else
        //    {
        //        TempData["Error"] = "�� ������� �������� ��������.";
        //    }

        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public IActionResult DeleteStudent(int id)
        //{
        //    var student = _universityService.GetStudentById(id);  // ����� ��� ��������� ��������
        //    if (student == null)
        //    {
        //        TempData["Error"] = "�������� �� ��������.";
        //        return RedirectToAction("Index");
        //    }

        //    return View(student);  // ³��������� ������� ������������ ���������
        //}

        //[HttpPost, ActionName("DeleteStudent")]
        //public IActionResult DeleteConfirmedStudent(int id)
        //{
        //    var student = _universityService.GetStudentById(id);
        //    if (student != null)
        //    {
        //        _universityService.DeleteStudent(id);  // ��������� ��������
        //        TempData["Message"] = "�������� ������ ��������.";
        //    }
        //    else
        //    {
        //        TempData["Error"] = "�� ������� �������� ��������.";
        //    }

        //    return RedirectToAction("Index");
        //}


        // ������ ������ ��� ������������ ��������� �������
        //[HttpGet]
        //public IActionResult DeleteTeacher(int id)
        //{
        //    var teacher = _universityService.GetTeacherById(id);  // ����� ��� ��������� �������
        //    if (teacher == null)
        //    {
        //        TempData["Error"] = "������� �� ��������.";
        //        return RedirectToAction("Index");
        //    }

        //    return View(teacher);  // ³��������� ������� ������������ ���������
        //}

        //[HttpPost, ActionName("DeleteTeacher")]
        //public IActionResult DeleteConfirmedTeacher(int id)
        //{
        //    var teacher = _universityService.GetTeacherById(id);
        //    if (teacher != null)
        //    {
        //        _universityService.DeleteTeacher(id);  // ��������� �������
        //        TempData["Message"] = "������� ������ ��������.";
        //    }
        //    else
        //    {
        //        TempData["Error"] = "�� ������� �������� �������.";
        //    }

        //    return RedirectToAction("Index");
        //}
>>>>>>> 127cb1402c24a36e580ce7bbe022610c18889c32



    }
}


<<<<<<< HEAD
=======


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
//        private readonly UniversityService _universityService;  // ������� �� ���������� �����
//        private readonly FacultyService _facultyService;

//        public HomeController(ILogger<HomeController> logger, UniversityService universityService, FacultyService facultyService)
//        {
//            _logger = logger;
//            _universityService = universityService;  // ���������� ����� ��� ������ � ������ ������������
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
//                    TempData["Error"] = "���� �����, ������� ���� ������� JSON.";
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

//                // ��������� ����� SaveUniversityData ����� ���������� �����
//                _universityService.SaveUniversityData(universityData);

//                TempData["Message"] = "���� ������ ����������� � ��������� � ��� �����.";
//            }
//            else
//            {
//                TempData["Error"] = "���� �����, ������� ����.";
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
//                TempData["Error"] = "���� �� ��������.";
//                return RedirectToAction("Index");
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> ImportFaculties()
//        {
//            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "faculties.json");

//            await _facultyService.ImportFacultiesFromJsonAsync(filePath);

//            TempData["Message"] = "���������� ������ �����������.";
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
////        private readonly FacultyService _facultyService; // ������ FacultyService

////        // ��������� ����������� ��� �������� �����������
////        public HomeController(ILogger<HomeController> logger, UnivercityContext universityService, FacultyService facultyService)
////        {
////            _logger = logger;
////            _universityService = universityService;
////            _facultyService = facultyService; // ������������ FacultyService
////        }

////        // ������� �������
////        public IActionResult Index()
////        {
////            return View();
////        }

////        // ����� ��� ������������ ����� (JSON)
////        [HttpPost]
////        public async Task<IActionResult> UploadFile(IFormFile file)
////        {
////            if (file != null && file.Length > 0)
////            {
////                if (Path.GetExtension(file.FileName).ToLower() != ".json")
////                {
////                    TempData["Error"] = "���� �����, ������� ���� ������� JSON.";
////                    return RedirectToAction("Index");
////                }

////                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", file.FileName);
////                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Data"));

////                using (var stream = new FileStream(filePath, FileMode.Create))
////                {
////                    await file.CopyToAsync(stream);
////                }

////                // ����������� ���� � JSON
////                var json = System.IO.File.ReadAllText(filePath);
////                var universityData = JsonSerializer.Deserialize<UnivercityData>(json);

////                // �������� ���� � ���
////                _universityService.SaveUniversityData(universityData);

////                TempData["Message"] = "���� ������ ����������� � ��������� � ��� �����.";
////            }
////            else
////            {
////                TempData["Error"] = "���� �����, ������� ����.";
////            }

////            return RedirectToAction("Index");
////        }

////        // ����� ��� ������������ ����� � �������
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
////                TempData["Error"] = "���� �� ��������.";
////                return RedirectToAction("Index");
////            }
////        }

////        // ����� ��� ������� ���������� � JSON
////        [HttpPost]
////        public async Task<IActionResult> ImportFaculties()
////        {
////            // ������� ���� �� ������ JSON �����
////            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "faculties.json");

////            // ��������� ����� ��� ������� ����������
////            await _facultyService.ImportFacultiesFromJsonAsync(filePath);

////            // ϳ��� ������� ��������� �� ������� �������
////            TempData["Message"] = "���������� ������ �����������.";
////            return RedirectToAction("Index");
////        }
////    }
////}



>>>>>>> 127cb1402c24a36e580ce7bbe022610c18889c32
