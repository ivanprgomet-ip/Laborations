using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Dealer:Player
    {
        public Dealer(string name):base(true,name)
        {
            //dealer is always a bot
        }

        public Card[] ShuffleCards(Deck deck)
        {
            //shuffles deck of cards 
            Random rnd = new Random();

            for (int i = 0; i < deck.cards.Length; i++)
            {
                int r = rnd.Next(deck.cards.Length);//random index generated (0-51)
                Card temp = deck.cards[i];//card in index i gets placed in temp variable
                deck.cards[i] = deck.cards[r];//card on rnd index (=rnd card) gets placed in index i
                deck.cards[r] = temp;//temp var gets placed where the rnd card was taken from
            }
            return deck.cards;
        }

        //todo: fix DealTo(); and HitOrStay();
        public void DealTo(int amount, Player player,Deck deck)
        {
            for (int i = player.counter; i < amount; i++)
            {
                player.Hand[i] = deck.ReturnCard();
                player.counter++;
            }
        }
        public void ProcessDecision(Player player,Deck deck)
        {
            //whenever someone busts or stays, 
            //round is over for that player
            bool isBustOrStay = false;


            while (!isBustOrStay)
            {
                if (player.IsBot)//if the player is a bot, player decides what to do based on programmed logic
                {
                    if (player.currentTotal > 17)
                    {
                        isBustOrStay = true;
                        Console.WriteLine(player.Name + " stay");
                        //break;
                    }
                    else //todo: this is eternity loop??
                    {
                        DealTo(1, player, deck);
                        ///*
                        //if player busts, bool isBustOrStay gets 
                        //set to true, and player gets thrown 
                        //out of loop
                        //*/
                        isBustOrStay = CheckBust(player);
                    }
                }
                else //if player is human, human decides via input what to do
                {
                    Console.WriteLine("Hit or Stay? h/s");
                    string hitorstay = Console.ReadLine();

                    if (hitorstay == "h")
                    {
                        DealTo(1, player, deck);
                        player.PrintHand();
                    }
                    else
                    {
                        Console.WriteLine($"{player.Name}: stay");
                        isBustOrStay = true;
                    }
                }
            }
        }
        private bool CheckBust(Player player)
        {
            if (player.currentTotal > 21)
                return true;
            else
                return false;
        }
    }
}
