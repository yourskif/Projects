using System;
using System.Collections.Generic;

namespace UniversityDirectory
{
    internal static class EditInformation
    {
        // Метод для відображення інформації про запис за номером
        public static void ViewRecordByNumber(University university)
        {
            Console.WriteLine("Введіть номер запису для перегляду (0 для виходу):");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0)
            {
                var students = university.GetStudents();
                if (index <= students.Count)
                {
                    var student = students[index - 1]; // Отримуємо студента за індексом
                    student.PrintInfo(); // Виводимо інформацію про студента
                }
                else
                {
                    Console.WriteLine("Невірний номер запису.");
                }
            }
            else
            {
                Console.WriteLine("Невірний ввід.");
            }
        }

        // Метод для пошуку запису за номером
        public static void FindRecordByNumber(University university)
        {
            Console.WriteLine("Введіть номер запису для пошуку (0 для виходу):");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0)
            {
                var students = university.GetStudents();
                if (index <= students.Count)
                {
                    var student = students[index - 1]; // Отримуємо студента за індексом
                    Console.WriteLine($"Знайдено запис: {student.FullName}");
                }
                else
                {
                    Console.WriteLine("Запис не знайдено.");
                }
            }
            else
            {
                Console.WriteLine("Невірний ввід.");
            }
        }

        // Метод для видалення запису за номером
        public static void DeleteRecordByNumber(University university)
        {
            Console.WriteLine("Введіть номер запису для видалення (0 для виходу):");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0)
            {
                var students = university.GetStudents();
                if (index <= students.Count)
                {
                    var student = students[index - 1]; // Отримуємо студента за індексом
                    Console.WriteLine($"Видалити запис: {student.FullName}? (y/n)");
                    var confirmation = Console.ReadLine();
                    if (confirmation?.ToLower() == "y")
                    {
                        university.RemoveStudentById(student.StudentId); // Видаляємо запис
                        Console.WriteLine("Запис успішно видалено.");
                    }
                    else
                    {
                        Console.WriteLine("Операція скасована.");
                    }
                }
                else
                {
                    Console.WriteLine("Невірний номер запису.");
                }
            }
            else
            {
                Console.WriteLine("Невірний ввід.");
            }
        }

        // Метод для видалення всієї інформації
        public static void DeleteAllRecords(University university)
        {
            Console.WriteLine("Ви дійсно хочете видалити всі записи? (y/n)");
            var confirmation = Console.ReadLine();
            if (confirmation?.ToLower() == "y")
            {
                university.RemoveAllStudents(); // Очищаємо список студентів
                Console.WriteLine("Всі записи були успішно видалені.");
            }
            else
            {
                Console.WriteLine("Операція скасована.");
            }
        }

        // Метод для виведення всіх записів із нумерацією
        public static void PrintAllRecordsWithNumbers(University university)
        {
            var students = university.GetStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("Записів немає.");
                return;
            }

            Console.WriteLine("Список всіх записів:");

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].FullName} - Група: {students[i].GroupName}");
            }
        }

        // Головне меню редагування інформації
        public static void ViewAndEditInformation(University university)
        {
            while (true)
            {
                Console.WriteLine("\nМеню редагування:");
                Console.WriteLine("1. Відобразити всі записи.");
                Console.WriteLine("2. Відобразити запис за номером.");
                Console.WriteLine("3. Пошук запису за номером.");
                Console.WriteLine("4. Видалити запис.");
                Console.WriteLine("5. Видалити всі записи.");
                Console.WriteLine("0. Повернутися до головного меню.");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PrintAllRecordsWithNumbers(university); // Вивести всі записи
                        PrintMethods.PrintAllStudents(university); // Вивести всі записи із сортуванням
                        break;
                    case "2":
                        ViewRecordByNumber(university); // Вивести запис за номером
                        break;
                    case "3":
                        FindRecordByNumber(university); // Пошук запису за номером
                        break;
                    case "4":
                        DeleteRecordByNumber(university); // Видалити запис за номером
                        break;
                    case "5":
                        DeleteAllRecords(university); // Видалити всі записи
                        break;
                    case "0":
                        return; // Повернутися до головного меню
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}


