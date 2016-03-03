using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public enum CellCondition
    {
        Dead=1,
        Alive=2,
        toDie=3,
        toBeReborn=4,
    }
    class Cell
    {
        //all cells are, by default, in a dead state:
        public CellCondition cell = CellCondition.Dead; 
        public override string ToString()
        {
            if (cell == CellCondition.Alive)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return "▓";
            }
            else if(cell == CellCondition.toBeReborn)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return "▒";
            }
            else if (cell == CellCondition.toDie)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                return "░";
            }
            else /*if (cell == Condition.Dead)*/
                return " ";
        }
    }
}
