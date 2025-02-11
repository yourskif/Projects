using System;
using System.IO;
using NewtonsoftJson = Newtonsoft.Json; // Псевдонім для Newtonsoft.Json

namespace UniversityDirectory
{
    public static class FileManager
    {
        private static readonly string filePath = "UniversityData.json";

        public static void SaveToFile(University university)
        {
            try
            {
                var options = new NewtonsoftJson.JsonSerializerSettings
                {
                    ReferenceLoopHandling = NewtonsoftJson.ReferenceLoopHandling.Ignore, // Налаштування для циклічних посилань
                    Formatting = NewtonsoftJson.Formatting.Indented // Форматування для кращої читабельності
                };
                string jsonString = NewtonsoftJson.JsonConvert.SerializeObject(university, options);
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine("Дані успішно збережено у файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні даних: {ex.Message}");
            }
        }

        public static University LoadFromFile()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не знайдено, повертаємо новий університет.");
                    return new University(); // Повертаємо новий університет, якщо файл не існує
                }

                string jsonString = File.ReadAllText(filePath);
                University university = NewtonsoftJson.JsonConvert.DeserializeObject<University>(jsonString);

                if (university == null)
                {
                    Console.WriteLine("Десеріалізація повернула null, повертаємо новий університет.");
                    return new University(); // Повертаємо новий університет, якщо десеріалізація не вдалася
                }

                Console.WriteLine("Дані успішно завантажено з файлу.");
                return university;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при завантаженні даних: {ex.Message}");
                return new University(); // Повертаємо новий університет у разі помилки
            }
        }
    }
}



