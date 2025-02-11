using System;
using BlackJackCard;
using BlackJackPlayer;
//using BlackJackComputer;

namespace BlackJackGame
{
    class Game : Card
    {
        public static int game = 0 ;
        int result_man;
        int result_computer;
        //public void GameSet()
        //{
        //    Player man = new Player();
        //    Player computer = new Player();

        //}
//-------------------------------------------------------------------------------------------

        public void PlayStartPlayer(Player ob)
        {
            for (int i = 0; i < 2; i++)
            {
                ob.SetPlayer(ob.GetCard());
                ob.ShowCard();
                Console.WriteLine("result of {0}", ob);
                ob.PrintPlayer();
            }
        }
//-------------------------------------------------------------------------------------------
        public void Play(Player ob)
        {
            while (game == 0)
{
    if (ob.GetPlayer() == 21)
    {
        Console.WriteLine("YOU WIN THIS GAME");
        ob.PrintPlayer();
        result_man = 1;
        game = 1;
    }
    int an;
            Console.WriteLine("Would you like continue a game? press - '1-yes' or '2-no' ");
            an = System.Convert.ToInt16(System.Console.ReadLine());
            if (an == 1)
            {
                if (ob.GetPlayer() > 21)
                {
                    Console.WriteLine("YOU LOSE THIS GAME");
                    ob.PrintPlayer();
                    result_man = 0;
                    game = 1;
                }
                else
                {
                    ob.SetPlayer(ob.GetCard());
                    ob.ShowCard();
                    Console.WriteLine("result of {0}", ob);
                    ob.PrintPlayer();
                    if (ob.GetPlayer() > 21)
                    {
                        Console.WriteLine("\n\n===========YOU LOSE THIS GAME===========");
                        ob.PrintPlayer();
                        result_man = 0;
                        game = 1;
                    }
                    else
                    {
                    }

                }

            }
            else 
            {
                game = 1;
            }
        } // --
 } //--
//-------------------------------------------------------------------------------------------
 public void PlayComputer(Player ob)
 {
     game = 0;
     //while (game == 0)
     //{
         Console.WriteLine("PLAING COMPUTER:");
         game = 0;
         while (game == 0)
         {
             if (ob.GetPlayer() == 21)
         {
             Console.WriteLine("COMPUTER WIN THIS GAME");
             ob.PrintPlayer();
             result_computer = 1;
             game = 1;
         }
             if (ob.GetPlayer() > 21)
             {
                 Console.WriteLine("COMPUTER LOSE THIS GAME");
                 ob.PrintPlayer();
                 result_computer = 0;
                 game = 1;
             }
             //game = 0;
             //while (game == 0)
             //{
                 if (ob.GetPlayer() == 21)
                 {
                     Console.WriteLine("COMPUTER WIN THIS GAME");
                     ob.PrintPlayer();
                     result_computer = 1;
                     game = 1;
                 }
                 if (ob.GetPlayer() < 21)
                 {
                     //ob.PrintPlayer();
                     if (ob.GetPlayer() <= 16)
                     {
                         ob.SetPlayer(ob.GetCard());
                         ob.ShowCard();
                         Console.WriteLine("result of {0}", ob);
                         ob.PrintPlayer();
                         if (ob.GetPlayer() > 21)
                         {
                             Console.WriteLine("\n\n===========COMPUTER LOSE THIS GAME===========");
                             ob.PrintPlayer();
                             result_computer = 0;
                             game = 1;
                         }
                         if (ob.GetPlayer() >= 17)
                         {
                             //Console.WriteLine("===================>=17");
                             ob.PrintPlayer();
                             game = 1;
                         }
                         //else 
                         //{
                             //game = 1;
                         //    continue;
                         //}
                     }
                 }
            // }
     } // --
 } //--
 //-------------------------------------------------------------------------------------------
        public void Compare(Player ob1, Player ob2)
        {
            Console.WriteLine();
            Console.Write("                    RESULT of man:      "); ob1.PrintPlayer();
            Console.Write("                    RESULT of computer: "); ob2.PrintPlayer();
            if ((ob1.GetPlayer() <= 21) && (ob2.GetPlayer() <= 21))
            {
                if ((ob1.GetPlayer() > ob2.GetPlayer()))
                { Console.WriteLine("MAN WAS WIN THIS GAME"); }
                else 
                { Console.WriteLine("COMPUTER WAS WIN THIS GAME"); }
            }
            else
            {
                if ((ob1.GetPlayer() <= 21) && (ob2.GetPlayer() > 21)) { Console.WriteLine("MAN WAS WIN THIS GAME"); }
                if ((ob2.GetPlayer() <= 21) && (ob1.GetPlayer() > 21)) { Console.WriteLine("COMPUTER WAS WIN THIS GAME"); }

                if (ob2.GetPlayer() == ob1.GetPlayer()) { Console.WriteLine("TIE UP"); }
            }


            //else
            //if ((ob1.GetPlayer() <= 21) && (ob2.GetPlayer() <= 21))
            //{
                //if ((ob1.GetPlayer() > ob2.GetPlayer()) && (ob1.GetPlayer() <= 21) && (ob2.GetPlayer() <= 21) && (ob1.GetPlayer() != ob2.GetPlayer()))
                //    Console.WriteLine("MAN WAS WIN THIS GAME");
                //else
                //    Console.WriteLine("COMPUTER WAS WIN THIS GAME");

            //}

            //if (ob1.GetPlayer() == ob2.GetPlayer())
            //{
            //    Console.WriteLine("TIE UP");
            //}
            //else
            //{
            //}
        }
 //-------------------------------------------------------------------------------------------




 } 
}

