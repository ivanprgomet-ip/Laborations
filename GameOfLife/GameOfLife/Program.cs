using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(20, 75);
            Game game = new Game();
            game.InjectCells(180, board.currentGeneration);
            board.Print();
            PrintLegend();
            Console.ReadKey();

            while(true)
            {
                Console.Clear();
                board.currentGeneration = game.ReturnNextGeneration(board.currentGeneration);
                board.Print();
                PrintLegend();
                Console.ReadKey();
                Console.ResetColor();
            }
        }
        public static void PrintLegend()
        {
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("ALIVE: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("▓");
            Console.ResetColor();

            Console.Write("BIRTH: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("▒");
            Console.ResetColor();

            Console.Write("DYING: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("░");
            Console.ResetColor();
        }
    }
}
