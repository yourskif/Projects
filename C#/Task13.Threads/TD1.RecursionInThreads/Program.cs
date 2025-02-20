/*
 * Напишіть програму, в якій метод буде викликатися рекурсивно.
Кожен новий виклик методу виконується в окремому потоці.
 */
using System.Text;
using System.Threading;

namespace TD1.RecursionInThreads
{
    internal class Program
    {

        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                int result = 0;
                //return n * Factorial(n - 1);

                Thread thread = new Thread(() =>
                {
                    result = n * Factorial(n - 1);
                });

                thread.Start();
                thread.Join();  // Must have

                return result;
            }

        }



        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            int n = 3;

            Thread thread = new Thread(() => Factorial(n));


            int result = Factorial(n);

            Console.WriteLine($"Result= {result}");


            Console.WriteLine("I'm, here!");
        }
    }
}
