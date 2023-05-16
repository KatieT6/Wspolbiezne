using Data;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DataTests
{
    [TestClass]
    public class DataAbstractAPITest
    {
        [TestMethod]
        public void BoardTest()
        {
            Board board = new();
            board.GenerateBalls(10,3,4,5);
            Assert.AreEqual(board.Balls, 10);
        }

        [TestMethod]
        public void BallConstruktorTest()
        {
            Vector2 v = new(1, 2);
            int radius = 5;
            Ball ball = new(v, radius);
            Assert.AreEqual(ball.Radious, radius);
            Assert.AreEqual(ball.Position, v);
        }

        [TestMethod]

        public void PositionChangedTest()
        {
            Ball ball = new(1500, 4, 5)
            {
                Velocity = new Vector2((float)0.003, (float)0.003),
                Position = new Vector2(50, 50)
            };
            ball.ChangePosition();
            Assert.AreNotEqual(50, ball.Position.X);
            Assert.AreNotEqual(50, ball.Position.Y);
            Assert.AreNotEqual(750, ball.Position.X);
            Assert.AreNotEqual(450, ball.Position.Y);
            Assert.AreEqual(new Vector2((float)0.003, (float)0.003), ball.Velocity);

        }
    }
}
