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
            for (int rows = 0; rows < currentGeneration.GetLength(0); rows++)
            {
                for (int cols = 0; cols < currentGeneration.GetLength(1); cols++)
                {
                    Console.Write(currentGeneration[rows, cols].ToString());
                }
                Console.WriteLine();
            }
        }






    }
}
