using System;
using System.Collections.Generic;
using System.Linq;
using ChessLib;
using NUnit.Framework;
using SampleProgram;

namespace SampleProgram.Test
{
    [TestFixture]
    public class TestAnswerFixture
    {
        // TODO: add additional tests for your answer

        [Test]
        public void TestQueenMoveFromInsideBoard()
        {
            var pos = new Position(3, 3);
            var Queen = new QueenMove();

            var moves = Queen.ValidMovesFor(pos).ToArray();

            Assert.IsNotNull(moves);
            Assert.AreEqual(25, moves.Length);

            foreach (var move in moves)
            {
                int x = move.X - pos.X;
                int y = move.Y - pos.Y;
                Assert.IsTrue((x==0)||(y==0)||(x+y==0)||(x-y==0));
            }
        }

        [Test]
        public void TestQueenMoveFromCorner()
        {
            var pos = new Position(1, 1);
            var Queen = new QueenMove();

            var moves = new HashSet<Position>(Queen.ValidMovesFor(pos));

            Assert.IsNotNull(moves);
            Assert.AreEqual(21, moves.Count);

            var possibles = new[] { new Position(8, 8), new Position(8, 1), new Position(1, 8) };

            foreach (var possible in possibles)
            {
                Assert.IsTrue(moves.Contains(possible));
            }
        }
        [Test]
        public void TestBishopMoveFromInsideBoard()
        {
            var pos = new Position(3, 3);
            var Bishop = new BishopMove();

            var moves = Bishop.ValidMovesFor(pos).ToArray();

            Assert.IsNotNull(moves);
            Assert.AreEqual(11, moves.Length);

            foreach (var move in moves)
            {
                int x = move.X - pos.X;
                int y = move.Y - pos.Y;
                Assert.IsTrue((x + y == 0) || (x - y == 0));
            }
        }

        [Test]
        public void TestBishopMoveFromCorner()
        {
            var pos = new Position(8, 1);
            var Bishop = new BishopMove();

            var moves = new HashSet<Position>(Bishop.ValidMovesFor(pos));

            Assert.IsNotNull(moves);
            Assert.AreEqual(7, moves.Count);

            var possibles = new[] { new Position(7, 2), new Position(1, 8) };

            foreach (var possible in possibles)
            {
                Assert.IsTrue(moves.Contains(possible));
            }
        }

    }
}
