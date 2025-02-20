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

