//using System;
//using System.Collections.Generic;
//using UniversityDirectory;
//using PersonDepartment;

//namespace PersonDepartment
//{
//    public class InputInformation
//    {
//        public static Faculty CollectFacultyInformation()
//        {
//            Console.Write("Введіть назву факультету: ");
//            string facultyName = Console.ReadLine();

//            // Створення нового факультету
//            Faculty faculty = new Faculty(facultyName);

//            while (true)
//            {
//                Department department = CollectDepartmentInformation(faculty);
//                if (department == null) break; // Якщо додати нову кафедру не вдалося, виходимо з циклу
//                faculty.Departments.Add(department);
//            }

//            return faculty;
//        }

//        public static Department CollectDepartmentInformation(Faculty faculty)
//        {
//            Console.WriteLine("Виберіть кафедру:");
//            for (int i = 0; i < faculty.Departments.Count; i++)
//            {
//                Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
//            }
//            Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

//            string input = Console.ReadLine();
//            int choice;

//            // Спробуйте перетворити введене значення в ціле число
//            if (int.TryParse(input, out choice) && choice >= 1 && choice <= faculty.Departments.Count + 1)
//            {
//                if (choice == faculty.Departments.Count + 1)
//                {
//                    // Код для додавання нової кафедри
//                    Console.Write("Введіть назву нової кафедри: ");
//                    string departmentName = Console.ReadLine();

//                    // Запит на введення голови кафедри
//                    Console.Write("Введіть ім'я голови кафедри (або пропустіть, натиснувши Enter): ");
//                    string headFirstName = Console.ReadLine();
//                    Teacher head = null;

//                    if (!string.IsNullOrEmpty(headFirstName))
//                    {
//                        string headLastName = ReadNonEmptyInput("Прізвище голови кафедри: ");
//                        string headMiddleName = ReadNonEmptyInput("По батькові голови кафедри: ");
//                        Gender headGender = ReadGenderInput();
//                        string headAddress = ReadNonEmptyInput("Адреса голови кафедри: ");
//                        string headSubject = ReadNonEmptyInput("Предмет голови кафедри: ");

//                        // Створення об'єкта голови кафедри
//                        head = new Teacher(headFirstName, headLastName, headMiddleName, headGender, headAddress, headSubject);
//                    }

//                    // Створення нового відділу з головою кафедри
//                    Department newDepartment = new Department(departmentName, faculty, head);
//                    return newDepartment;
//                }
//                else
//                {
//                    return faculty.Departments[choice - 1];
//                }
//            }
//            else
//            {
//                Console.WriteLine("Введено неправильне значення. Будь ласка, введіть номер кафедри.");
//                return null; // Повертаємо null, щоб вийти з циклу
//            }
//        }

//        private static string ReadNonEmptyInput(string prompt)
//        {
//            string input;
//            do
//            {
//                Console.Write(prompt);
//                input = Console.ReadLine();
//            } while (string.IsNullOrWhiteSpace(input));

//            return input;
//        }

//        private static Gender ReadGenderInput()
//        {
//            Console.WriteLine("Оберіть стать (1. Чоловіча, 2. Жіноча): ");
//            string input = Console.ReadLine();
//            Gender gender;

//            switch (input)
//            {
//                case "1":
//                    gender = Gender.Male;
//                    break;
//                case "2":
//                    gender = Gender.Female;
//                    break;
//                default:
//                    Console.WriteLine("Неправильний вибір. Встановлюється стать 'Чоловіча'.");
//                    gender = Gender.Male;
//                    break;
//            }

//            return gender;
//        }
//    }
//}




using System;
using System.Collections.Generic;

namespace UniversityDirectory
{
    public static class InputInformation
    {
        public static void CollectInputInformation(University university)
        {
            // Вибір або створення факультету
            Faculty faculty = ChooseOrCreateFaculty(university);
            // Вибір або створення кафедри
            Department department = ChooseOrCreateDepartment(faculty);

            // Введення інформації про студентів
            CollectStudentInformation(department, faculty);
            // Введення інформації про викладачів
            CollectTeacherInformation(department);
        }

        private static Faculty ChooseOrCreateFaculty(University university)
        {
            Console.WriteLine("Виберіть факультет:");
            for (int i = 0; i < university.Faculties.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {university.Faculties[i].Name}");
            }
            Console.WriteLine($"{university.Faculties.Count + 1}. Додати новий факультет");

            int choice = int.Parse(Console.ReadLine());
            if (choice == university.Faculties.Count + 1)
            {
                Console.Write("Введіть назву нового факультету: ");
                string facultyName = Console.ReadLine();
                Faculty newFaculty = new Faculty(facultyName);
                university.Faculties.Add(newFaculty);
                return newFaculty;
            }
            else
            {
                return university.Faculties[choice - 1];
            }
        }

        public static Department ChooseOrCreateDepartment(Faculty faculty)
        {
            Console.WriteLine("Виберіть кафедру:");
            for (int i = 0; i < faculty.Departments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
            }
            Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

            int choice = int.Parse(Console.ReadLine());
            if (choice == faculty.Departments.Count + 1)
            {
                Console.Write("Введіть назву нової кафедри: ");
                string departmentName = Console.ReadLine();

                // Запит на введення голови кафедри
                Console.Write("Введіть ім'я голови кафедри (або пропустіть, натиснувши Enter): ");
                string headFirstName = Console.ReadLine();
                Teacher head = null;

                if (!string.IsNullOrEmpty(headFirstName))
                {
                    string headLastName = ReadNonEmptyInput("Прізвище голови кафедри: ");
                    string headMiddleName = ReadNonEmptyInput("По батькові голови кафедри: ");
                    Gender headGender = ReadGenderInput();
                    string headAddress = ReadNonEmptyInput("Адреса голови кафедри: ");
                    string headSubject = ReadNonEmptyInput("Предмет голови кафедри: ");

                    // Створення об'єкта голови кафедри
                    head = new Teacher(headFirstName, headLastName, headMiddleName, headGender, headAddress, headSubject);
                }

                // Створення нового відділу з головою кафедри
                Department newDepartment = new Department(departmentName, faculty, head);
                faculty.Departments.Add(newDepartment);
                return newDepartment;
            }
            else
            {
                return faculty.Departments[choice - 1];
            }
        }


        //private static Department ChooseOrCreateDepartment(Faculty faculty)
        //{
        //    Console.WriteLine("Виберіть кафедру:");
        //    for (int i = 0; i < faculty.Departments.Count; i++)
        //    {
        //        Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
        //    }
        //    Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

        //    int choice = int.Parse(Console.ReadLine());
        //    if (choice == faculty.Departments.Count + 1)
        //    {
        //        Console.Write("Введіть назву нової кафедри: ");
        //        string departmentName = Console.ReadLine();

        //        // Запит на введення голови кафедри
        //        Console.Write("Введіть ім'я голови кафедри (або пропустіть, натиснувши Enter): ");
        //        string headName = Console.ReadLine();
        //        Teacher head = null;

        //        if (!string.IsNullOrEmpty(headName))
        //        {
        //            head = new Teacher(headName); // Припустимо, у вас є конструктор у класі Teacher
        //        }

        //        Department newDepartment = new Department(departmentName, faculty, head);
        //        faculty.Departments.Add(newDepartment);
        //        return newDepartment;
        //    }
        //    else
        //    {
        //        return faculty.Departments[choice - 1];
        //    }
        //}

        private static void CollectStudentInformation(Department department, Faculty faculty)
        {
            while (true)
            {
                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

                // Зчитування імені студента
                string firstName = ReadNonEmptyInput("Ім'я: ");
                if (firstName == "0") break;

                // Зчитування прізвища студента
                string lastName = ReadNonEmptyInput("Призвище: ");
                if (lastName == "0") break;

                // Зчитування по батькові студента
                string middleName = ReadNonEmptyInput("По батькові: ");
                if (middleName == "0") break;

                // Зчитування статі студента
                Gender gender = ReadGenderInput();
                string address = ReadNonEmptyInput("Адреса: ");
                if (address == "0") break;

                string group = ReadNonEmptyInput("Група: ");
                if (group == "0") break;

                // Введення інформації про батька
                string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
                string parentLastName = ReadNonEmptyInput("Призвище батька: ");
                bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

                // Створення об'єкта батька
                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);

                // Створення нового студента з переданими даними
                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);

                // Додавання студента до кафедри
                department.Students.Add(student);

                // Вивід інформації про доданого студента
                Console.WriteLine($"Студента додано: {student.FirstName} {student.LastName}, Факультет: {faculty.Name}, Кафедра: {department.Name}");
            }
        }

        private static void CollectTeacherInformation(Department department)
        {
            // Ваш код для збору інформації про викладачів
            // Додайте логіку для введення даних про викладачів
        }

        private static string ReadNonEmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Це поле не може бути порожнім!");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        private static Gender ReadGenderInput()
        {
            Gender gender;
            while (true)
            {
                Console.Write("Стать (Male/Female): ");
                if (Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
                {
                    break;
                }
                Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
            }
            return gender;
        }

        private static bool ReadBooleanInput(string prompt)
        {
            bool result;
            while (true)
            {
                Console.Write(prompt);
                if (bool.TryParse(Console.ReadLine(), out result))
                {
                    break;
                }
                Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
            }
            return result;
        }
    }
}


////using System;
////using System.Collections.Generic;

////namespace UniversityDirectory
////{
////    public static class InputInformation
////    {
////        public static void CollectInputInformation(University university)
////        {
////            // Вибір або створення факультету
////            Faculty faculty = ChooseOrCreateFaculty(university);
////            // Вибір або створення кафедри
////            Department department = ChooseOrCreateDepartment(faculty);

////            // Введення інформації про студентів
////            CollectStudentInformation(department, faculty);
////            // Введення інформації про викладачів
////            CollectTeacherInformation(department);
////        }

////        private static Faculty ChooseOrCreateFaculty(University university)
////        {
////            Console.WriteLine("Виберіть факультет:");
////            for (int i = 0; i < university.Faculties.Count; i++)
////            {
////                Console.WriteLine($"{i + 1}. {university.Faculties[i].Name}");
////            }
////            Console.WriteLine($"{university.Faculties.Count + 1}. Додати новий факультет");

////            int choice = int.Parse(Console.ReadLine());
////            if (choice == university.Faculties.Count + 1)
////            {
////                Console.Write("Введіть назву нового факультету: ");
////                string facultyName = Console.ReadLine();
////                Faculty newFaculty = new Faculty(facultyName);
////                university.Faculties.Add(newFaculty);
////                return newFaculty;
////            }
////            else
////            {
////                return university.Faculties[choice - 1];
////            }
////        }

////        private static Department ChooseOrCreateDepartment(Faculty faculty)
////        {
////            Console.WriteLine("Виберіть кафедру:");
////            for (int i = 0; i < faculty.Departments.Count; i++)
////            {
////                Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
////            }
////            Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

////            int choice = int.Parse(Console.ReadLine());
////            if (choice == faculty.Departments.Count + 1)
////            {
////                Console.Write("Введіть назву нової кафедри: ");
////                string departmentName = Console.ReadLine();

////                // Створення нової кафедри з переданим факультетом
////                Department newDepartment = new Department(departmentName, faculty);
////                faculty.Departments.Add(newDepartment);
////                return newDepartment;
////            }
////            else
////            {
////                return faculty.Departments[choice - 1];
////            }
////        }

////        private static void CollectStudentInformation(Department department, Faculty faculty)
////        {
////            while (true)
////            {
////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

////                // Зчитування імені студента
////                string firstName = ReadNonEmptyInput("Ім'я: ");
////                if (firstName == "0") break;

////                // Зчитування прізвища студента
////                string lastName = ReadNonEmptyInput("Призвище: ");
////                if (lastName == "0") break;

////                // Зчитування по батькові студента
////                string middleName = ReadNonEmptyInput("По батькові: ");
////                if (middleName == "0") break;

////                // Зчитування статі студента
////                Gender gender = ReadGenderInput();
////                string address = ReadNonEmptyInput("Адреса: ");
////                if (address == "0") break;

////                string group = ReadNonEmptyInput("Група: ");
////                if (group == "0") break;

////                // Введення інформації про батька
////                string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
////                string parentLastName = ReadNonEmptyInput("Призвище батька: ");
////                bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

////                // Створення об'єкта батька
////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);

////                // Створення нового студента з переданими даними
////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);

////                // Додавання студента до кафедри
////                department.Students.Add(student);

////                // Вивід інформації про доданого студента
////                Console.WriteLine($"Студента додано: {student.FirstName} {student.LastName}, Факультет: {faculty.Name}, Кафедра: {department.Name}");
////            }
////        }

////        private static void CollectTeacherInformation(Department department)
////        {
////            // Ваш код для збору інформації про викладачів
////        }

////        private static string ReadNonEmptyInput(string prompt)
////        {
////            string input;
////            do
////            {
////                Console.Write(prompt);
////                input = Console.ReadLine();
////                if (string.IsNullOrWhiteSpace(input))
////                {
////                    Console.WriteLine("Це поле не може бути порожнім!");
////                }
////            } while (string.IsNullOrWhiteSpace(input));

////            return input;
////        }

////        private static Gender ReadGenderInput()
////        {
////            Gender gender;
////            while (true)
////            {
////                Console.Write("Стать (Male/Female): ");
////                if (Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
////                {
////                    break;
////                }
////                Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
////            }
////            return gender;
////        }

////        private static bool ReadBooleanInput(string prompt)
////        {
////            bool result;
////            while (true)
////            {
////                Console.Write(prompt);
////                if (bool.TryParse(Console.ReadLine(), out result))
////                {
////                    break;
////                }
////                Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
////            }
////            return result;
////        }
////    }
////}




////using System;
////using System.Collections.Generic;

////namespace UniversityDirectory
////{
////    public static class InputInformation
////    {
////        public static void CollectInputInformation(University university)
////        {
////            // Вибір або створення факультету
////            Faculty faculty = ChooseOrCreateFaculty(university);
////            // Вибір або створення кафедри
////            Department department = ChooseOrCreateDepartment(faculty);

////            // Введення інформації про студентів
////            CollectStudentInformation(department, faculty);
////            // Введення інформації про викладачів
////            CollectTeacherInformation(department);
////        }

////        private static Faculty ChooseOrCreateFaculty(University university)
////        {
////            Console.WriteLine("Виберіть факультет:");
////            for (int i = 0; i < university.Faculties.Count; i++)
////            {
////                Console.WriteLine($"{i + 1}. {university.Faculties[i].Name}");
////            }
////            Console.WriteLine($"{university.Faculties.Count + 1}. Додати новий факультет");

////            int choice = int.Parse(Console.ReadLine());
////            if (choice == university.Faculties.Count + 1)
////            {
////                Console.Write("Введіть назву нового факультету: ");
////                string facultyName = Console.ReadLine();
////                Faculty newFaculty = new Faculty(facultyName);
////                university.Faculties.Add(newFaculty);
////                return newFaculty;
////            }
////            else
////            {
////                return university.Faculties[choice - 1];
////            }
////        }

////        private static Department ChooseOrCreateDepartment(Faculty faculty)
////        {
////            Console.WriteLine("Виберіть кафедру:");
////            for (int i = 0; i < faculty.Departments.Count; i++)
////            {
////                Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
////            }
////            Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

////            int choice = int.Parse(Console.ReadLine());
////            if (choice == faculty.Departments.Count + 1)
////            {
////                Console.Write("Введіть назву нової кафедри: ");
////                string departmentName = Console.ReadLine();
////                Department newDepartment = new Department(departmentName);
////                faculty.Departments.Add(newDepartment);
////                return newDepartment;
////            }
////            else
////            {
////                return faculty.Departments[choice - 1];
////            }
////        }


////        private static void CollectStudentInformation(Department department, Faculty faculty)
////        {
////            while (true)
////            {
////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

////                // Зчитування імені студента
////                string firstName = ReadNonEmptyInput("Ім'я: ");
////                if (firstName == "0") break;

////                // Зчитування прізвища студента
////                string lastName = ReadNonEmptyInput("Призвище: ");
////                if (lastName == "0") break;

////                // Зчитування по батькові студента
////                string middleName = ReadNonEmptyInput("По батькові: ");
////                if (middleName == "0") break;

////                // Зчитування статі студента
////                Gender gender = ReadGenderInput();
////                string address = ReadNonEmptyInput("Адреса: ");
////                if (address == "0") break;

////                string group = ReadNonEmptyInput("Група: ");
////                if (group == "0") break;

////                // Введення інформації про батька
////                string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
////                string parentLastName = ReadNonEmptyInput("Призвище батька: ");
////                bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

////                // Створення об'єкта батька
////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);

////                // Створення нового студента з переданими даними
////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);

////                // Додавання студента до кафедри
////                department.Students.Add(student);

////                // Вивід інформації про доданого студента
////                Console.WriteLine($"Студента додано: {student.FirstName} {student.LastName}, Факультет: {faculty.Name}, Кафедра: {department.Name}");
////            }
////        }



////        private static void CollectTeacherInformation(Department department)
////        {
////            // Ваш код для збору інформації про викладачів
////        }

////        private static string ReadNonEmptyInput(string prompt)
////        {
////            string input;
////            do
////            {
////                Console.Write(prompt);
////                input = Console.ReadLine();
////                if (string.IsNullOrWhiteSpace(input))
////                {
////                    Console.WriteLine("Це поле не може бути порожнім!");
////                }
////            } while (string.IsNullOrWhiteSpace(input));

////            return input;
////        }

////        private static Gender ReadGenderInput()
////        {
////            Gender gender;
////            while (true)
////            {
////                Console.Write("Стать (Male/Female): ");
////                if (Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
////                {
////                    break;
////                }
////                Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
////            }
////            return gender;
////        }

////        private static bool ReadBooleanInput(string prompt)
////        {
////            bool result;
////            while (true)
////            {
////                Console.Write(prompt);
////                if (bool.TryParse(Console.ReadLine(), out result))
////                {
////                    break;
////                }
////                Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
////            }
////            return result;
////        }
////    }
////}







////using System;
////using System.Collections.Generic;

////namespace UniversityDirectory
////{
////    public static class InputInformation
////    {
////        public static void CollectInputInformation(University university)
////        {
////            // Вибір або створення факультету
////            Faculty faculty = ChooseOrCreateFaculty(university);
////            // Вибір або створення кафедри
////            Department department = ChooseOrCreateDepartment(faculty);

////            // Введення інформації про студентів
////            CollectStudentInformation(department, faculty);
////            // Введення інформації про викладачів
////            CollectTeacherInformation(department);
////        }

////        private static Faculty ChooseOrCreateFaculty(University university)
////        {
////            Console.WriteLine("Виберіть факультет:");
////            for (int i = 0; i < university.Faculties.Count; i++)
////            {
////                Console.WriteLine($"{i + 1}. {university.Faculties[i].Name}");
////            }
////            Console.WriteLine($"{university.Faculties.Count + 1}. Додати новий факультет");

////            int choice = int.Parse(Console.ReadLine());
////            if (choice == university.Faculties.Count + 1)
////            {
////                Console.Write("Введіть назву нового факультету: ");
////                string facultyName = Console.ReadLine();
////                Faculty newFaculty = new Faculty(facultyName);
////                university.Faculties.Add(newFaculty);
////                return newFaculty;
////            }
////            else
////            {
////                return university.Faculties[choice - 1];
////            }
////        }

////        private static Department ChooseOrCreateDepartment(Faculty faculty)
////        {
////            Console.WriteLine("Виберіть кафедру:");
////            for (int i = 0; i < faculty.Departments.Count; i++)
////            {
////                Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
////            }
////            Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

////            int choice = int.Parse(Console.ReadLine());
////            if (choice == faculty.Departments.Count + 1)
////            {
////                Console.Write("Введіть назву нової кафедри: ");
////                string departmentName = Console.ReadLine();
////                Department newDepartment = new Department(departmentName);
////                faculty.Departments.Add(newDepartment);
////                return newDepartment;
////            }
////            else
////            {
////                return faculty.Departments[choice - 1];
////            }
////        }

////        private static void CollectStudentInformation(Department department, Faculty faculty)
////        {
////            while (true)
////            {
////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

////                string firstName = ReadNonEmptyInput("Ім'я: ");
////                if (firstName == "0") break;

////                string lastName = ReadNonEmptyInput("Призвище: ");
////                if (lastName == "0") break;

////                string middleName = ReadNonEmptyInput("По батькові: ");
////                if (middleName == "0") break;

////                Gender gender = ReadGenderInput();
////                string address = ReadNonEmptyInput("Адреса: ");
////                if (address == "0") break;

////                string group = ReadNonEmptyInput("Група: ");
////                if (group == "0") break;

////                // Введення інформації про батька
////                string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
////                string parentLastName = ReadNonEmptyInput("Призвище батька: ");
////                bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);
////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);
////                department.Students.Add(student);

////                Console.WriteLine("Студента додано.");
////            }
////        }

////        private static void CollectTeacherInformation(Department department)
////        {
////            // Ваш код для збору інформації про викладачів
////        }

////        private static string ReadNonEmptyInput(string prompt)
////        {
////            string input;
////            do
////            {
////                Console.Write(prompt);
////                input = Console.ReadLine();
////                if (string.IsNullOrWhiteSpace(input))
////                {
////                    Console.WriteLine("Це поле не може бути порожнім!");
////                }
////            } while (string.IsNullOrWhiteSpace(input));

////            return input;
////        }

////        private static Gender ReadGenderInput()
////        {
////            Gender gender;
////            while (true)
////            {
////                Console.Write("Стать (Male/Female): ");
////                if (Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
////                {
////                    break;
////                }
////                Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
////            }
////            return gender;
////        }

////        private static bool ReadBooleanInput(string prompt)
////        {
////            bool result;
////            while (true)
////            {
////                Console.Write(prompt);
////                if (bool.TryParse(Console.ReadLine(), out result))
////                {
////                    break;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
////                }
////                Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
////            }
////            return result;
////        }
////    }
////}






////using System;

////namespace UniversityDirectory
////{
////    public static class InputInformation
////    {
////        public static void CollectInputInformation(University university)
////        {
////            Console.WriteLine("Введіть назву факультету:");
////            string facultyName = Console.ReadLine();
////            Faculty faculty = new Faculty(facultyName);
////            university.Faculties.Add(faculty);

////            Console.WriteLine("Введіть назву кафедри:");
////            string departmentName = Console.ReadLine();
////            Department department = new Department(departmentName);
////            faculty.Departments.Add(department);

////            // Введення інформації про студентів
////            while (true)
////            {
////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

////                string firstName;
////                do
////                {
////                    Console.Write("Ім'я: ");
////                    firstName = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(firstName))
////                    {
////                        Console.WriteLine("Ім'я не може бути порожнім!");
////                    }
////                } while (string.IsNullOrWhiteSpace(firstName) || firstName == "0");

////                string lastName;
////                do
////                {
////                    Console.Write("Призвище: ");
////                    lastName = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(lastName))
////                    {
////                        Console.WriteLine("Призвище не може бути порожнім!");
////                    }
////                } while (string.IsNullOrWhiteSpace(lastName) || lastName == "0");

////                string middleName;
////                do
////                {
////                    Console.Write("По батькові: ");
////                    middleName = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(middleName))
////                    {
////                        Console.WriteLine("По батькові не може бути порожнім!");
////                    }
////                } while (string.IsNullOrWhiteSpace(middleName) || middleName == "0");

////                Console.Write("Стать (Male/Female): ");
////                Gender gender;
////                while (!Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
////                {
////                    Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
////                }

////                string address;
////                do
////                {
////                    Console.Write("Адреса: ");
////                    address = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(address))
////                    {
////                        Console.WriteLine("Адреса не може бути порожньою!");
////                    }
////                } while (string.IsNullOrWhiteSpace(address) || address == "0");

////                string group;
////                do
////                {
////                    Console.Write("Група: ");
////                    group = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(group))
////                    {
////                        Console.WriteLine("Група не може бути порожньою!");
////                    }
////                } while (string.IsNullOrWhiteSpace(group) || group == "0");

////                // Введення інформації про батька
////                string parentFirstName;
////                do
////                {
////                    Console.Write("Ім'я батька: ");
////                    parentFirstName = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(parentFirstName))
////                    {
////                        Console.WriteLine("Ім'я батька не може бути порожнім!");
////                    }
////                } while (string.IsNullOrWhiteSpace(parentFirstName) || parentFirstName == "0");

////                string parentLastName;
////                do
////                {
////                    Console.Write("Призвище батька: ");
////                    parentLastName = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(parentLastName))
////                    {
////                        Console.WriteLine("Призвище батька не може бути порожнім!");
////                    }
////                } while (string.IsNullOrWhiteSpace(parentLastName) || parentLastName == "0");

////                Console.Write("Чи є батько викладачем (true/false): ");
////                bool isTeacher;
////                while (!bool.TryParse(Console.ReadLine(), out isTeacher))
////                {
////                    Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
////                }

////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);
////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);
////                department.Students.Add(student);

////                Console.WriteLine("Студента додано.");
////            }

////            // Введення інформації про викладачів
////            while (true)
////            {
////                Console.WriteLine("Введіть інформацію про викладача (введіть '0' для виходу):");

////                string teacherFirstName;
////                do
////                {
////                    Console.Write("Ім'я: ");
////                    teacherFirstName = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(teacherFirstName))
////                    {
////                        Console.WriteLine("Ім'я не може бути порожнім!");
////                    }
////                } while (string.IsNullOrWhiteSpace(teacherFirstName) || teacherFirstName == "0");

////                string teacherLastName;
////                do
////                {
////                    Console.Write("Призвище: ");
////                    teacherLastName = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(teacherLastName))
////                    {
////                        Console.WriteLine("Призвище не може бути порожнім!");
////                    }
////                } while (string.IsNullOrWhiteSpace(teacherLastName) || teacherLastName == "0");

////                string teacherMiddleName;
////                do
////                {
////                    Console.Write("По батькові: ");
////                    teacherMiddleName = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(teacherMiddleName))
////                    {
////                        Console.WriteLine("По батькові не може бути порожнім!");
////                    }
////                } while (string.IsNullOrWhiteSpace(teacherMiddleName) || teacherMiddleName == "0");

////                Console.Write("Стать (Male/Female): ");
////                Gender teacherGender;
////                while (!Enum.TryParse<Gender>(Console.ReadLine(), true, out teacherGender))
////                {
////                    Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
////                }

////                string teacherAddress;
////                do
////                {
////                    Console.Write("Адреса: ");
////                    teacherAddress = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(teacherAddress))
////                    {
////                        Console.WriteLine("Адреса не може бути порожньою!");
////                    }
////                } while (string.IsNullOrWhiteSpace(teacherAddress) || teacherAddress == "0");

////                string subject;
////                do
////                {
////                    Console.Write("Предмет: ");
////                    subject = Console.ReadLine();
////                    if (string.IsNullOrWhiteSpace(subject))
////                    {
////                        Console.WriteLine("Предмет не може бути порожнім!");
////                    }
////                } while (string.IsNullOrWhiteSpace(subject) || subject == "0");

////                Teacher teacher = new Teacher(teacherFirstName, teacherLastName, teacherMiddleName, teacherGender, teacherAddress, subject);
////                department.Teachers.Add(teacher);

////                Console.WriteLine("Викладача додано.");
////            }
////        }

////        private static void AskToSave(University university)
////        {
////            Console.WriteLine("Ви хочете зберегти дані? (введіть 'y' для так, 'n' для ні): ");
////            string input = Console.ReadLine();
////            if (input?.ToLower() == "y")
////            {
////                FileManager.SaveToFile(university); // Використання FileManager для збереження
////                Console.WriteLine("Дані успішно збережено у файл.");
////            }
////            else
////            {
////                Console.WriteLine("Дані не збережені.");
////            }
////        }
////    }
////}




////using System;

////namespace UniversityDirectory
////{
////    public static class InputInformation
////    {
////        public static void CollectInputInformation(University university)
////        {
////            Console.WriteLine("Введіть назву факультету:");
////            string facultyName = Console.ReadLine();
////            Faculty faculty = new Faculty(facultyName);
////            university.Faculties.Add(faculty);

////            Console.WriteLine("Введіть назву кафедри:");
////            string departmentName = Console.ReadLine();
////            Department department = new Department(departmentName);
////            faculty.Departments.Add(department);

////            // Введення інформації про студентів
////            while (true)
////            {
////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

////                Console.Write("Ім'я: ");
////                string firstName = Console.ReadLine();
////                if (firstName == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Console.Write("Призвище: ");
////                string lastName = Console.ReadLine();
////                if (lastName == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Console.Write("По батькові: ");
////                string middleName = Console.ReadLine();
////                if (middleName == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Console.Write("Стать (Male/Female): ");
////                Gender gender;
////                while (!Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
////                {
////                    Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
////                }

////                Console.Write("Адреса: ");
////                string address = Console.ReadLine();
////                if (address == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Console.Write("Група: ");
////                string group = Console.ReadLine();
////                if (group == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                // Введення інформації про батька
////                Console.Write("Ім'я батька: ");
////                string parentFirstName = Console.ReadLine();
////                if (parentFirstName == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Console.Write("Призвище батька: ");
////                string parentLastName = Console.ReadLine();
////                if (parentLastName == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Console.Write("Чи є батько викладачем (true/false): ");
////                bool isTeacher;
////                while (!bool.TryParse(Console.ReadLine(), out isTeacher))
////                {
////                    Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
////                }

////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);
////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);
////                department.Students.Add(student);

////                Console.WriteLine("Студента додано.");
////            }

////            // Введення інформації про викладачів
////            while (true)
////            {
////                Console.WriteLine("Введіть інформацію про викладача (введіть '0' для виходу):");

////                Console.Write("Ім'я: ");
////                string teacherFirstName = Console.ReadLine();
////                if (teacherFirstName == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Console.Write("Призвище: ");
////                string teacherLastName = Console.ReadLine();
////                if (teacherLastName == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Console.Write("По батькові: ");
////                string teacherMiddleName = Console.ReadLine();
////                if (teacherMiddleName == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Console.Write("Стать (Male/Female): ");
////                Gender teacherGender;
////                while (!Enum.TryParse<Gender>(Console.ReadLine(), true, out teacherGender))
////                {
////                    Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
////                }

////                Console.Write("Адреса: ");
////                string teacherAddress = Console.ReadLine();
////                if (teacherAddress == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Console.Write("Предмет: ");
////                string subject = Console.ReadLine();
////                if (subject == "0")
////                {
////                    AskToSave(university);
////                    return; // Вихід з методу
////                }

////                Teacher teacher = new Teacher(teacherFirstName, teacherLastName, teacherMiddleName, teacherGender, teacherAddress, subject);
////                department.Teachers.Add(teacher);

////                Console.WriteLine("Викладача додано.");
////            }
////        }

////        private static void AskToSave(University university)
////        {
////            Console.WriteLine("Ви хочете зберегти дані? (введіть 'y' для так, 'n' для ні): ");
////            string input = Console.ReadLine();
////            if (input?.ToLower() == "y")
////            {
////                FileManager.SaveToFile(university); // Використання FileManager для збереження
////                Console.WriteLine("Дані успішно збережено у файл.");
////            }
////            else
////            {
////                Console.WriteLine("Дані не збережені.");
////            }
////        }
////    }
////}



////private static void CollectStudentInformation(Department department, Faculty faculty)
////{
////    while (true)
////    {
////        Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

////        string firstName = ReadNonEmptyInput("Ім'я: ");
////        if (firstName == "0") break;

////        string lastName = ReadNonEmptyInput("Призвище: ");
////        if (lastName == "0") break;

////        string middleName = ReadNonEmptyInput("По батькові: ");
////        if (middleName == "0") break;

////        Gender gender = ReadGenderInput();
////        string address = ReadNonEmptyInput("Адреса: ");
////        if (address == "0") break;

////        string group = ReadNonEmptyInput("Група: ");
////        if (group == "0") break;

////        // Введення інформації про батька
////        string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
////        string parentLastName = ReadNonEmptyInput("Призвище батька: ");
////        bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

////        Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);
////        Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);
////        department.Students.Add(student);

////        Console.WriteLine("Студента додано.");

////        // Виведення інформації про факультет і кафедру
////        Console.WriteLine($"Факультет: {faculty.Name}, Кафедра: {department.Name}");

////        // Вивід всіх студентів для перевірки
////        //DisplayStudents(department);
////    }
////}



////private static void CollectStudentInformation(Department department, Faculty faculty)
////{
////    while (true)
////    {
////        Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

////        string firstName = ReadNonEmptyInput("Ім'я: ");
////        if (firstName == "0") break;

////        string lastName = ReadNonEmptyInput("Призвище: ");
////        if (lastName == "0") break;

////        string middleName = ReadNonEmptyInput("По батькові: ");
////        if (middleName == "0") break;

////        Gender gender = ReadGenderInput();
////        string address = ReadNonEmptyInput("Адреса: ");
////        if (address == "0") break;

////        string group = ReadNonEmptyInput("Група: ");
////        if (group == "0") break;

////        // Введення інформації про батька
////        string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
////        string parentLastName = ReadNonEmptyInput("Призвище батька: ");
////        bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

////        Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);
////        Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);
////        department.Students.Add(student);

////        Console.WriteLine("Студента додано.");
////    }
////}




////using System;
////using System.ComponentModel.DataAnnotations;
////using Newtonsoft.Json; // Додано для JsonIgnore

////public static class InputInformation
////{
////    public static void CollectInputInformation(University university)
////    {
////        // Вибір або створення факультету
////        Faculty faculty = ChooseOrCreateFaculty(university);
////        // Вибір або створення кафедри
////        Department department = ChooseOrCreateDepartment(faculty);

////        // Введення інформації про студентів
////        CollectStudentInformation(department, faculty);
////        // Введення інформації про викладачів
////        CollectTeacherInformation(department);
////    }

////    // Метод для вибору або створення кафедри
////    public static Department ChooseOrCreateDepartment(Faculty faculty)
////    {
////        Console.WriteLine("Виберіть кафедру:");
////        for (int i = 0; i < faculty.Departments.Count; i++)
////        {
////            Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
////        }
////        Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

////        int choice = int.Parse(Console.ReadLine());
////        if (choice == faculty.Departments.Count + 1)
////        {
////            Console.Write("Введіть назву нової кафедри: ");
////            string departmentName = Console.ReadLine();

////            // Запит на введення голови кафедри
////            Console.Write("Введіть ім'я голови кафедри (або пропустіть, натиснувши Enter): ");
////            string headFirstName = Console.ReadLine();
////            Teacher head = null;

////            if (!string.IsNullOrEmpty(headFirstName))
////            {
////                // Збираємо решту інформації про викладача
////                string headLastName = ReadNonEmptyInput("Прізвище голови кафедри: ");
////                string headMiddleName = ReadNonEmptyInput("По батькові голови кафедри: ");
////                Gender headGender = ReadGenderInput();
////                string headAddress = ReadNonEmptyInput("Адреса голови кафедри: ");
////                string headSubject = ReadNonEmptyInput("Предмет голови кафедри: ");

////                // Створення об'єкта голови кафедри
////                head = new Teacher(headFirstName, headLastName, headMiddleName, headGender, headAddress, headSubject);
////            }

////            // Створення нового відділу з головою кафедри
////            Department newDepartment = new Department(departmentName, faculty, head);
////            faculty.Departments.Add(newDepartment);
////            return newDepartment;
////        }
////        else
////        {
////            return faculty.Departments[choice - 1];
////        }
////    }

////    // Метод для читання непорожнього введення
////    private static string ReadNonEmptyInput(string prompt)
////    {
////        string input;
////        do
////        {
////            Console.Write(prompt);
////            input = Console.ReadLine();
////        } while (string.IsNullOrWhiteSpace(input));
////        return input;
////    }

////    // Метод для вибору статі (Gender)
////    private static Gender ReadGenderInput()
////    {
////        Console.WriteLine("Виберіть стать:");
////        foreach (var gender in Enum.GetValues(typeof(Gender)))
////        {
////            Console.WriteLine($"{(int)gender}. {gender}");
////        }
////        int genderChoice = int.Parse(Console.ReadLine());
////        return (Gender)genderChoice;
////    }
////}

////// Приклад класу Department
////public class Department
////{
////    public string Name { get; set; }
////    public Faculty Faculty { get; set; }
////    public Teacher Head { get; set; }

////    public Department(string name, Faculty faculty, Teacher head)
////    {
////        Name = name;
////        Faculty = faculty;
////        Head = head;
////    }
////}

////// Приклад класу Faculty
////public class Faculty
////{
////    public string Name { get; set; }
////    public List<Department> Departments { get; set; }

////    public Faculty(string name)
////    {
////        Name = name;
////        Departments = new List<Department>();
////    }
////}

////// Приклад класу Teacher
////public class Teacher : Person
////{
////    [Required(ErrorMessage = "Subject is required.")]
////    public string Subject { get; set; }

////    [JsonIgnore] // Ігноруємо під час серіалізації, щоб уникнути циклів
////    public Parent Parent { get; set; }

////    // Конструктор з батьком
////    public Teacher(string firstName, string lastName, string middleName, Gender gender, string address, string subject, Parent parent = null)
////        : base(firstName, lastName, middleName, gender, address)
////    {
////        Subject = subject;
////        Parent = parent ?? new Parent("Unknown", "Unknown", false);

////        // Якщо вказаний батько, додаємо викладача до списку дітей
////        Parent.AddChild(null); // Для викладачів не додаємо студента, можна розширити логіку
////    }
////}

////// Приклад класу Person
////public abstract class Person
////{
////    public string FirstName { get; set; }
////    public string LastName { get; set; }
////    public string MiddleName { get; set; }
////    public Gender Gender { get; set; }
////    public string Address { get; set; }

////    protected Person(string firstName, string lastName, string middleName, Gender gender, string address)
////    {
////        FirstName = firstName;
////        LastName = lastName;
////        MiddleName = middleName;
////        Gender = gender;
////        Address = address;
////    }
////}

////// Приклад класу Parent
////public class Parent
////{
////    public string FirstName { get; set; }
////    public string LastName { get; set; }
////    public bool IsGuardian { get; set; }

////    public Parent(string firstName, string lastName, bool isGuardian)
////    {
////        FirstName = firstName;
////        LastName = lastName;
////        IsGuardian = isGuardian;
////    }

////    public void AddChild(Person child)
////    {
////        // Логіка додавання дитини
////    }
////}

////// Приклад перерахування Gender
////public enum Gender
////{
////    Male = 1,
////    Female = 2
////}

















//////using System;
//////using System.Collections.Generic;

//////namespace UniversityDirectory
//////{
//////    public static class InputInformation
//////    {
//////        public static void CollectInputInformation(University university)
//////        {
//////            // Вибір або створення факультету
//////            Faculty faculty = ChooseOrCreateFaculty(university);
//////            // Вибір або створення кафедри
//////            Department department = ChooseOrCreateDepartment(faculty);

//////            // Введення інформації про студентів
//////            CollectStudentInformation(department, faculty);
//////            // Введення інформації про викладачів
//////            CollectTeacherInformation(department);
//////        }

//////        private static Faculty ChooseOrCreateFaculty(University university)
//////        {
//////            Console.WriteLine("Виберіть факультет:");
//////            for (int i = 0; i < university.Faculties.Count; i++)
//////            {
//////                Console.WriteLine($"{i + 1}. {university.Faculties[i].Name}");
//////            }
//////            Console.WriteLine($"{university.Faculties.Count + 1}. Додати новий факультет");

//////            int choice = int.Parse(Console.ReadLine());
//////            if (choice == university.Faculties.Count + 1)
//////            {
//////                Console.Write("Введіть назву нового факультету: ");
//////                string facultyName = Console.ReadLine();
//////                Faculty newFaculty = new Faculty(facultyName);
//////                university.Faculties.Add(newFaculty);
//////                return newFaculty;
//////            }
//////            else
//////            {
//////                return university.Faculties[choice - 1];
//////            }
//////        }

//////        private static Department ChooseOrCreateDepartment(Faculty faculty)
//////        {
//////            Console.WriteLine("Виберіть кафедру:");
//////            for (int i = 0; i < faculty.Departments.Count; i++)
//////            {
//////                Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
//////            }
//////            Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

//////            int choice = int.Parse(Console.ReadLine());
//////            if (choice == faculty.Departments.Count + 1)
//////            {
//////                Console.Write("Введіть назву нової кафедри: ");
//////                string departmentName = Console.ReadLine();

//////                // Запит на введення голови кафедри
//////                Console.Write("Введіть ім'я голови кафедри (або пропустіть, натиснувши Enter): ");
//////                string headName = Console.ReadLine();
//////                Teacher head = null;

//////                if (!string.IsNullOrEmpty(headName))
//////                {
//////                    head = new Teacher(headName); // Припустимо, у вас є конструктор у класі Teacher
//////                }

//////                Department newDepartment = new Department(departmentName, faculty, head);
//////                faculty.Departments.Add(newDepartment);
//////                return newDepartment;
//////            }
//////            else
//////            {
//////                return faculty.Departments[choice - 1];
//////            }
//////        }

//////        private static void CollectStudentInformation(Department department, Faculty faculty)
//////        {
//////            while (true)
//////            {
//////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

//////                // Зчитування імені студента
//////                string firstName = ReadNonEmptyInput("Ім'я: ");
//////                if (firstName == "0") break;

//////                // Зчитування прізвища студента
//////                string lastName = ReadNonEmptyInput("Призвище: ");
//////                if (lastName == "0") break;

//////                // Зчитування по батькові студента
//////                string middleName = ReadNonEmptyInput("По батькові: ");
//////                if (middleName == "0") break;

//////                // Зчитування статі студента
//////                Gender gender = ReadGenderInput();
//////                string address = ReadNonEmptyInput("Адреса: ");
//////                if (address == "0") break;

//////                string group = ReadNonEmptyInput("Група: ");
//////                if (group == "0") break;

//////                // Введення інформації про батька
//////                string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
//////                string parentLastName = ReadNonEmptyInput("Призвище батька: ");
//////                bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

//////                // Створення об'єкта батька
//////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);

//////                // Створення нового студента з переданими даними
//////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);

//////                // Додавання студента до кафедри
//////                department.Students.Add(student);

//////                // Вивід інформації про доданого студента
//////                Console.WriteLine($"Студента додано: {student.FirstName} {student.LastName}, Факультет: {faculty.Name}, Кафедра: {department.Name}");
//////            }
//////        }

//////        private static void CollectTeacherInformation(Department department)
//////        {
//////            // Ваш код для збору інформації про викладачів
//////            // Додайте логіку для введення даних про викладачів
//////        }

//////        private static string ReadNonEmptyInput(string prompt)
//////        {
//////            string input;
//////            do
//////            {
//////                Console.Write(prompt);
//////                input = Console.ReadLine();
//////                if (string.IsNullOrWhiteSpace(input))
//////                {
//////                    Console.WriteLine("Це поле не може бути порожнім!");
//////                }
//////            } while (string.IsNullOrWhiteSpace(input));

//////            return input;
//////        }

//////        private static Gender ReadGenderInput()
//////        {
//////            Gender gender;
//////            while (true)
//////            {
//////                Console.Write("Стать (Male/Female): ");
//////                if (Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
//////                {
//////                    break;
//////                }
//////                Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
//////            }
//////            return gender;
//////        }

//////        private static bool ReadBooleanInput(string prompt)
//////        {
//////            bool result;
//////            while (true)
//////            {
//////                Console.Write(prompt);
//////                if (bool.TryParse(Console.ReadLine(), out result))
//////                {
//////                    break;
//////                }
//////                Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
//////            }
//////            return result;
//////        }
//////    }
//////}


//////using System;
//////using System.Collections.Generic;

//////namespace UniversityDirectory
//////{
//////    public static class InputInformation
//////    {
//////        public static void CollectInputInformation(University university)
//////        {
//////            // Вибір або створення факультету
//////            Faculty faculty = ChooseOrCreateFaculty(university);
//////            // Вибір або створення кафедри
//////            Department department = ChooseOrCreateDepartment(faculty);

//////            // Введення інформації про студентів
//////            CollectStudentInformation(department, faculty);
//////            // Введення інформації про викладачів
//////            CollectTeacherInformation(department);
//////        }

//////        private static Faculty ChooseOrCreateFaculty(University university)
//////        {
//////            Console.WriteLine("Виберіть факультет:");
//////            for (int i = 0; i < university.Faculties.Count; i++)
//////            {
//////                Console.WriteLine($"{i + 1}. {university.Faculties[i].Name}");
//////            }
//////            Console.WriteLine($"{university.Faculties.Count + 1}. Додати новий факультет");

//////            int choice = int.Parse(Console.ReadLine());
//////            if (choice == university.Faculties.Count + 1)
//////            {
//////                Console.Write("Введіть назву нового факультету: ");
//////                string facultyName = Console.ReadLine();
//////                Faculty newFaculty = new Faculty(facultyName);
//////                university.Faculties.Add(newFaculty);
//////                return newFaculty;
//////            }
//////            else
//////            {
//////                return university.Faculties[choice - 1];
//////            }
//////        }

//////        private static Department ChooseOrCreateDepartment(Faculty faculty)
//////        {
//////            Console.WriteLine("Виберіть кафедру:");
//////            for (int i = 0; i < faculty.Departments.Count; i++)
//////            {
//////                Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
//////            }
//////            Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

//////            int choice = int.Parse(Console.ReadLine());
//////            if (choice == faculty.Departments.Count + 1)
//////            {
//////                Console.Write("Введіть назву нової кафедри: ");
//////                string departmentName = Console.ReadLine();

//////                // Створення нової кафедри з переданим факультетом
//////                Department newDepartment = new Department(departmentName, faculty);
//////                faculty.Departments.Add(newDepartment);
//////                return newDepartment;
//////            }
//////            else
//////            {
//////                return faculty.Departments[choice - 1];
//////            }
//////        }

//////        private static void CollectStudentInformation(Department department, Faculty faculty)
//////        {
//////            while (true)
//////            {
//////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

//////                // Зчитування імені студента
//////                string firstName = ReadNonEmptyInput("Ім'я: ");
//////                if (firstName == "0") break;

//////                // Зчитування прізвища студента
//////                string lastName = ReadNonEmptyInput("Призвище: ");
//////                if (lastName == "0") break;

//////                // Зчитування по батькові студента
//////                string middleName = ReadNonEmptyInput("По батькові: ");
//////                if (middleName == "0") break;

//////                // Зчитування статі студента
//////                Gender gender = ReadGenderInput();
//////                string address = ReadNonEmptyInput("Адреса: ");
//////                if (address == "0") break;

//////                string group = ReadNonEmptyInput("Група: ");
//////                if (group == "0") break;

//////                // Введення інформації про батька
//////                string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
//////                string parentLastName = ReadNonEmptyInput("Призвище батька: ");
//////                bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

//////                // Створення об'єкта батька
//////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);

//////                // Створення нового студента з переданими даними
//////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);

//////                // Додавання студента до кафедри
//////                department.Students.Add(student);

//////                // Вивід інформації про доданого студента
//////                Console.WriteLine($"Студента додано: {student.FirstName} {student.LastName}, Факультет: {faculty.Name}, Кафедра: {department.Name}");
//////            }
//////        }

//////        private static void CollectTeacherInformation(Department department)
//////        {
//////            // Ваш код для збору інформації про викладачів
//////        }

//////        private static string ReadNonEmptyInput(string prompt)
//////        {
//////            string input;
//////            do
//////            {
//////                Console.Write(prompt);
//////                input = Console.ReadLine();
//////                if (string.IsNullOrWhiteSpace(input))
//////                {
//////                    Console.WriteLine("Це поле не може бути порожнім!");
//////                }
//////            } while (string.IsNullOrWhiteSpace(input));

//////            return input;
//////        }

//////        private static Gender ReadGenderInput()
//////        {
//////            Gender gender;
//////            while (true)
//////            {
//////                Console.Write("Стать (Male/Female): ");
//////                if (Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
//////                {
//////                    break;
//////                }
//////                Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
//////            }
//////            return gender;
//////        }

//////        private static bool ReadBooleanInput(string prompt)
//////        {
//////            bool result;
//////            while (true)
//////            {
//////                Console.Write(prompt);
//////                if (bool.TryParse(Console.ReadLine(), out result))
//////                {
//////                    break;
//////                }
//////                Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
//////            }
//////            return result;
//////        }
//////    }
//////}




//////using System;
//////using System.Collections.Generic;

//////namespace UniversityDirectory
//////{
//////    public static class InputInformation
//////    {
//////        public static void CollectInputInformation(University university)
//////        {
//////            // Вибір або створення факультету
//////            Faculty faculty = ChooseOrCreateFaculty(university);
//////            // Вибір або створення кафедри
//////            Department department = ChooseOrCreateDepartment(faculty);

//////            // Введення інформації про студентів
//////            CollectStudentInformation(department, faculty);
//////            // Введення інформації про викладачів
//////            CollectTeacherInformation(department);
//////        }

//////        private static Faculty ChooseOrCreateFaculty(University university)
//////        {
//////            Console.WriteLine("Виберіть факультет:");
//////            for (int i = 0; i < university.Faculties.Count; i++)
//////            {
//////                Console.WriteLine($"{i + 1}. {university.Faculties[i].Name}");
//////            }
//////            Console.WriteLine($"{university.Faculties.Count + 1}. Додати новий факультет");

//////            int choice = int.Parse(Console.ReadLine());
//////            if (choice == university.Faculties.Count + 1)
//////            {
//////                Console.Write("Введіть назву нового факультету: ");
//////                string facultyName = Console.ReadLine();
//////                Faculty newFaculty = new Faculty(facultyName);
//////                university.Faculties.Add(newFaculty);
//////                return newFaculty;
//////            }
//////            else
//////            {
//////                return university.Faculties[choice - 1];
//////            }
//////        }

//////        private static Department ChooseOrCreateDepartment(Faculty faculty)
//////        {
//////            Console.WriteLine("Виберіть кафедру:");
//////            for (int i = 0; i < faculty.Departments.Count; i++)
//////            {
//////                Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
//////            }
//////            Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

//////            int choice = int.Parse(Console.ReadLine());
//////            if (choice == faculty.Departments.Count + 1)
//////            {
//////                Console.Write("Введіть назву нової кафедри: ");
//////                string departmentName = Console.ReadLine();
//////                Department newDepartment = new Department(departmentName);
//////                faculty.Departments.Add(newDepartment);
//////                return newDepartment;
//////            }
//////            else
//////            {
//////                return faculty.Departments[choice - 1];
//////            }
//////        }


//////        private static void CollectStudentInformation(Department department, Faculty faculty)
//////        {
//////            while (true)
//////            {
//////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

//////                // Зчитування імені студента
//////                string firstName = ReadNonEmptyInput("Ім'я: ");
//////                if (firstName == "0") break;

//////                // Зчитування прізвища студента
//////                string lastName = ReadNonEmptyInput("Призвище: ");
//////                if (lastName == "0") break;

//////                // Зчитування по батькові студента
//////                string middleName = ReadNonEmptyInput("По батькові: ");
//////                if (middleName == "0") break;

//////                // Зчитування статі студента
//////                Gender gender = ReadGenderInput();
//////                string address = ReadNonEmptyInput("Адреса: ");
//////                if (address == "0") break;

//////                string group = ReadNonEmptyInput("Група: ");
//////                if (group == "0") break;

//////                // Введення інформації про батька
//////                string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
//////                string parentLastName = ReadNonEmptyInput("Призвище батька: ");
//////                bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

//////                // Створення об'єкта батька
//////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);

//////                // Створення нового студента з переданими даними
//////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);

//////                // Додавання студента до кафедри
//////                department.Students.Add(student);

//////                // Вивід інформації про доданого студента
//////                Console.WriteLine($"Студента додано: {student.FirstName} {student.LastName}, Факультет: {faculty.Name}, Кафедра: {department.Name}");
//////            }
//////        }



//////        private static void CollectTeacherInformation(Department department)
//////        {
//////            // Ваш код для збору інформації про викладачів
//////        }

//////        private static string ReadNonEmptyInput(string prompt)
//////        {
//////            string input;
//////            do
//////            {
//////                Console.Write(prompt);
//////                input = Console.ReadLine();
//////                if (string.IsNullOrWhiteSpace(input))
//////                {
//////                    Console.WriteLine("Це поле не може бути порожнім!");
//////                }
//////            } while (string.IsNullOrWhiteSpace(input));

//////            return input;
//////        }

//////        private static Gender ReadGenderInput()
//////        {
//////            Gender gender;
//////            while (true)
//////            {
//////                Console.Write("Стать (Male/Female): ");
//////                if (Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
//////                {
//////                    break;
//////                }
//////                Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
//////            }
//////            return gender;
//////        }

//////        private static bool ReadBooleanInput(string prompt)
//////        {
//////            bool result;
//////            while (true)
//////            {
//////                Console.Write(prompt);
//////                if (bool.TryParse(Console.ReadLine(), out result))
//////                {
//////                    break;
//////                }
//////                Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
//////            }
//////            return result;
//////        }
//////    }
//////}







//////using System;
//////using System.Collections.Generic;

//////namespace UniversityDirectory
//////{
//////    public static class InputInformation
//////    {
//////        public static void CollectInputInformation(University university)
//////        {
//////            // Вибір або створення факультету
//////            Faculty faculty = ChooseOrCreateFaculty(university);
//////            // Вибір або створення кафедри
//////            Department department = ChooseOrCreateDepartment(faculty);

//////            // Введення інформації про студентів
//////            CollectStudentInformation(department, faculty);
//////            // Введення інформації про викладачів
//////            CollectTeacherInformation(department);
//////        }

//////        private static Faculty ChooseOrCreateFaculty(University university)
//////        {
//////            Console.WriteLine("Виберіть факультет:");
//////            for (int i = 0; i < university.Faculties.Count; i++)
//////            {
//////                Console.WriteLine($"{i + 1}. {university.Faculties[i].Name}");
//////            }
//////            Console.WriteLine($"{university.Faculties.Count + 1}. Додати новий факультет");

//////            int choice = int.Parse(Console.ReadLine());
//////            if (choice == university.Faculties.Count + 1)
//////            {
//////                Console.Write("Введіть назву нового факультету: ");
//////                string facultyName = Console.ReadLine();
//////                Faculty newFaculty = new Faculty(facultyName);
//////                university.Faculties.Add(newFaculty);
//////                return newFaculty;
//////            }
//////            else
//////            {
//////                return university.Faculties[choice - 1];
//////            }
//////        }

//////        private static Department ChooseOrCreateDepartment(Faculty faculty)
//////        {
//////            Console.WriteLine("Виберіть кафедру:");
//////            for (int i = 0; i < faculty.Departments.Count; i++)
//////            {
//////                Console.WriteLine($"{i + 1}. {faculty.Departments[i].Name}");
//////            }
//////            Console.WriteLine($"{faculty.Departments.Count + 1}. Додати нову кафедру");

//////            int choice = int.Parse(Console.ReadLine());
//////            if (choice == faculty.Departments.Count + 1)
//////            {
//////                Console.Write("Введіть назву нової кафедри: ");
//////                string departmentName = Console.ReadLine();
//////                Department newDepartment = new Department(departmentName);
//////                faculty.Departments.Add(newDepartment);
//////                return newDepartment;
//////            }
//////            else
//////            {
//////                return faculty.Departments[choice - 1];
//////            }
//////        }

//////        private static void CollectStudentInformation(Department department, Faculty faculty)
//////        {
//////            while (true)
//////            {
//////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

//////                string firstName = ReadNonEmptyInput("Ім'я: ");
//////                if (firstName == "0") break;

//////                string lastName = ReadNonEmptyInput("Призвище: ");
//////                if (lastName == "0") break;

//////                string middleName = ReadNonEmptyInput("По батькові: ");
//////                if (middleName == "0") break;

//////                Gender gender = ReadGenderInput();
//////                string address = ReadNonEmptyInput("Адреса: ");
//////                if (address == "0") break;

//////                string group = ReadNonEmptyInput("Група: ");
//////                if (group == "0") break;

//////                // Введення інформації про батька
//////                string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
//////                string parentLastName = ReadNonEmptyInput("Призвище батька: ");
//////                bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

//////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);
//////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);
//////                department.Students.Add(student);

//////                Console.WriteLine("Студента додано.");
//////            }
//////        }

//////        private static void CollectTeacherInformation(Department department)
//////        {
//////            // Ваш код для збору інформації про викладачів
//////        }

//////        private static string ReadNonEmptyInput(string prompt)
//////        {
//////            string input;
//////            do
//////            {
//////                Console.Write(prompt);
//////                input = Console.ReadLine();
//////                if (string.IsNullOrWhiteSpace(input))
//////                {
//////                    Console.WriteLine("Це поле не може бути порожнім!");
//////                }
//////            } while (string.IsNullOrWhiteSpace(input));

//////            return input;
//////        }

//////        private static Gender ReadGenderInput()
//////        {
//////            Gender gender;
//////            while (true)
//////            {
//////                Console.Write("Стать (Male/Female): ");
//////                if (Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
//////                {
//////                    break;
//////                }
//////                Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
//////            }
//////            return gender;
//////        }

//////        private static bool ReadBooleanInput(string prompt)
//////        {
//////            bool result;
//////            while (true)
//////            {
//////                Console.Write(prompt);
//////                if (bool.TryParse(Console.ReadLine(), out result))
//////                {
//////                    break;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
//////                }
//////                Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
//////            }
//////            return result;
//////        }
//////    }
//////}






//////using System;

//////namespace UniversityDirectory
//////{
//////    public static class InputInformation
//////    {
//////        public static void CollectInputInformation(University university)
//////        {
//////            Console.WriteLine("Введіть назву факультету:");
//////            string facultyName = Console.ReadLine();
//////            Faculty faculty = new Faculty(facultyName);
//////            university.Faculties.Add(faculty);

//////            Console.WriteLine("Введіть назву кафедри:");
//////            string departmentName = Console.ReadLine();
//////            Department department = new Department(departmentName);
//////            faculty.Departments.Add(department);

//////            // Введення інформації про студентів
//////            while (true)
//////            {
//////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

//////                string firstName;
//////                do
//////                {
//////                    Console.Write("Ім'я: ");
//////                    firstName = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(firstName))
//////                    {
//////                        Console.WriteLine("Ім'я не може бути порожнім!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(firstName) || firstName == "0");

//////                string lastName;
//////                do
//////                {
//////                    Console.Write("Призвище: ");
//////                    lastName = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(lastName))
//////                    {
//////                        Console.WriteLine("Призвище не може бути порожнім!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(lastName) || lastName == "0");

//////                string middleName;
//////                do
//////                {
//////                    Console.Write("По батькові: ");
//////                    middleName = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(middleName))
//////                    {
//////                        Console.WriteLine("По батькові не може бути порожнім!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(middleName) || middleName == "0");

//////                Console.Write("Стать (Male/Female): ");
//////                Gender gender;
//////                while (!Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
//////                {
//////                    Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
//////                }

//////                string address;
//////                do
//////                {
//////                    Console.Write("Адреса: ");
//////                    address = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(address))
//////                    {
//////                        Console.WriteLine("Адреса не може бути порожньою!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(address) || address == "0");

//////                string group;
//////                do
//////                {
//////                    Console.Write("Група: ");
//////                    group = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(group))
//////                    {
//////                        Console.WriteLine("Група не може бути порожньою!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(group) || group == "0");

//////                // Введення інформації про батька
//////                string parentFirstName;
//////                do
//////                {
//////                    Console.Write("Ім'я батька: ");
//////                    parentFirstName = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(parentFirstName))
//////                    {
//////                        Console.WriteLine("Ім'я батька не може бути порожнім!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(parentFirstName) || parentFirstName == "0");

//////                string parentLastName;
//////                do
//////                {
//////                    Console.Write("Призвище батька: ");
//////                    parentLastName = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(parentLastName))
//////                    {
//////                        Console.WriteLine("Призвище батька не може бути порожнім!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(parentLastName) || parentLastName == "0");

//////                Console.Write("Чи є батько викладачем (true/false): ");
//////                bool isTeacher;
//////                while (!bool.TryParse(Console.ReadLine(), out isTeacher))
//////                {
//////                    Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
//////                }

//////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);
//////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);
//////                department.Students.Add(student);

//////                Console.WriteLine("Студента додано.");
//////            }

//////            // Введення інформації про викладачів
//////            while (true)
//////            {
//////                Console.WriteLine("Введіть інформацію про викладача (введіть '0' для виходу):");

//////                string teacherFirstName;
//////                do
//////                {
//////                    Console.Write("Ім'я: ");
//////                    teacherFirstName = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(teacherFirstName))
//////                    {
//////                        Console.WriteLine("Ім'я не може бути порожнім!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(teacherFirstName) || teacherFirstName == "0");

//////                string teacherLastName;
//////                do
//////                {
//////                    Console.Write("Призвище: ");
//////                    teacherLastName = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(teacherLastName))
//////                    {
//////                        Console.WriteLine("Призвище не може бути порожнім!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(teacherLastName) || teacherLastName == "0");

//////                string teacherMiddleName;
//////                do
//////                {
//////                    Console.Write("По батькові: ");
//////                    teacherMiddleName = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(teacherMiddleName))
//////                    {
//////                        Console.WriteLine("По батькові не може бути порожнім!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(teacherMiddleName) || teacherMiddleName == "0");

//////                Console.Write("Стать (Male/Female): ");
//////                Gender teacherGender;
//////                while (!Enum.TryParse<Gender>(Console.ReadLine(), true, out teacherGender))
//////                {
//////                    Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
//////                }

//////                string teacherAddress;
//////                do
//////                {
//////                    Console.Write("Адреса: ");
//////                    teacherAddress = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(teacherAddress))
//////                    {
//////                        Console.WriteLine("Адреса не може бути порожньою!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(teacherAddress) || teacherAddress == "0");

//////                string subject;
//////                do
//////                {
//////                    Console.Write("Предмет: ");
//////                    subject = Console.ReadLine();
//////                    if (string.IsNullOrWhiteSpace(subject))
//////                    {
//////                        Console.WriteLine("Предмет не може бути порожнім!");
//////                    }
//////                } while (string.IsNullOrWhiteSpace(subject) || subject == "0");

//////                Teacher teacher = new Teacher(teacherFirstName, teacherLastName, teacherMiddleName, teacherGender, teacherAddress, subject);
//////                department.Teachers.Add(teacher);

//////                Console.WriteLine("Викладача додано.");
//////            }
//////        }

//////        private static void AskToSave(University university)
//////        {
//////            Console.WriteLine("Ви хочете зберегти дані? (введіть 'y' для так, 'n' для ні): ");
//////            string input = Console.ReadLine();
//////            if (input?.ToLower() == "y")
//////            {
//////                FileManager.SaveToFile(university); // Використання FileManager для збереження
//////                Console.WriteLine("Дані успішно збережено у файл.");
//////            }
//////            else
//////            {
//////                Console.WriteLine("Дані не збережені.");
//////            }
//////        }
//////    }
//////}




//////using System;

//////namespace UniversityDirectory
//////{
//////    public static class InputInformation
//////    {
//////        public static void CollectInputInformation(University university)
//////        {
//////            Console.WriteLine("Введіть назву факультету:");
//////            string facultyName = Console.ReadLine();
//////            Faculty faculty = new Faculty(facultyName);
//////            university.Faculties.Add(faculty);

//////            Console.WriteLine("Введіть назву кафедри:");
//////            string departmentName = Console.ReadLine();
//////            Department department = new Department(departmentName);
//////            faculty.Departments.Add(department);

//////            // Введення інформації про студентів
//////            while (true)
//////            {
//////                Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

//////                Console.Write("Ім'я: ");
//////                string firstName = Console.ReadLine();
//////                if (firstName == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Console.Write("Призвище: ");
//////                string lastName = Console.ReadLine();
//////                if (lastName == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Console.Write("По батькові: ");
//////                string middleName = Console.ReadLine();
//////                if (middleName == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Console.Write("Стать (Male/Female): ");
//////                Gender gender;
//////                while (!Enum.TryParse<Gender>(Console.ReadLine(), true, out gender))
//////                {
//////                    Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
//////                }

//////                Console.Write("Адреса: ");
//////                string address = Console.ReadLine();
//////                if (address == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Console.Write("Група: ");
//////                string group = Console.ReadLine();
//////                if (group == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                // Введення інформації про батька
//////                Console.Write("Ім'я батька: ");
//////                string parentFirstName = Console.ReadLine();
//////                if (parentFirstName == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Console.Write("Призвище батька: ");
//////                string parentLastName = Console.ReadLine();
//////                if (parentLastName == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Console.Write("Чи є батько викладачем (true/false): ");
//////                bool isTeacher;
//////                while (!bool.TryParse(Console.ReadLine(), out isTeacher))
//////                {
//////                    Console.Write("Неправильний ввід! Спробуйте ще раз (true/false): ");
//////                }

//////                Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);
//////                Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);
//////                department.Students.Add(student);

//////                Console.WriteLine("Студента додано.");
//////            }

//////            // Введення інформації про викладачів
//////            while (true)
//////            {
//////                Console.WriteLine("Введіть інформацію про викладача (введіть '0' для виходу):");

//////                Console.Write("Ім'я: ");
//////                string teacherFirstName = Console.ReadLine();
//////                if (teacherFirstName == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Console.Write("Призвище: ");
//////                string teacherLastName = Console.ReadLine();
//////                if (teacherLastName == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Console.Write("По батькові: ");
//////                string teacherMiddleName = Console.ReadLine();
//////                if (teacherMiddleName == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Console.Write("Стать (Male/Female): ");
//////                Gender teacherGender;
//////                while (!Enum.TryParse<Gender>(Console.ReadLine(), true, out teacherGender))
//////                {
//////                    Console.Write("Неправильний ввід! Спробуйте ще раз (Male/Female): ");
//////                }

//////                Console.Write("Адреса: ");
//////                string teacherAddress = Console.ReadLine();
//////                if (teacherAddress == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Console.Write("Предмет: ");
//////                string subject = Console.ReadLine();
//////                if (subject == "0")
//////                {
//////                    AskToSave(university);
//////                    return; // Вихід з методу
//////                }

//////                Teacher teacher = new Teacher(teacherFirstName, teacherLastName, teacherMiddleName, teacherGender, teacherAddress, subject);
//////                department.Teachers.Add(teacher);

//////                Console.WriteLine("Викладача додано.");
//////            }
//////        }

//////        private static void AskToSave(University university)
//////        {
//////            Console.WriteLine("Ви хочете зберегти дані? (введіть 'y' для так, 'n' для ні): ");
//////            string input = Console.ReadLine();
//////            if (input?.ToLower() == "y")
//////            {
//////                FileManager.SaveToFile(university); // Використання FileManager для збереження
//////                Console.WriteLine("Дані успішно збережено у файл.");
//////            }
//////            else
//////            {
//////                Console.WriteLine("Дані не збережені.");
//////            }
//////        }
//////    }
//////}



//////private static void CollectStudentInformation(Department department, Faculty faculty)
//////{
//////    while (true)
//////    {
//////        Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

//////        string firstName = ReadNonEmptyInput("Ім'я: ");
//////        if (firstName == "0") break;

//////        string lastName = ReadNonEmptyInput("Призвище: ");
//////        if (lastName == "0") break;

//////        string middleName = ReadNonEmptyInput("По батькові: ");
//////        if (middleName == "0") break;

//////        Gender gender = ReadGenderInput();
//////        string address = ReadNonEmptyInput("Адреса: ");
//////        if (address == "0") break;

//////        string group = ReadNonEmptyInput("Група: ");
//////        if (group == "0") break;

//////        // Введення інформації про батька
//////        string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
//////        string parentLastName = ReadNonEmptyInput("Призвище батька: ");
//////        bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

//////        Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);
//////        Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);
//////        department.Students.Add(student);

//////        Console.WriteLine("Студента додано.");

//////        // Виведення інформації про факультет і кафедру
//////        Console.WriteLine($"Факультет: {faculty.Name}, Кафедра: {department.Name}");

//////        // Вивід всіх студентів для перевірки
//////        //DisplayStudents(department);
//////    }
//////}



//////private static void CollectStudentInformation(Department department, Faculty faculty)
//////{
//////    while (true)
//////    {
//////        Console.WriteLine("Введіть інформацію про студента (введіть '0' для виходу):");

//////        string firstName = ReadNonEmptyInput("Ім'я: ");
//////        if (firstName == "0") break;

//////        string lastName = ReadNonEmptyInput("Призвище: ");
//////        if (lastName == "0") break;

//////        string middleName = ReadNonEmptyInput("По батькові: ");
//////        if (middleName == "0") break;

//////        Gender gender = ReadGenderInput();
//////        string address = ReadNonEmptyInput("Адреса: ");
//////        if (address == "0") break;

//////        string group = ReadNonEmptyInput("Група: ");
//////        if (group == "0") break;

//////        // Введення інформації про батька
//////        string parentFirstName = ReadNonEmptyInput("Ім'я батька: ");
//////        string parentLastName = ReadNonEmptyInput("Призвище батька: ");
//////        bool isTeacher = ReadBooleanInput("Чи є батько викладачем (true/false): ");

//////        Parent parent = new Parent(parentFirstName, parentLastName, isTeacher);
//////        Student student = new Student(firstName, lastName, middleName, gender, address, group, parent, department, faculty, phone: null);
//////        department.Students.Add(student);

//////        Console.WriteLine("Студента додано.");
//////    }
//////}

