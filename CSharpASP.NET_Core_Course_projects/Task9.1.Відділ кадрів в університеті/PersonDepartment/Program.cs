using System;
using System.Linq;

namespace UniversityDirectory
{
    internal class Program
    {
        // Оголошення делегата
        public delegate void TestMethod();

        // Оголошення події
        public static event TestMethod OnTestMethods;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            var university = new University();

            // Підписка на методи тестування
            OnTestMethods += TestMethods.TestMethod1;
            OnTestMethods += TestMethods.TestMethod2;
            // Додайте сюди інші методи, які ви хочете перевіряти

            while (true)
            {
                Console.WriteLine("Головне меню:");
                Console.WriteLine("1. Завантажити інформацію.");
                Console.WriteLine("2. Записати інформацію.");
                Console.WriteLine("3. Ввести інформацію.");
                Console.WriteLine("4. Вивести/редагувати/сортувати інформацію.");
                Console.WriteLine("5. Ініціалізація.");
                Console.WriteLine("6. Тестові методи.");
                Console.WriteLine("0. Вихід");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        university = FileManager.LoadFromFile();
                        Console.WriteLine("Дані успішно завантажені.");
                        break;
                    case "2":
                        FileManager.SaveToFile(university);
                        Console.WriteLine("Дані успішно збережені.");
                        break;
                    case "3":
                        InputInformation.CollectInputInformation(university);
                        break;
                    case "4":
                        EditInformation.ViewAndEditInformation(university);
                        break;
                    case "5":
                        InitializeUniversity(university);
                        break;
                    case "6":
                        // Виклик події, щоб запустити всі методи, на які підписалися
                        OnTestMethods?.Invoke();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }

        private static void InitializeUniversity(University university)
        {
            DataInitializer.InitializeData(university);
            PrintMethods.Print(university);

            while (true)
            {
                Console.WriteLine("Виберіть завдання:");
                Console.WriteLine("1. Список усіх студентів з можливістю сортування.");
                Console.WriteLine("2. Список студентів без батьків.");
                Console.WriteLine("3. Список викладачів.");
                Console.WriteLine("4. Список завідувачів кафедр.");
                Console.WriteLine("5. Список груп без старост та кафедр без завідувачів.");
                Console.WriteLine("6. Пошук дітей-студентів у заданого батька.");
                Console.WriteLine("7. Список викладачів, які мають дітей-студентів.");
                Console.WriteLine("0. Вихід");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PrintMethods.PrintAllStudents(university);
                        break;
                    case "2":
                        PrintMethods.PrintStudentsWithoutParents(university);
                        break;
                    case "3":
                        PrintMethods.PrintAllTeachers(university);
                        break;
                    case "4":
                        PrintMethods.PrintAllDepartmentHeads(university);
                        break;
                    case "5":
                        PrintMethods.PrintStudentsWithoutClassRepsAndDepartmentHeads(university);
                        break;
                    case "6":
                        PrintMethods.FindStudentsByParent(university);
                        break;
                    case "7":
                        PrintMethods.PrintTeachersWithStudentChildren(university);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }
    }

    // Клас для тестових методів
    public static class TestMethods
    {
        public static void TestMethod1()
        {
            Console.WriteLine("Виконано тестовий метод 1.");
            // Додайте код для тестування
        }

        public static void TestMethod2()
        {
            Console.WriteLine("Виконано тестовий метод 2.");
            // Додайте код для тестування
        }

        // Додайте інші тестові методи
    }
}



