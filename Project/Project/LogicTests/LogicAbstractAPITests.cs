using System.Collections.ObjectModel;
using System.Numerics;
using System.Threading;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class LogicAbstractAPITests
    {
        [TestMethod]
        public void CreateBalls_CreatesSpecifiedNumberOfBalls()
        {
            // Arrange
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateLogicAPI();
            int ballCount = 5;

            // Act
            logicAPI.CreateBalls(ballCount);

            // Assert
            Assert.AreEqual(ballCount, logicAPI.Balls.Count);
        }

        [TestMethod]
        public void DeleteBalls_RemovesAllBalls()
        {
            // Arrange
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateLogicAPI();
            int ballCount = 5;
            logicAPI.CreateBalls(ballCount);

            // Act
            logicAPI.DeleteBalls();

            // Assert
            Assert.AreEqual(0, logicAPI.Balls.Count);
        }

        [TestMethod]
        public void RunSimulation_StartsUpdatingBalls()
        {
            // Arrange
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateLogicAPI();
            int ballCount = 5;
            logicAPI.CreateBalls(ballCount);

            
            logicAPI.RunSimulation();

            
        }

        [TestMethod]
        public void StopSimulation_StopsUpdatingBalls()
        {
            // Arrange
            LogicAbstractAPI logicAPI = LogicAbstractAPI.CreateLogicAPI();
            int ballCount = 5;
            logicAPI.CreateBalls(ballCount);
            logicAPI.RunSimulation();

            // Act
            logicAPI.StopSimulation();

            // Assert
            // Validate that the balls are no longer being updated (e.g., check their positions or velocities)
            // Add appropriate assertions based on the expected behavior after stopping the simulation
        }
    }
}
