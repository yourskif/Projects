using Microsoft.EntityFrameworkCore;
using UnivercityDepartment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnivercityDepartment.Services
{
    public class StudentService
    {
        private readonly UnivercityContext _context;

        public StudentService(UnivercityContext context)
        {
            _context = context;
        }

        // Отримання всіх студентів
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        // Отримання студента по ID
        public async Task<Student> GetStudentAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        // Створення студента
        public async Task CreateStudentAsync(Student student)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
        }

        // Оновлення студента
        public async Task UpdateStudentAsync(Student student)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }

        // Перевірка існування студента
        public bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }

        // Отримання всіх факультетів
        public async Task<List<Faculty>> GetFacultiesAsync()
        {
            return await _context.Faculties.ToListAsync();
        }

        // Отримання всіх департаментів
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}




//using UnivercityDepartment.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace UnivercityDepartment.Services
//{
//    public class StudentService
//    {
//        private readonly UnivercityContext _context;

//        // Конструктор для інжекції контексту
//        public StudentService(UnivercityContext context)
//        {
//            _context = context;
//        }

//        // Отримання всіх студентів
//        public async Task<List<Student>> GetAllStudentsAsync()
//        {
//            return await _context.Students
//                                 .Include(s => s.Faculty)
//                                 .Include(s => s.Department)
//                                 .ToListAsync();
//        }

//        // Отримання студента за ID
//        public async Task<Student> GetStudentAsync(int studentId)
//        {
//            return await _context.Students
//                                 .Include(s => s.Faculty)
//                                 .Include(s => s.Department)
//                                 .FirstOrDefaultAsync(s => s.StudentId == studentId);
//        }

//        // Створення нового студента
//        public async Task CreateStudentAsync(Student student)
//        {
//            _context.Students.Add(student);
//            await _context.SaveChangesAsync();
//        }

//        // Оновлення інформації про студента
//        public async Task UpdateStudentAsync(Student student)
//        {
//            _context.Students.Update(student);
//            await _context.SaveChangesAsync();
//        }

//        // Перевірка, чи існує студент за ID
//        public bool StudentExists(int studentId)
//        {
//            return _context.Students.Any(e => e.StudentId == studentId);
//        }
//    }
//}
