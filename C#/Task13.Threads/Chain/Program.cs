using System;
using System.Threading;

namespace FallingChains
{
    class Program
    {
        static Random random = new Random();
        static object locker = new object();

        static void WriteChain(int x)
        {
            int length = random.Next(5, 20); // Генеруємо випадкову довжину ланцюжка
            int y = 0;

            while (true)
            {
                for (int i = 0; i < length; i++)
                {
                    char symbol = (char)random.Next(33, 126); // Генеруємо випадковий символ

                    if (i == 0)
                    {
                        WriteAtPosition(x, y - i, symbol.ToString(), ConsoleColor.White);
                    }
                    else if (i == 1)
                    {
                        WriteAtPosition(x, y - i, symbol.ToString(), ConsoleColor.Green);
                    }
                    else
                    {
                        WriteAtPosition(x, y - i, symbol.ToString(), ConsoleColor.DarkGreen);
                    }
                }

                Thread.Sleep(100);

                // Очищення символа на верхній частині ланцюжка
                if (y >= length)
                {
                    WriteAtPosition(x, y - length, " ", ConsoleColor.Black);
                }

                y++;

                // Якщо ланцюжок дійшов до кінця, починаємо новий
                if (y - length >= Console.WindowHeight)
                {
                    y = 0;
                    length = random.Next(5, 20);
                }
            }
        }

        static void WriteAtPosition(int x, int y, string text, ConsoleColor color)
        {
            lock (locker)
            {
                if (x >= 0 && y >= 0 && x < Console.BufferWidth && y < Console.BufferHeight)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = color;
                    Console.Write(text);
                    Console.ResetColor();
                }
            }
        }

        static void Main()
        {
            // Встановлюємо розмір вікна консолі
            Console.SetWindowSize(80, 25);

            // Створюємо і запускаємо кілька ланцюжків у різних позиціях
            for (int i = 0; i < 5; i++)
            {
                int x = random.Next(0, Console.WindowWidth);
                Thread thread = new Thread(() => WriteChain(x));
                thread.Start();
            }

            // Затримка перед закриттям консолі
            Console.ReadKey();
        }
    }
}






//namespace Chain
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//        }
//    }
//}
