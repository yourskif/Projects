using System;
using System.Collections.Generic;

namespace UniversityDirectory
{
    internal static class DataInitializer
    {
        public static void InitializeData(University university)
        {
            var faculty1 = new Faculty("Факультет комп'ютерних наук");
            var faculty2 = new Faculty("Факультет фізики");

            var department1 = new Department("Кафедра програмування") { Faculty = faculty1 };
            var department2 = new Department("Кафедра теоретичної фізики") { Faculty = faculty2 };
            var department3 = new Department("Кафедра системного аналізу") { Faculty = faculty1 };

            faculty1.Departments.Add(department1);
            faculty1.Departments.Add(department3);
            faculty2.Departments.Add(department2);

            university.Faculties.Add(faculty1);
            university.Faculties.Add(faculty2);

            // Ініціалізація батьків (деякі з них є викладачами)
            var parent1 = new Parent("Іван", "Шевченко", true); // Іван - викладач
            var parent2 = new Parent("Ольга", "Коваленко", false); // Ольга - не викладач
            var parent3 = new Parent("Марія", "Петренко", true); // Марія - викладач, тепер додамо її як батька

            // Ініціалізація викладачів (один з них є батьком студента)
            var teacher1 = new Teacher("Сергій", "Іваненко", "Олександрович", Gender.Male, "Київ", "Програмування", parent1); // Сергій - батько
            var teacher2 = new Teacher("Марія", "Петренко", "Степанівна", Gender.Female, "Львів", "Фізика", parent3); // Тепер вона також має батька

            // Призначення викладачів на кафедри
            department1.Teachers.Add(teacher1);
            department2.Teachers.Add(teacher2);

            // Встановлення завідувачів кафедр
            department1.Head = teacher1; // Завідувач кафедри програмування
            department2.Head = teacher2; // Завідувач кафедри теоретичної фізики

            // Ініціалізація студентів з номерами телефонів (один студент є дитиною викладача)
            var student1 = new Student("Андрій", "Шевченко", "Ігорович", Gender.Male, "Київ", "К-321", parent1, department3, faculty1, "123-456-7890", true);
            var student2 = new Student("Анна", "Коваленко", "Сергіївна", Gender.Female, "Львів", "К-123", parent2, department1, faculty1, "098-765-4321");
            var student3 = new Student("Олег", "Петренко", "Миколайович", Gender.Male, "Львів", "Ф-888", parent3, department2, faculty2, "444-444-4444", true); // Новий студент Марії

            // Додаємо студентів до кафедр
            department1.Students.Add(student2);
            department2.Students.Add(new Student("Дмитро", "Павленко", "Олександрович", Gender.Male, "Харків", "Ф-777", null, department2, faculty2, "555-555-5555"));
            department3.Students.Add(student1);
            department2.Students.Add(student3); // Додаємо нового студента до кафедри фізики

            // Призначення старост
            student1.ClassRepresentative = true; // Андрій - староста групи К-321
            student2.ClassRepresentative = false; // Анна - не староста
            student3.ClassRepresentative = true; // Олег - староста групи Ф-888

            // Перевірка, чи викладачі мають студентів
            //CheckIfStudentsHaveTeacherParents(department1.Students);
            //CheckIfStudentsHaveTeacherParents(department2.Students);
            //CheckIfStudentsHaveTeacherParents(department3.Students);
        }

/*
        // Метод для перевірки, чи студент має батька-викладача
        private static void CheckIfStudentsHaveTeacherParents(List<Student> students)
        {
            foreach (var student in students)
            {
                if (student.Parent != null)
                {
                    if (student.Parent.IsTeacher)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName} є дитиною викладача {student.Parent.FirstName} {student.Parent.LastName}.");
                    }
                    else
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName} не має батька-викладача.");
                    }
                }
                else
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} не має зазначеного батька.");
                }
            }
        }

        public static void PrintStudentsWithTeacherParents(University university)
        {
            Console.WriteLine("Студенти, які є дітьми викладачів:");
            foreach (var faculty in university.Faculties)
            {
                foreach (var department in faculty.Departments)
                {
                    foreach (var student in department.Students)
                    {
                        if (student.Parent != null && student.Parent.IsTeacher)
                        {
                            Console.WriteLine($"{student.FullName} є дитиною викладача {student.Parent.FirstName} {student.Parent.LastName}.");
                        }
                    }
                }
            }
        }

        // Метод для виводу викладачів, які мають дітей-студентів
        public static void PrintTeachersWithStudentChildren(University university)
        {
            Console.WriteLine("Викладачі, які мають дітей-студентів:");
            foreach (var faculty in university.Faculties)
            {
                foreach (var department in faculty.Departments)
                {
                    foreach (var teacher in department.Teachers)
                    {
                        // Перевірка чи має викладач дітей-студентів
                        var hasStudentChildren = department.Students.Any(s => s.Parent != null && s.Parent.FirstName == teacher.Parent?.FirstName && s.Parent.LastName == teacher.Parent?.LastName);
                        if (hasStudentChildren)
                        {
                            Console.WriteLine($"{teacher.FullName} ({department.Name})");
                        }
                    }
                }
            }
        }
*/
    }
}
