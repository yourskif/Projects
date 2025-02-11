using System;
using System.Threading;

namespace ConsoleRectangle
{
    class Program
    {
        static Random random = new Random();
        static object locker = new object();

        static void WriteChain(int x)
        {
            int length = random.Next(5, 20);
            int y = 0;

            while (true)
            {
                // Очищення попереднього ланцюга
                if (y > 0)
                {
                    for (int i = 0; i < length; i++)
                    {
                        int posX = x;
                        int posY = y - i;

                        if (posX >= 0 && posX < Console.WindowWidth && posY >= 0 && posY < Console.WindowHeight)
                        {
                            WriteAtPosition(posX, posY, " ", ConsoleColor.Black);
                        }
                    }
                }

                // Малюємо новий ланцюг
                for (int i = 0; i < length; i++)
                {
                    char symbol = (char)random.Next(33, 126);
                    int posX = x;
                    int posY = y - i;

                    if (posX >= 0 && posX < Console.WindowWidth && posY >= 0 && posY < Console.WindowHeight)
                    {
                        if (i == 0)
                        {
                            WriteAtPosition(posX, posY, symbol.ToString(), ConsoleColor.White);
                        }
                        else if (i == 1)
                        {
                            WriteAtPosition(posX, posY, symbol.ToString(), ConsoleColor.Green);
                        }
                        else
                        {
                            WriteAtPosition(posX, posY, symbol.ToString(), ConsoleColor.DarkGreen);
                        }
                    }
                }

                Thread.Sleep(100);
                y++;

                // Якщо ланцюг досягає низу, починаємо новий
                if (y >= Console.WindowHeight)
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
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }
        }

        static void Main()
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            for (int i = 0; i < 5; i++)
            {
                int x = random.Next(0, Console.WindowWidth);
                //int x = i;
                Thread thread = new Thread(() => WriteChain(x));
                thread.Start();
            }

            Console.ReadKey();
        }
    }
}
