using System;
using System.Linq;

namespace UniversityDirectory
{
    public static class PrintMethods
    {
        // Метод для виводу даних
        public static void Print(University university)
        {
            Console.WriteLine("Введені дані:");

            foreach (var faculty in university.Faculties)
            {
                Console.WriteLine($"Факультет: {faculty.Name}");

                foreach (var department in faculty.Departments)
                {
                    Console.WriteLine($"  Кафедра: {department.Name}");
                    if (department.Head != null)
                    {
                        Console.WriteLine($"    Завідувач кафедри: {department.Head.LastName} {department.Head.FirstName}");
                    }
                    else
                    {
                        Console.WriteLine("    Завідувача немає.");
                    }

                    Console.WriteLine("    Викладачі:");
                    var teachers = department.Teachers;
                    if (teachers.Any())
                    {
                        foreach (var teacher in teachers)
                        {
                            Console.WriteLine($"      {teacher.LastName} {teacher.FirstName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("      Викладачів немає.");
                    }

                    Console.WriteLine("    Студенти:");
                    if (department.Students.Any())
                    {
                        foreach (var student in department.Students)
                        {
                            Console.WriteLine($"      {student.LastName} {student.FirstName}, Група: {student.Group}, Профільна кафедра: {student.Department.Name}, Староста: {student.ClassRepresentative}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("      Студентів немає.");
                    }
                }
            }
        }

        // 1. Вивести усіх студентів
        //public static void PrintAllStudents(University university)
        //{
        //    var students = university.GetStudents();
        //    foreach (var student in students)
        //    {
        //        Console.WriteLine($"{student.LastName} {student.FirstName} {student.Phone} {student.Faculty?.Name ?? "Невизначений факультет"} {student.Department.Name} {(student.ClassRepresentative ? "(Староста)" : "")}");
        //    }
        //}


        public static void PrintAllStudents(University university)
        {
            Console.WriteLine("Виберіть сортування: 1 - за ПІБ, 2 - за факультетом, 3 - за групою, 4 - за кафедрою");
            var sortBy = Console.ReadLine();

            SortingOption sortingOption = sortBy switch
            {
                "1" => SortingOption.Name,
                "2" => SortingOption.Faculty,
                "3" => SortingOption.Group,
                "4" => SortingOption.Department,
                _ => SortingOption.Name // Default sorting
            };

            var students = university.GetStudents(s => true, sortingOption);
            if (!students.Any())
            {
                Console.WriteLine("Студентів не знайдено.");
                return;
            }

            foreach (var student in students)
            {
                string departmentName = student.Department?.Name ?? "Невизначена кафедра";
                string facultyName = student.Department?.Faculty?.Name ?? "Невизначений факультет";

                Console.WriteLine($"{student.LastName} {student.FirstName} {student.Group} {facultyName} {departmentName} {(student.ClassRepresentative ? "(Староста)" : "")}");
            }
        }



        // 2. Вивести студентів без батьків
        public static void PrintStudentsWithoutParents(University university)
        {
            Console.WriteLine("Студенти без батьків:");

            // Вибір параметра сортування
            SortingOption sortingOption = SortingOption.Name; // Задайте тип сортування, якщо потрібно

            // Передайте і predicate, і sortingOption
            var studentsWithoutParents = university.GetStudents(s => s.Parent == null, sortingOption);
            foreach (var student in studentsWithoutParents)
            {
                Console.WriteLine($"{student.LastName} {student.FirstName} (Група: {student.Group}, Кафедра: {student.Department.Name})");
            }
        }

        // 3. Вивести усіх викладачів
        public static void PrintAllTeachers(University university)
        {
            Console.WriteLine("Усі викладачі:");
            foreach (var faculty in university.Faculties)
            {
                foreach (var department in faculty.Departments)
                {
                    foreach (var teacher in department.Teachers)
                    {
                        Console.WriteLine($"{teacher.LastName} {teacher.FirstName} ({department.Name})");
                    }
                }
            }
        }

        // 4. Вивести усіх завідувачів кафедр
        public static void PrintAllDepartmentHeads(University university)
        {
            Console.WriteLine("Завідувачі кафедр:");
            foreach (var faculty in university.Faculties)
            {
                foreach (var department in faculty.Departments)
                {
                    if (department.Head != null)
                    {
                        Console.WriteLine($"{department.Head.LastName} {department.Head.FirstName} ({department.Name})");
                    }
                }
            }
        }

        // 5. Вивести групи без старост та кафедри без завідувачів
        public static void PrintStudentsWithoutClassRepsAndDepartmentHeads(University university)
        {
            Console.WriteLine("Групи без старост:");
            foreach (var faculty in university.Faculties)
            {
                foreach (var department in faculty.Departments)
                {
                    var studentsWithoutClassReps = department.Students.Where(s => !s.ClassRepresentative).ToList();
                    if (studentsWithoutClassReps.Any())
                    {
                        Console.WriteLine($"Кафедра: {department.Name}");
                        foreach (var student in studentsWithoutClassReps)
                        {
                            Console.WriteLine($"{student.LastName} {student.FirstName} (Група: {student.Group})");
                        }
                    }
                }
            }

            Console.WriteLine("Кафедри без завідувачів:");
            foreach (var faculty in university.Faculties)
            {
                foreach (var department in faculty.Departments)
                {
                    if (department.Head == null)
                    {
                        Console.WriteLine($"Кафедра: {department.Name}");
                    }
                }
            }
        }

        // 6. Пошук дітей-студентів у заданого батька
        public static void FindStudentsByParent(University university)
        {
            Console.WriteLine("Введіть прізвище батька:");
            var parentLastName = Console.ReadLine();

            var parent = university.GetParents().FirstOrDefault(p => p.LastName.Equals(parentLastName, StringComparison.OrdinalIgnoreCase));
            if (parent != null)
            {
                var children = parent.Children;
                if (children.Count > 0)
                {
                    Console.WriteLine($"Діти студенти батька {parent.LastName}:");
                    foreach (var child in children)
                    {
                        Console.WriteLine($"{child.LastName} {child.FirstName} (Група: {child.Group})");
                    }
                }
                else
                {
                    Console.WriteLine($"У батька {parent.LastName} немає дітей-студентів.");
                }
            }
            else
            {
                Console.WriteLine($"Батька з прізвищем {parentLastName} не знайдено.");
            }
        }

        // 7. Вивести викладачів, які мають дітей-студентів
        public static void PrintTeachersWithStudentChildren(University university)
        {
            Console.WriteLine("Викладачі, які мають дітей-студентів:");
            foreach (var faculty in university.Faculties)
            {
                foreach (var department in faculty.Departments)
                {
                    foreach (var teacher in department.Teachers)
                    {
                        // Перевірка, чи має викладач дітей-студентів
                        var hasStudentChildren = department.Students.Any(s => s.Parent == teacher.Parent && teacher.Parent != null);
                        if (hasStudentChildren)
                        {
                            Console.WriteLine($"{teacher.FullName} ({department.Name})");
                        }
                    }
                }
            }
        }





    }
}
