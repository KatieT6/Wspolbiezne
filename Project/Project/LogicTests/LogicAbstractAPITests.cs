using System;
using System.Numerics;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class LogicAbstractAPITests
    {
        [TestMethod]
        public void CreateLogicAPI_ShouldReturnInstanceOfLogicAPI()
        {
            // Arrange
            int width = 800;
            int height = 600;

            // Act
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateLogicAPI(width, height);

            // Assert
            Assert.IsNotNull(logicAPI);
            Assert.IsInstanceOfType(logicAPI, typeof(LogicAbstractAPI));
        }

        [TestMethod]
        public void CreateBalls_ShouldCreateSpecifiedNumberOfBalls()
        {
            // Arrange
            int width = 800;
            int height = 600;
            int ballCount = 5;
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateLogicAPI(width, height);

            // Act
            logicAPI.CreateBalls(ballCount);
            int actualBallCount = logicAPI.GetBallsAmount();

            // Assert
            Assert.AreEqual(ballCount, actualBallCount);
        }

        [TestMethod]
        public void DeleteBalls_ShouldRemoveAllBalls()
        {
            // Arrange
            int width = 800;
            int height = 600;
            int ballCount = 5;
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateLogicAPI(width, height);
            logicAPI.CreateBalls(ballCount);

            // Act
            logicAPI.DeleteBalls();
            int actualBallCount = logicAPI.GetBallsAmount();

            // Assert
            Assert.AreEqual(0, actualBallCount);
        }

        [TestMethod]
        public void GetBallsAmount_ShouldReturnCorrectNumberOfBalls()
        {
            // Arrange
            int width = 800;
            int height = 600;
            int ballCount = 5;
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateLogicAPI(width, height);
            logicAPI.CreateBalls(ballCount);

            // Act
            int actualBallCount = logicAPI.GetBallsAmount();

            // Assert
            Assert.AreEqual(ballCount, actualBallCount);
        }

        [TestMethod]
        public void GetBallDiameterByID_ShouldReturnCorrectDiameter()
        {
            // Arrange
            int width = 800;
            int height = 600;
            int ballCount = 5;
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateLogicAPI(width, height);
            logicAPI.CreateBalls(ballCount);
            int ballId = 2;
            BallInterface ball = logicAPI.GetBallByID(ballId);
            int expectedDiameter = ball.Diameter;

            // Act
            int actualDiameter = logicAPI.GetBallDiameterByID(ballId);

            // Assert
            Assert.AreEqual(expectedDiameter, actualDiameter);
        }

        [TestMethod]
        public void GetBallPositionByID_ShouldReturnCorrectPosition()
        {
            // Arrange
            int width = 800;
            int height = 600;
            int ballCount = 5;
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateLogicAPI(width, height);
            logicAPI.CreateBalls(ballCount);
            int ballId = 2;
            BallInterface ball = logicAPI.GetBallByID(ballId);
            Vector2 expectedPosition = ball.Position;

            // Act
            Vector2 actualPosition = logicAPI.GetBallPositionByID(ballId);

            // Assert
            Assert.AreEqual(expectedPosition, actualPosition);
        }

        // Add more test methods as needed for the remaining functionality.
    }
}
