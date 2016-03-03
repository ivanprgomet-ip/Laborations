using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Board
    {
        public Cell[,] currentGeneration {get; set;}

        public Board(int rows, int cols)
        {
            currentGeneration = new Cell[rows, cols];

            //initializiation must be done AFTER 
            //the cells and rows memory space(s) 
            //have been allocated
            InitCells(currentGeneration);
        }
        public void InitCells(Cell[,] currentGeneration)
        {
            for (int rows = 0; rows < currentGeneration.GetLength(0); rows++)
            {
                for (int cols = 0; cols < currentGeneration.GetLength(1); cols++)
                {
                    currentGeneration[rows, cols] = new Cell();
                }
            }
        }

        public void Print()
        {
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //todo: make it print cells that are ALIVE, DEAD, ABOUT-TO-DIE, and ABOUT-TO-BE-REBORN.
            for (int rows = 0; rows < currentGeneration.GetLength(0); rows++)
            {
                for (int cols = 0; cols < currentGeneration.GetLength(1); cols++)
                {
                    Console.Write(currentGeneration[rows, cols].ToString());
                }
                Console.WriteLine();
            }
            //Console.ResetColor();
        }






    }
}
