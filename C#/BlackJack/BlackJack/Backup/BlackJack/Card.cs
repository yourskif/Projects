using System;
using BlackJackGame;

namespace BlackJackCard
{
    class Card
    {
        public int val;
        //        Random z = new Random();

//        public int Get(){return val;}

        public int GetVal()
        {
            return val;
        }

        public int GetCard()
        {
            Random z = new Random();
            val = z.Next(1, 11);
            return val;
        }
        public void ShowCard()
        {
            Console.WriteLine("card is ============> : {0}", val);
        }
    }
}
