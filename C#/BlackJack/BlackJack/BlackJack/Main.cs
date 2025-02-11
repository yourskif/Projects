using System;
using BlackJackCard;
using BlackJackPlayer;
//using BlackJackComputer;
using BlackJackGame;
    class Program
    {
        static int Main()
        {
            int games = 0,i=0;
            Console.WriteLine("Plain in 21. Please take cards:");


            while (games == 0)
            {
                Console.Clear();
                Console.WriteLine("START");
                Player man = new Player();
                Player computer = new Player();

                Game obj = new Game();

                Console.WriteLine("\n\nRESULT OF MAN :");
                obj.PlayStartPlayer(man);

                Console.WriteLine("\n\nRESULT OF COMPUTER :");
                obj.PlayStartPlayer(computer);
                Console.WriteLine("\n\nRESULT OF MAN :");
                obj.Play(man);
                Console.WriteLine("\n\nRESULT OF COMPUTER :");
                obj.PlayComputer(computer);
                obj.Compare(man, computer);
                int an;
                Console.WriteLine("\n\n****** BEGIN MEW GAME? press - '1-yes' or '2-no' ******");
                an = System.Convert.ToInt16(System.Console.ReadLine());
                if (an == 1)
                {
                    Console.Clear();
                    i = i + 1;
                    Main();
                    //                continue;
                }
                else
                {
                    return 0;
                }
        }

            return 0;
        }
    }
