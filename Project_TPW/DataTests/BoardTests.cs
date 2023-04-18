using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tests
{
    [TestClass()]
    public class BoardTests
    {

        [TestMethod()]
        public void addBallTest()
        {
            Board board = new Board(21, 37);
            Ball b = new Ball(10, 10, 5);

            Assert.AreEqual(board.Balls.Count, 0);

            board.addBall(b);

            Assert.AreEqual(board.Balls.Count, 1);

            Ball b2 = new Ball(66, 66, 5);

            Assert.AreEqual(board.Balls.Count, 1);
        }
    }
}