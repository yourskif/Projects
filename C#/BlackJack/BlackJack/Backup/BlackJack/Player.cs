using System;
//using BlackJackGame;
using BlackJackCard;

namespace BlackJackPlayer
{
    class Player:Card
    {
        int sum=0;
//        Player() { sum = 0; }
        public void SetPlayer(int val){sum = sum + val;}

        public int GetPlayer() { return sum;}


        public void PrintPlayer()
        {
            Console.WriteLine("player sum= {0}",sum);
        }
    }
}
