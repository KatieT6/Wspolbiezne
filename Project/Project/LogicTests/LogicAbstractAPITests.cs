using Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace LogicTest.UnitTest
{
    public class Tests
    {
        LogicAbstractAPI api;
        DataAbstractAPI data;

        [TestInitialize]
        public void Setup()
        {
            data = DataAbstractAPI.CreateDataAPI(5, 4, 3);
            data.generateBalls(10);
            api = LogicAbstractAPI.CreateLogicAPI(data);
        }


        [TestMethod]
        public void CreateBallsTest()
        {
            int _amount = 10;
            int _radius = 25;
<<<<<<< HEAD
<<<<<<< HEAD
            api.TaskRun();
            Assert.AreEqual(api.getBalls().Count, _amount);
=======
            api.RunSimulation();
            Assert.That(api.Balls().Count, Is.EqualTo(_amount));
>>>>>>> 6d106460ff17b0e47a0b485241eb1c4a056a0cc2
=======
            api.RunSimulation();
            Assert.That(api.Balls().Count, Is.EqualTo(_amount));
>>>>>>> 0b804d85db8e0efae133ece25bf13c7571717499

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
            api.StopSimulation();
            Assert.AreEqual(0, api.Balls().Count);
        }



    }
}