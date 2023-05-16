using Data;
using Logic;
using NUnit.Framework;
using System.Numerics;

namespace LogicTest.UnitTest
{
    public class Tests
    {
        LogicAbstractApi api;
        DataAbstractAPI data;

        [SetUp]
        public void Setup()
        {
            data = DataAbstractAPI.CreateDataAPI(5, 4, 3);
            data.generateBalls(10);
            api = LogicAbstractApi.CreateLogicAPI(data);
        }


        [Test]
        public void CreateBallsTest()
        {
            int _amount = 10;
            int _radius = 25;
            api.TaskRun();
            Assert.That(api.getBalls().Count, Is.EqualTo(_amount));

            foreach (Ball ball in data.getBalls())
            {
                Assert.IsTrue(ball.Position.X >= 1);
                Assert.IsTrue(ball.Position.X <= 750 - _radius);
                Assert.IsTrue(ball.Position.Y >= 1);
                Assert.IsTrue(ball.Position.Y <= 450 - _radius);
            }

        }

        [Test]
        public void DeleteBallsTest()
        {
            api.TaskStop();
            Assert.AreEqual(0, api.getBalls().Count);
        }



    }
}