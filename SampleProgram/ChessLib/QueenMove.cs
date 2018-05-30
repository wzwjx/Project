using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLib
{
    public class QueenMove
    {
        public static readonly int[,] Directions = new[,] { { -1,1},{ -1,-1},{ 1,1},{ 1,-1} ,{ 1,0},{ -1,0},{ 0,1},{ 0,-1} };   //Defining Queen's direction of movement。
        public IEnumerable<Position> ValidMovesFor(Position pos)
        {
            for(int j = 1; j < 8; j++)  //Traversing the number of moveable cells
            {
                for (var i = 0; i <= Directions.GetUpperBound(0); i++)
                {
                    var newX = pos.X + Directions[i, 0]*j;
                    var newY = pos.Y + Directions[i, 1]*j;
                    if (newX > 8 || newX < 1 || newY > 8 || newY < 1)
                        continue;
                    yield return new Position(newX, newY);
                }
            }
        }
    }
}
