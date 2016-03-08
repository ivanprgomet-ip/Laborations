using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    enum CardSuite
    {
        Hearts = 1,
        Clubs,
        Diamonds,
        Spades,
    }
    public class Card 
    {
        internal CardSuite Suite { get; set; }
        internal int Value { get; set; }

        public override string ToString()
        {
            string face = string.Empty;

            if (Value == 11)
                face = "J";
            if (Value == 12)
                face = "Q";
            if (Value == 13)
                face = "K";

            if(Value<11)
            {
                if (Suite == CardSuite.Clubs)
                    return string.Format($"{Value}♣");
                else if (Suite == CardSuite.Diamonds)
                    return string.Format($"{Value}♦");
                else if (Suite == CardSuite.Hearts)
                    return string.Format($"{Value}♥");
                else /*if (Suite == CardSuite.Spades)*/
                    return string.Format($"{Value}♠");
            }
            else
            {
                if (Suite == CardSuite.Clubs)
                    return string.Format($"{face}♣");
                else if (Suite == CardSuite.Diamonds)
                    return string.Format($"{face}♦");
                else if (Suite == CardSuite.Hearts)
                    return string.Format($"{face}♥");
                else /*if (Suite == CardSuite.Spades)*/
                    return string.Format($"{face}♠");
            }
        }
    }
}
