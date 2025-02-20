using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityDirectory
{
    public enum Gender
    {
        Male,
        Female
    }

    // Базовий клас Person
    public class Person
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string Address { get; set; }

        public Person(string firstName, string lastName, string middleName, Gender gender, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Gender = gender;
            Address = address;
        }

        // Властивість для отримання повного імені
        public string FullName => $"{FirstName} {LastName} {MiddleName}";
    }

    // Клас Student, що наслідується від Person
    public class Student : Person
    {
        [Required(ErrorMessage = "Group is required.")]
        public int StudentId { get; set; } 

        public string Group { get; set; }

        public Parent Parent { get; set; } = new Parent("Unknown", "Unknown", false); 
        public Department Department { get; set; } = new Department("No Department"); 
        public Faculty Faculty { get; set; } = new Faculty("No Faculty"); 

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; } // Додаємо властивість телефону

        public bool ClassRepresentative { get; set; } // Представник класу

        // Конструктор
        public Student(string firstName, string lastName, string middleName, Gender gender, string address, string group, Parent parent = null, Department department = null, Faculty faculty = null, string phone = null, bool classRepresentative = false)
            : base(firstName, lastName, middleName, gender, address)
        {
            Group = group;
            Parent = parent ?? new Parent("Unknown", "Unknown", false); // Ініціалізація, якщо parent = null
            Department = department ?? new Department("No Department"); // Ініціалізація, якщо department = null
            Faculty = faculty ?? new Faculty("No Faculty"); // Ініціалізація, якщо faculty = null
            Phone = phone; // Присвоюємо номер телефону
            ClassRepresentative = classRepresentative;

            // Якщо вказаний батько, додаємо студента до списку дітей
            Parent.AddChild(this);
        }

        // Властивість для отримання назви групи
        public string GroupName => Group;

        // Властивість для отримання назви відділу або інформації про його відсутність
        public string DepartmentName => Department.Name;

        // Метод для виводу інформації про студента
        public void PrintInfo()
        {
            Console.WriteLine($"Student: {FullName}, Group: {Group}, Department: {DepartmentName}, Phone: {Phone}");
        }
    }

    // Клас Teacher, що наслідується від Person
    public class Teacher : Person
    {
        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }

        [JsonIgnore] // Ігноруємо під час серіалізації, щоб уникнути циклів
        public Parent Parent { get; set; } // Додаємо батька

        // Конструктор з батьком
        public Teacher(string firstName, string lastName, string middleName, Gender gender, string address, string subject, Parent parent = null)
            : base(firstName, lastName, middleName, gender, address)
        {
            Subject = subject;
            Parent = parent ?? new Parent("Unknown", "Unknown", false); // Ініціалізація

            // Якщо вказаний батько, додаємо викладача до списку дітей
            Parent.AddChild(null); 
        }
    }

    public class Parent
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [JsonIgnore] // Ігноруємо під час серіалізації, щоб уникнути циклів
        public List<Student> Children { get; set; } // Діти

        public bool IsTeacher { get; set; } // Властивість, що вказує, чи є батько викладачем

        // Конструктор з параметрами
        public Parent(string firstName, string lastName, bool isTeacher)
        {
            FirstName = firstName;
            LastName = lastName;
            IsTeacher = isTeacher; // Встановлюємо, чи є батько викладачем
            Children = new List<Student>(); // Ініціалізація списку дітей
        }

        // Додати дитину до списку дітей
        public void AddChild(Student child)
        {
            if (child != null)
                Children.Add(child);
        }

        // Метод для отримання імені батька 
        public string FullName => $"{FirstName} {LastName}";
    }
}



