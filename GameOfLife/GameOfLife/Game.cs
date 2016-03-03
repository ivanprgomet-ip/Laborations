using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Game
    {
        public Cell[,] CloneArray(Cell[,] currentGeneration)
        {
            Cell[,] tempBoard = new Cell[currentGeneration.GetLength(0), currentGeneration.GetLength(1)];
            for (int rows = 0; rows < currentGeneration.GetLength(0); rows++)
            {
                for (int cols = 0; cols < currentGeneration.GetLength(1); cols++)
                {
                    /*a new cell gets instantiated. the current bool status from the 
                    input array gets copied over to the new cells bool property isAlive. 
                    the new cell gets copied over to the new tempBoard. two distinct arrays
                    now exist in the memory, which is what we want.
                    Without declaring "new" cells, the old array and the new temp will 
                    point at the same memory location*/
                    Cell myNewCell = new Cell(); 
                    myNewCell.cell = currentGeneration[rows, cols].cell;//the new cells state becomes the same as the old cells state
                    tempBoard[rows, cols] = myNewCell;
                }
            }
            return tempBoard;
        }

        public Cell[,] InjectCells(int amount, Cell[,] inputBoard)
        {
            /*Cells containing life get injected into the array.
            where user choses the amount of cells to inject*/

            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int rndRow = rnd.Next(inputBoard.GetLength(0));
                int rndCol = rnd.Next(inputBoard.GetLength(1));

                inputBoard[rndRow, rndCol].cell= CellCondition.Alive;
            }
            return inputBoard;
        }
        public int CountNeighbours(int row, int col, Cell[,] inputBoard)
        {
            int amountOfNeighbours = 0;

            /*todo: just added more conditions to count neighbours. if a cell
            is alive or about to die still counts as a valid living cell,
            and therefore counts as a valid neighbour*/
            if (row != 0)
            {
                if (inputBoard[row - 1, col].cell == CellCondition.Alive)
                {
                    amountOfNeighbours++;
                }
                else if (inputBoard[row - 1, col].cell == CellCondition.toDie)
                {
                    amountOfNeighbours++;
                }
            }
            if (col != 0)
            {
                if (inputBoard[row, col - 1].cell == CellCondition.Alive)
                {
                    amountOfNeighbours++;
                }
                else if (inputBoard[row, col - 1].cell == CellCondition.toDie)
                {
                    amountOfNeighbours++;
                }
            }
            if (row != inputBoard.GetLength(0) - 1)
            {
                if (inputBoard[row + 1, col].cell == CellCondition.Alive)
                {
                    amountOfNeighbours++;
                }
                else if (inputBoard[row + 1, col].cell == CellCondition.toDie)
                {
                    amountOfNeighbours++;
                }
            }
            if (col != inputBoard.GetLength(1) - 1)
            {
                if (inputBoard[row, col + 1].cell == CellCondition.Alive)
                {
                    amountOfNeighbours++;
                }
                else if (inputBoard[row, col + 1].cell == CellCondition.toDie)
                {
                    amountOfNeighbours++;
                }
            }
            if (row != inputBoard.GetLength(0) - 1 && col != inputBoard.GetLength(1) - 1)
            {
                if (inputBoard[row + 1, col + 1].cell == CellCondition.Alive)
                {
                    amountOfNeighbours++;
                }
                else if (inputBoard[row + 1, col + 1].cell == CellCondition.toDie)
                {
                    amountOfNeighbours++;
                }
            }
            if (row != 0 && col != 0)
            {
                if (inputBoard[row - 1, col - 1].cell == CellCondition.Alive)
                {
                    amountOfNeighbours++;
                }
                else if (inputBoard[row - 1, col - 1].cell == CellCondition.toDie)
                {
                    amountOfNeighbours++;
                }
            }
            if (row != 0 && col != inputBoard.GetLength(1) - 1)
            {
                if (inputBoard[row - 1, col + 1].cell == CellCondition.Alive)
                {
                    amountOfNeighbours++;
                }
                else if (inputBoard[row - 1, col + 1].cell == CellCondition.toDie)
                {
                    amountOfNeighbours++;
                }
            }
            if (col != 0 && row != inputBoard.GetLength(0) - 1)
            {
                if (inputBoard[row + 1, col - 1].cell == CellCondition.Alive)
                {
                    amountOfNeighbours++;
                }
                else if (inputBoard[row + 1, col - 1].cell == CellCondition.toDie)
                {
                    amountOfNeighbours++;
                }
            }
            return amountOfNeighbours;
        }
        public Cell[,] ReturnNextGeneration(Cell[,] currentGeneration)
        {
            Cell[,] nextGeneration = CloneArray(currentGeneration);
            /*at this point, the nextGeneration and currentGeneration are the same, but have their own memory
            spaces allocated (see inside CloneArray()). Further changes in this method are now happening to 
            the nextGeneration, where the currentGeneration stays untouched. You need the previous generation 
            untouched (unmanipulated) during calculation of the new generation */

            for (int rows = 0; rows < currentGeneration.GetLength(0); rows++)
            {
                for (int cols = 0; cols < currentGeneration.GetLength(1); cols++)
                {
                    /*think like this: 
                    1. If a cell is about to die in the "currentGeneration", then it is dead in the "nextGeneration"
                    2. If a cell is alive in the "currentGeneration", then it kan only be "Dying" or "Alive (survived)" in the "nextGeneration"
                    3. If a cell is about to be reborn in the "currentGeneration", then it is alive in the "nextGeneration"
                    4. If a cell is dead in the "currentGeneration", then it can only be reborn or continue to be dead in the "nextGeneration"*/
                    //////////////////////////////////////////////////////////////SCENARIOS FOR LIVING CELLS/////////////////
                    if (currentGeneration[rows, cols].cell == CellCondition.Alive)
                    {
                        /////////////////////DIES/////////////////////
                        if (CountNeighbours(rows, cols, currentGeneration) < 2 || CountNeighbours(rows, cols, currentGeneration) > 3)
                            nextGeneration[rows, cols].cell = CellCondition.toDie;
                        /////////////////////SURVIVES/////////////////
                        else if (CountNeighbours(rows, cols, currentGeneration) == 2 || CountNeighbours(rows, cols, currentGeneration) == 3)
                            nextGeneration[rows, cols].cell = CellCondition.Alive;
                    }
                    
                    else if (currentGeneration[rows, cols].cell == CellCondition.toDie)
                        nextGeneration[rows, cols].cell = CellCondition.Dead;
                    
                    else if (currentGeneration[rows, cols].cell == CellCondition.toBeReborn)
                        nextGeneration[rows, cols].cell = CellCondition.Alive;
                    
                    //////////////////////////////////////////////////////////////SCENARIOS FOR DEAD CELLS///////////////////
                    else if (currentGeneration[rows, cols].cell == CellCondition.Dead)
                    {
                        /////////////////////BORN/////////////////////    
                        if (CountNeighbours(rows, cols, currentGeneration) == 3)
                            nextGeneration[rows, cols].cell = CellCondition.toBeReborn;
                        else
                            nextGeneration[rows, cols].cell = CellCondition.Dead;
                    }
                }
            }
            return nextGeneration;
        }
    }
}
