using System.Collections.Generic;
using System.Linq;
using UnivercityDepartment.Models;

namespace UnivercityDepartment.Services
{
    public class UniversityService
    {
        private readonly UnivercityContext _context;

        public UniversityService(UnivercityContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Зберігає дані університету (факультети, кафедри, студенти, вчителі) у базу даних.
        /// </summary>
        public void SaveUniversityData(UnivercityData universityData)
        {
            if (universityData == null)
                throw new ArgumentNullException(nameof(universityData));

            // Перевірка та ініціалізація колекцій
            universityData.Faculties ??= new List<Faculty>();
            universityData.Departments ??= new List<Department>();
            universityData.Students ??= new List<Student>();
            universityData.Teachers ??= new List<Teacher>();

            // Додавання факультетів, якщо їх ще немає в базі даних
            foreach (var faculty in universityData.Faculties)
            {
                if (!_context.Faculties.Any(f => f.FacultyId == faculty.FacultyId))
                {
                    _context.Faculties.Add(faculty);
                }
            }

            // Додавання кафедр, якщо їх ще немає
            foreach (var department in universityData.Departments)
            {
                if (!_context.Departments.Any(d => d.DepartmentId == department.DepartmentId))
                {
                    _context.Departments.Add(department);
                }
            }

            // Додавання студентів
            foreach (var student in universityData.Students)
            {
                var facultyExists = _context.Faculties.Any(f => f.FacultyId == student.FacultyId);
                var departmentExists = _context.Departments.Any(d => d.DepartmentId == student.DepartmentId);

                if (facultyExists && departmentExists)
                {
                    if (!_context.Students.Any(s => s.StudentId == student.StudentId))
                    {
                        _context.Students.Add(student);
                    }
                }
                else
                {
                    // Логіка для обробки ситуації, коли факультет або кафедра не існують
                    // Логувати помилку чи створювати відповідний запис?
                }
            }

            // Додавання вчителів
            foreach (var teacher in universityData.Teachers)
            {
                var departmentExists = _context.Departments.Any(d => d.DepartmentId == teacher.DepartmentId);

                if (departmentExists)
                {
                    if (!_context.Teachers.Any(t => t.TeacherId == teacher.TeacherId))
                    {
                        _context.Teachers.Add(teacher);
                    }
                }
                else
                {
                    // Логіка для обробки ситуації, коли кафедра не існує
                }
            }

            // Зберегти всі зміни
            _context.SaveChanges();
        }

        /// <summary>
        /// Отримує вчителя за ідентифікатором.
        /// </summary>
        public Teacher GetTeacherById(int id)
        {
            return _context.Teachers.FirstOrDefault(t => t.TeacherId == id);
        }

        /// <summary>
        /// Отримує всіх вчителів.
        /// </summary>
        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        /// <summary>
        /// Додає нового вчителя.
        /// </summary>
        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            if (!_context.Teachers.Any(t => t.TeacherId == teacher.TeacherId))
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Оновлює дані про вчителя.
        /// </summary>
        public void UpdateTeacher(Teacher updatedTeacher)
        {
            var existingTeacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == updatedTeacher.TeacherId);
            if (existingTeacher != null)
            {
                existingTeacher.FirstName = updatedTeacher.FirstName;
                existingTeacher.LastName = updatedTeacher.LastName;
                existingTeacher.DepartmentId = updatedTeacher.DepartmentId;

                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Видаляє вчителя за ідентифікатором.
        /// </summary>
        public bool DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return false; // Вчитель не знайдений
            }

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return true; // Вчитель успішно видалений
        }


        /// <summary>
        /// Отримує студента за ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор студента.</param>
        /// <returns>Об'єкт Student, якщо знайдено, або null.</returns>
        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.StudentId == id);
        }

        /// <summary>
        /// Видаляє студента за ідентифікатором.
        /// </summary>
        /// <param name="id">Ідентифікатор студента.</param>
        /// <returns>True, якщо видалення успішне; інакше False.</returns>
        public bool DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }
            return false;
        }



    }
}





//using System.Collections.Generic;
//using System.Linq;
//using UnivercityDepartment.Models;

//namespace UnivercityDepartment.Services
//{
//    public class UniversityService
//    {
//        private readonly UnivercityContext _context;

//        public UniversityService(UnivercityContext context)
//        {
//            _context = context;
//        }

//        public void SaveUniversityData(UnivercityData universityData)
//        {
//            // Перевірка на null і ініціалізація списків, якщо вони не задані
//            if (universityData.Faculties == null)
//            {
//                universityData.Faculties = new List<Faculty>();
//            }

//            if (universityData.Departments == null)
//            {
//                universityData.Departments = new List<Department>();
//            }

//            // Додавання факультетів (якщо потрібно)
//            foreach (var faculty in universityData.Faculties)
//            {
//                // Тут ваш код для додавання факультетів до бази даних, якщо потрібно
//                // Приклад:
//                // _context.Faculties.Add(faculty);
//            }

//            // Додавання студентів
//            foreach (var student in universityData.Students)
//            {
//                // Переконатися, що FacultyId і DepartmentId є валідними
//                var faculty = universityData.Faculties.FirstOrDefault(f => f.FacultyId == student.FacultyId);
//                var department = universityData.Departments.FirstOrDefault(d => d.DepartmentId == student.DepartmentId);

//                if (faculty != null && department != null)
//                {
//                    // Додаємо студента, якщо факультет і кафедра знайдені
//                    // Тут ваш код для додавання студента в базу даних або в список
//                    // Приклад:
//                    // _context.Students.Add(student);
//                }
//                else
//                {
//                    // Логіка для обробки помилки, якщо факультет чи кафедра не знайдені
//                    // Можна додати повідомлення про помилку або виконати інші дії
//                }
//            }

//            // Зберігаємо зміни в базі даних
//            // _context.SaveChanges();
//        }
//    }
//}




////using System.Collections.Generic;
////using System.Linq;
////using UnivercityDepartment.Models;

////namespace UnivercityDepartment.Services
////{
////    public class UniversityService
////    {
////        private readonly UnivercityContext _context;

////        public UniversityService(UnivercityContext context)
////        {
////            _context = context;
////        }

////        public void SaveUniversityData(UnivercityData universityData)
////        {
////            // Перевірка на null і ініціалізація списків, якщо вони не задані
////            if (universityData.Faculties == null)
////            {
////                universityData.Faculties = new List<Faculty>();
////            }

////            if (universityData.Departments == null)
////            {
////                universityData.Departments = new List<Department>();
////            }

////            if (universityData.Teachers == null)
////            {
////                universityData.Teachers = new List<Teacher>(); // Ініціалізація вчителів, якщо вони не задані
////            }

////            if (universityData.Students == null)
////            {
////                universityData.Students = new List<Student>(); // Ініціалізація студентів, якщо вони не задані
////            }

////            // Додавання факультетів (якщо потрібно)
////            foreach (var faculty in universityData.Faculties)
////            {
////                var existingFaculty = _context.Faculties
////                    .FirstOrDefault(f => f.FacultyId == faculty.FacultyId);
////                if (existingFaculty == null)
////                {
////                    _context.Faculties.Add(faculty);  // Додати факультет, якщо його немає в базі
////                }
////            }

////            // Додавання кафедр
////            foreach (var department in universityData.Departments)
////            {
////                var existingDepartment = _context.Departments
////                    .FirstOrDefault(d => d.DepartmentId == department.DepartmentId);
////                if (existingDepartment == null)
////                {
////                    _context.Departments.Add(department);  // Додати кафедру, якщо її немає в базі
////                }
////            }

////            // Додавання вчителів
////            foreach (var teacher in universityData.Teachers)
////            {
////                // Переконатися, що FacultyId і DepartmentId є валідними
////                var faculty = universityData.Faculties.FirstOrDefault(f => f.FacultyId == teacher.FacultyId);
////                var department = universityData.Departments.FirstOrDefault(d => d.DepartmentId == teacher.DepartmentId);

////                if (faculty != null && department != null)
////                {
////                    // Додаємо вчителя, якщо факультет і кафедра знайдені
////                    var existingTeacher = _context.Teachers
////                        .FirstOrDefault(t => t.TeacherId == teacher.TeacherId);
////                    if (existingTeacher == null)
////                    {
////                        _context.Teachers.Add(teacher);  // Додаємо вчителя в базу
////                    }
////                }
////                else
////                {
////                    // Логіка для обробки помилки, якщо факультет чи кафедра не знайдені
////                    // Можна додати повідомлення про помилку або виконати інші дії
////                }
////            }

////            // Додавання студентів
////            foreach (var student in universityData.Students)
////            {
////                // Переконатися, що FacultyId і DepartmentId є валідними
////                var faculty = universityData.Faculties.FirstOrDefault(f => f.FacultyId == student.FacultyId);
////                var department = universityData.Departments.FirstOrDefault(d => d.DepartmentId == student.DepartmentId);

////                if (faculty != null && department != null)
////                {
////                    // Додаємо студента, якщо факультет і кафедра знайдені
////                    var existingStudent = _context.Students
////                        .FirstOrDefault(s => s.StudentId == student.StudentId);
////                    if (existingStudent == null)
////                    {
////                        _context.Students.Add(student);  // Додаємо студента в базу
////                    }
////                }
////                else
////                {
////                    // Логіка для обробки помилки, якщо факультет чи кафедра не знайдені
////                    // Можна додати повідомлення про помилку або виконати інші дії
////                }
////            }

////            // Зберігаємо зміни в базі даних
////            _context.SaveChanges();
////        }
////    }
////}





//using System.Collections.Generic;
//using System.Linq;
//using UnivercityDepartment.Models;

//namespace UnivercityDepartment.Services
//{
//    public class UniversityService
//    {
//        private readonly UnivercityContext _context;

//        public UniversityService(UnivercityContext context)
//        {
//            _context = context;
//        }

//        public void SaveUniversityData(UnivercityData universityData)
//        {
//            // Перевірка на null і ініціалізація списків, якщо вони не задані
//            if (universityData.Faculties == null)
//            {
//                universityData.Faculties = new List<Faculty>();
//            }

//            if (universityData.Departments == null)
//            {
//                universityData.Departments = new List<Department>();
//            }

//            // Додавання факультетів (якщо потрібно)
//            foreach (var faculty in universityData.Faculties)
//            {
//                // Тут ваш код для додавання факультетів до бази даних, якщо потрібно
//                // Приклад:
//                // _context.Faculties.Add(faculty);
//            }

//            // Додавання студентів
//            foreach (var student in universityData.Students)
//            {
//                // Переконатися, що FacultyId і DepartmentId є валідними
//                var faculty = universityData.Faculties.FirstOrDefault(f => f.FacultyId == student.FacultyId);
//                var department = universityData.Departments.FirstOrDefault(d => d.DepartmentId == student.DepartmentId);

//                if (faculty != null && department != null)
//                {
//                    // Додаємо студента, якщо факультет і кафедра знайдені
//                    // Тут ваш код для додавання студента в базу даних або в список
//                    // Приклад:
//                    // _context.Students.Add(student);
//                }
//                else
//                {
//                    // Логіка для обробки помилки, якщо факультет чи кафедра не знайдені
//                    // Можна додати повідомлення про помилку або виконати інші дії
//                }
//            }

//            // Зберігаємо зміни в базі даних
//            // _context.SaveChanges();
//        }
//    }
//}
