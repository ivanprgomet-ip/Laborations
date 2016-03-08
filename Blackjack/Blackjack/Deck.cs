using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        public Card[] cards { get; set; }
        private int count = 0;

        public Deck()
        {
            /*the 2d array gets initialized in the constructor.
            every Card object gets initialized in the Generate 
            method to avoid nullreference exception. If we dont
            do the last mentioned thing, we successfully initialize
            an 2darray of nulls*/
            cards = new Card[52];
            Initialize();
        }
        private void Initialize()
        {
            int cardCount = 1;

            /*method is private because the deck will only be used 
            in the constructor. no need to be using this method anywhere else 
            if its in the ctor at initialization time*/
            for (int i=0;i<cards.Length;i++)
            {
                    cards[i] = new Card();//Every card gets New'd to avoid references to nothing (nulls)
                    cards[i].Value = cardCount;//every card gets set to its face value.

                    if (cards[i].Value % 13 == 0)
                    {
                        /*Restarts the counter so that every suite can 
                        get it's corresponding numbers right (1-13)
                        without this statement, the card values would
                        rise 1-52*/ 
                        cardCount = 0;
                    }
                    //setting the cards to their right suite
                    if (i == 0)
                        cards[i].Suite = CardSuite.Clubs;
                    if(i ==1)
                        cards[i].Suite = CardSuite.Diamonds;
                    if (i == 2)
                        cards[i].Suite = CardSuite.Hearts;
                    if (i == 3)
                        cards[i].Suite = CardSuite.Spades;

                //essential to get rising face values (1-52)
                cardCount++;
            }
        }
        public void Print()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (i % 13 == 0)
                {
                    //formats output 4 by 13
                    Console.WriteLine();
                }
                if (cards[i].Value != 0) //displays card.tostring() if value is NOT zero
                    Console.Write(cards[i].ToString() + " ");
                else //simulates empty slot if value IS zero
                    Console.Write("[] ");
            }
        }//tostring


        public Card ReturnCard()
        {
                //every time this method is run, it should return
                //the next card in the deck, and at the same time, 
                //put the returned card "spot" to 0, because it does
                //not exist in the deck anymory, its in someones hand.
                Card nextCard = new Card();

                for (int currentCard = 0; currentCard < 1; currentCard++)
                {
                    //nextcard gets assigned the value of 
                    //current count index in the deck of 
                    //cards (before the count gets +1):
                    nextCard.Value = cards[count].Value;
                    nextCard.Suite= cards[count].Suite;

                //sets the pulled card value to 0 in the deck:
                cards[count].Value = 0;
                    
                    //prepares count for next time a card gets pulled:
                    count++;
                }
                return nextCard;
                //returns card on top of deck everytime
                //update deck so that pulled cards dont
                //exist in deck anymore (0)
        }
    }
}
