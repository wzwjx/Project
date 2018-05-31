using ChessLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleProgram
{

    public class ComplexGame
    {
        private readonly Random _rnd = new Random();
        private Position _startPosition;

        public void Setup()
        {
            // TODO: Set up the state of the game here
            _startPosition = new Position(1, 1);
        }

        public void Play(int moves)
        {
            // TODO: Play the game moves here
            var Queen = new QueenMove();
            var Knight = new KnightMove();
            var Bishop = new BishopMove();
            var Queen_pos = _startPosition;
            var Knight_pos = _startPosition;
            var Bishop_pos = _startPosition;
            Console.WriteLine("0: My Inint position is {0}", _startPosition);


            for (var move = 1; move <= moves; move++)
            {
                int i = _rnd.Next(1, 4); //Randomly obtained 1 to 3, corresponding to three pieces of random movement.
                if (i==1)
                {
                    var possibleMoves = Queen.ValidMovesFor(Queen_pos).ToList();
                    if (possibleMoves.Contains(Knight_pos))
                        possibleMoves.Remove(Knight_pos);
                    if (possibleMoves.Contains(Bishop_pos))
                        possibleMoves.Remove(Bishop_pos);
                    Queen_pos = possibleMoves[_rnd.Next(possibleMoves.Count)];
                    Console.WriteLine("{1}: My Queen position is {0}", Queen_pos, move);
                }
                if (i == 2)
                {
                    var possibleMoves = Knight.ValidMovesFor(Knight_pos).ToList();
                    if (possibleMoves.Contains(Queen_pos))
                        possibleMoves.Remove(Queen_pos);
                    if (possibleMoves.Contains(Bishop_pos))
                        possibleMoves.Remove(Bishop_pos);
                    Knight_pos = possibleMoves[_rnd.Next(possibleMoves.Count)];
                    Console.WriteLine("{1}: My Knight position is {0}", Knight_pos, move);
                }
                if (i == 3)
                {
                    var possibleMoves = Bishop.ValidMovesFor(Bishop_pos).ToList();
                    if (possibleMoves.Contains(Queen_pos))
                        possibleMoves.Remove(Queen_pos);
                    if (possibleMoves.Contains(Knight_pos))
                        possibleMoves.Remove(Knight_pos);
                    Bishop_pos = possibleMoves[_rnd.Next(possibleMoves.Count)];
                    Console.WriteLine("{1}: My Bishop_pos position is {0}", Bishop_pos, move);
                }
                
            }
        }
    }
 
    //Move rule of Bishop
    public class BishopMove
    {
        public static readonly int[,] Directions = new[,] { { -1, 1 }, { -1, -1 }, { 1, 1 }, { 1, -1 } };   //Defining Bishop's direction of movement。

        public IEnumerable<Position> ValidMovesFor(Position pos)
        {
            for (int j = 1; j < 8; j++)  //Traversing the number of moveable cells
            {
                for (var i = 0; i <= Directions.GetUpperBound(0); i++)
                {
                    var newX = pos.X + Directions[i, 0] * j;
                    var newY = pos.Y + Directions[i, 1] * j;
                    if (newX > 8 || newX < 1 || newY > 8 || newY < 1)
                        continue;
                    yield return new Position(newX, newY);
                }
            }
        }
    }

    //Move rule of Queen
    public class QueenMove
    {
        public static readonly int[,] Directions = new[,] { { -1, 1 }, { -1, -1 }, { 1, 1 }, { 1, -1 }, { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };   //Defining Queen's direction of movement。
        public IEnumerable<Position> ValidMovesFor(Position pos)
        {
            for (int j = 1; j < 8; j++)  //Traversing the number of moveable cells
            {
                for (var i = 0; i <= Directions.GetUpperBound(0); i++)
                {
                    var newX = pos.X + Directions[i, 0] * j;
                    var newY = pos.Y + Directions[i, 1] * j;
                    if (newX > 8 || newX < 1 || newY > 8 || newY < 1)
                        continue;
                    yield return new Position(newX, newY);
                }
            }
        }
    }

}
