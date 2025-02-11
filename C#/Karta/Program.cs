using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karta
{

    class Program
    {
        private int i;
        private int n = 0;
        private int summ = 0;
        private int summus = 0;
        private int c = 0;
        private int[] cards =
        {
            2,2,2,2,
            3,3,3,3,
            4,4,4,4,
            5,5,5,5,
            6,6,6,6,
            7,7,7,7,
            8,8,8,8,
            9,9,9,9,
            10,10,10,10,
            10,10,10,10,
            10,10,10,10,
            10,10,10,10,
            11,11,11,11
        };
        private int[] compcards = new int[5];
        private int[] usercards = new int[5];
        /*private static int ins()
        {
            int[] bcards = new int[10];
            for (int i = 0; i < bcards.Length; i++) 
            {
                bcards[i] = 0;
            }
            return bcards[10]; 
        }*/
        private int game()
        {
            int[] bcards = new int[10];
            for (int i = 0; i < bcards.Length; i++)
            {
                bcards[i] = 0;
            }
            Console.WriteLine("Сдаю карты");
            Random rand = new Random();
            for (i = 0; i < 2; i++)
            {
            L1:
                n = rand.Next(2, 11);
                //Console.WriteLine("This {0}", n);
                compcards[i] = n;
                if (compcards[0] + compcards[1] == 21)
                {
                    Console.WriteLine("У меня 21 очко, я выиграл");
                    break;
                }
                if (compcards[i] == n)
                {
                    bcards[n - 2] += 1;
                    if (bcards[n - 2] >= 4 && n - 2 != 9)
                        goto L1;
                    if (bcards[n - 2] >= 16 && n - 2 == 9)
                        goto L1;
                }
            }
            if (compcards[0] + compcards[1] >= 18)
            {
                Console.WriteLine("Мне хватит");
                //break;
            }
            else
            {
                for (i = 2; i < 5; i++)
                {
                L1:
                    n = rand.Next(2, 11);
                    //Console.WriteLine("This {0}", n);
                    compcards[i] = n;
                    if (compcards[i] == n)
                    {
                        bcards[n - 2] += 1;
                        if (bcards[n - 2] >= 4 && n - 2 != 9)
                            goto L1;
                        if (bcards[n - 2] >= 16 && n - 2 == 9)
                            goto L1;
                        for (int j = 0; j < 5; j++)
                        {
                            summ += compcards[j];
                        }
                        if (summ == 21)
                        {
                            Console.WriteLine("У меня 21 очко, я выиграл");
                            goto L4;
                        }
                        if (summ >= 18)
                        {
                            Console.WriteLine("Мне хватит");
                            break;
                        }
                    }
                }
            }
            for (i = 0; i < 2; i++)
            {
            L2:
                n = rand.Next(2, 11);
                usercards[i] = n;
                if (usercards[i] == n)
                {
                    bcards[n - 2] += 1;
                    if (bcards[n - 2] >= 4 && n - 2 != 9)
                        goto L2;
                    if (bcards[n - 2] >= 16 && n - 2 == 9)
                        goto L2;
                }
            }
            Console.Write("Карты игрока:");
            for (i = 0; i < 5; i++)
            {
                if (usercards[i] != 0)
                    Console.Write("{0};", usercards[i]);
            }
            Console.WriteLine();
            string answer2;
            for (i = 2; i < 5; i++)
            {
            L2:
                Console.WriteLine("Ещё?");
                answer2 = Console.ReadLine();
                /*{
                    Console.Write("Карты игрока:");
                    for (int d = 0; d < 5; d++)
                    {
                        if (usercards[d] != 0)
                            Console.Write("{0};", usercards[d]);
                    }
                }*/
                if (answer2 == "нет") goto L5;
                if (answer2 == "да")
                {
                    n = rand.Next(2, 11);
                    usercards[i] = n;
                    Console.Write("Карты игрока:");
                    for (int d = 0; d < 5; d++)
                    {
                        if (usercards[d] != 0)
                            Console.Write("{0};", usercards[d]);
                    }
                    Console.WriteLine();
                }
                if (usercards[i] == n)
                {
                    bcards[n - 2] += 1;
                    if (bcards[n - 2] >= 4 && n - 2 != 9)
                        goto L2;
                    if (bcards[n - 2] >= 16 && n - 2 == 9)
                        goto L2;
                }
                for (int j = 0; j < 5; j++)
                {
                    if (usercards[j] != 0) { c++; }
                }
                if (c == 5) { break; }
            }
        L5:
            Console.Write("Карты компьютера:");
            for (i = 0; i < 5; i++)
            {
                Console.Write("{0};", compcards[i]);
            }
            Console.WriteLine();
            Console.Write("Карты игрока:");
            for (i = 0; i < 5; i++)
            {
                summus += usercards[i];
                if (usercards[i] != 0)
                    Console.Write("{0};", usercards[i]);
            }
            /*Console.WriteLine();
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}", bcards[i]);
            }*/
            Console.WriteLine();
            if (summ > summus && summ <= 21)
            {
                Console.WriteLine("Я выиграл");
            }
            if (summ < summus && summus <= 21)
            {
                Console.WriteLine("Вы выиграли");
            }
            if (summ == summus || (summ > 21 && summus > 21))
            {
                Console.WriteLine("Ничья");
            }
        L4: Console.WriteLine("Конец игры");
            return 0;
        }
        static void Main(string[] args)
        {
            Program ex = new Program();
            ex.game();

        }
    }



}
