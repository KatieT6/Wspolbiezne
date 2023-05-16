using Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace LogicTest.UnitTest
{
    public class Tests
    {
        LogicAbstractApi api;
        DataAbstractAPI data;

        [TestInitialize]
        public void Setup()
        {
            data = DataAbstractAPI.CreateDataAPI(5, 4, 3);
            data.generateBalls(10);
            api = LogicAbstractApi.CreateLogicAPI(data);
        }


        [TestMethod]
        public void CreateBallsTest()
        {
            int _amount = 10;
            int _radius = 25;
            api.TaskRun();
            Assert.AreEqual(api.getBalls().Count, _amount);

            foreach (Ball ball in data.getBalls())
            {
                Assert.IsTrue(ball.Position.X >= 1);
                Assert.IsTrue(ball.Position.X <= 750 - _radius);
                Assert.IsTrue(ball.Position.Y >= 1);
                Assert.IsTrue(ball.Position.Y <= 450 - _radius);
            }

        }

        [TestMethod]
        public void DeleteBallsTest()
        {
            api.TaskStop();
            Assert.AreEqual(0, api.getBalls().Count);
        }



    }
}