using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityDirectory
{
    public class University
    {
        public List<Faculty> Faculties { get; set; } = new List<Faculty>();

        // Метод для отримання всіх студентів
        public List<Student> GetStudents()
        {
            return Faculties.SelectMany(f => f.Departments.SelectMany(d => d.Students)).ToList();
        }

        public List<Student> GetStudents(Func<Student, bool> predicate, SortingOption option)
        {
            var students = Faculties.SelectMany(f => f.Departments.SelectMany(d => d.Students))
                                     .Where(predicate)
                                     .ToList();

            switch (option)
            {
                case SortingOption.Name:
                    return students.OrderBy(s => s.FullName).ToList();
                case SortingOption.Faculty:
                    return students.OrderBy(s => s.Department?.Faculty?.Name).ToList(); // Додано перевірку на null
                case SortingOption.Group:
                    return students.OrderBy(s => s.GroupName).ToList();
                case SortingOption.Department:
                    return students.OrderBy(s => s.Department?.Name).ToList(); // Додано перевірку на null
                default:
                    return students;
            }
        }

        public List<Parent> GetParents()
        {
            var parents = new List<Parent>();
            foreach (var faculty in Faculties)
            {
                foreach (var department in faculty.Departments)
                {
                    foreach (var student in department.Students)
                    {
                        if (student.Parent != null)
                        {
                            parents.Add(student.Parent);
                        }
                    }
                }
            }
            return parents.Distinct().ToList(); // Додано Distinct для уникальності батьків
        }

        // Метод для видалення студента за ідентифікатором
        public void RemoveStudentById(int studentId)
        {
            foreach (var faculty in Faculties)
            {
                foreach (var department in faculty.Departments)
                {
                    var student = department.Students.FirstOrDefault(s => s.StudentId == studentId);
                    if (student != null)
                    {
                        department.Students.Remove(student);
                        return;
                    }
                }
            }
        }

        // Метод для видалення всіх студентів
        public void RemoveAllStudents()
        {
            foreach (var faculty in Faculties)
            {
                foreach (var department in faculty.Departments)
                {
                    department.Students.Clear();
                }
            }
        }
    }

    public enum SortingOption
    {
        Default,  // Додано значення за замовчуванням
        Name,
        Faculty,
        Group,
        Department
    }
}


