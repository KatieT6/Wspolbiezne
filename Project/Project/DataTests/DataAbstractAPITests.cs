using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Data.Tests
{
    [TestClass]
    public class DataAbstractAPITests
    {
        private DataAbstractAPI _dataAPI;

        [TestInitialize]
        public void TestInitialize()
        {
            _dataAPI = DataAbstractAPI.CreateDataAPI(750, 400);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _dataAPI.RemoveBalls();
        }

        [TestMethod]
        public void BoardWidth_Should_Return_Correct_Value()
        {
            int expectedWidth = 750;

            int actualWidth = _dataAPI.BoardWidth;

            Assert.AreEqual(expectedWidth, actualWidth);
        }

        [TestMethod]
        public void BoardHeight_Should_Return_Correct_Value()
        {
            int expectedHeight = 400;

            int actualHeight = _dataAPI.BoardHeight;

            Assert.AreEqual(expectedHeight, actualHeight);
        }

        [TestMethod]
        public void GetBallAmount_Should_Return_Correct_Value()
        {
            _dataAPI.CreateBalls(5);
            int expectedAmount = 5;

            int actualAmount = _dataAPI.GetBallAmount();

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        public void GetBallByID_Should_Return_Correct_Ball()
        {
            _dataAPI.CreateBalls(3);
            int ballId = 1;
            BallInterface expectedBall = _dataAPI.GetBallByID(ballId);

            BallInterface actualBall = _dataAPI.GetBallByID(ballId);

            Assert.AreEqual(expectedBall, actualBall);
        }

        [TestMethod]
        public void CreateBalls_Should_Add_Correct_Number_Of_Balls()
        {
            int ballCount = 5;

            _dataAPI.CreateBalls(ballCount);

            int actualAmount = _dataAPI.GetBallAmount();
            Assert.AreEqual(ballCount, actualAmount);
        }
    }
}
