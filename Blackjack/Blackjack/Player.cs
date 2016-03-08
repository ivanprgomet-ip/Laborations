using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        //auto-properties 
        public int counter { get; set; } = 0; //keep track of player hand and placing cards in right index since last time
        public bool IsBot { get; }
        public string Name { get; }
        public Card[] Hand { get; set; }
        public int currentTotal { get; set; } = 0;

        //constructor | contains initializer methods for players
        public Player(bool isBot,string name)
        {
            Name = name;
            IsBot = isBot;//set via ctor if player is OR is not a bot 
            Hand = new Card[11];//initializes array 
            Initialize();//initializes elements in array
        }

        public void PrintHand()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.Write($"{Name} >> ");

            for (int i = 0; i < Hand.Length; i++)
            {
                if (Hand[i].Value != 0)
                    Console.Write(Hand[i].ToString() + " ");
                else
                    break;
            }
            Console.WriteLine($"({CalcHand()})");
            Console.ResetColor();
        }
        //private methods | not used outside of class 
        private int CalcHand()
        {
            for (int i = 0; i < Hand.Length; i++)
            {
                /*  
                Scoring: 
                1-10p regular cards (1-10)
                10p face cards (J-K)
                */
                if (Hand[i].Value < 11)
                    currentTotal += Hand[i].Value;
                else if (Hand[i].Value > 10)
                    currentTotal += 10;
            }
            return currentTotal;
        }
        private void Initialize()
        {
            for (int i = 0; i < Hand.Length; i++)
            {
                Hand[i] = new Card();
            }
        }
    }
}
