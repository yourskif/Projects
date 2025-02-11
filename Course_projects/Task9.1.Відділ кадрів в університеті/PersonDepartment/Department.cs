using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityDirectory
{
    public class Department
    {
        [Required(ErrorMessage = "Department name is required.")]
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public Teacher Head { get; set; }
        public Faculty Faculty { get; set; }

        // Конструктор з параметрами
        public Department(string name)
        {
            Name = name;
            Teachers = new List<Teacher>();
            Students = new List<Student>();
        }

        // Конструктор з параметрами
        public Department(string name, Faculty faculty, Teacher head)
        {
            Name = name;
            Faculty = faculty;
            Head = head;
            Teachers = new List<Teacher>();
            Students = new List<Student>();
        }

        // Конструктор без параметрів
        public Department()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }

        // Метод для додавання студента
        public void AddStudent(Student student)
        {
            if (student != null)
            {
                Students.Add(student);
            }
        }

        // Метод для додавання викладача
        public void AddTeacher(Teacher teacher)
        {
            if (teacher != null)
            {
                Teachers.Add(teacher);
            }
        }
    }

    public class Faculty
    {
        [Required(ErrorMessage = "Faculty name is required.")]
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        public Faculty(string name)
        {
            Name = name;
            Departments = new List<Department>();
        }
    }
}

