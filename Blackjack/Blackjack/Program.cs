using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Dealer dealer = new Dealer("dealer");
            Player player = new Player(false, "human");
            Player player2 = new Player(true, "Computer");

            dealer.ShuffleCards(deck);
            dealer.DealTo(2, dealer, deck);
            dealer.PrintHand();
            dealer.ProcessDecision(dealer, deck);

            dealer.DealTo(2, player, deck);
            player.PrintHand();

            dealer.DealTo(2, player2, deck);
            player2.PrintHand();

            Console.ReadKey();



        }
    }
}
