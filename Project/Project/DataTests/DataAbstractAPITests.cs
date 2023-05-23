using Data;
using System.Collections.ObjectModel;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data.Tests
{
    [TestClass]
    public class DataAbstractAPITests
    {
        [TestMethod]
        public void GetBallData_ReturnsValidBallData()
        {
            // Arrange
            DataAbstractAPI dataAPI = DataAbstractAPI.CreateDataAPI();
            Vector2 position = new Vector2(100, 200);
            Vector2 velocity = new Vector2(0.1f, -0.2f);
            float radius = 10f;
            float mass = 5f;

            // Act
            BallData ballData = dataAPI.GetBallData(position, velocity, radius, mass);

            // Assert
            Assert.IsNotNull(ballData);
            Assert.AreEqual(position, ballData.Position);
            Assert.AreEqual(velocity, ballData.Velocity);
            Assert.AreEqual(radius, ballData.Radius);
            Assert.AreEqual(mass, ballData.Mass);
        }

        [TestMethod]
        public void CreateDataAPI_ReturnsValidDataAPIInstance()
        {
            // Act
            DataAbstractAPI dataAPI = DataAbstractAPI.CreateDataAPI();

            // Assert
            Assert.IsNotNull(dataAPI);
        }

        [TestMethod]
        public void BoardWidth_ReturnsCorrectValue()
        {
            // Act
            int boardWidth = DataAbstractAPI.BoardWidth;

            // Assert
            Assert.AreEqual(750, boardWidth);
        }

        [TestMethod]
        public void BoardHeight_ReturnsCorrectValue()
        {
            // Act
            int boardHeight = DataAbstractAPI.BoardHeight;

            // Assert
            Assert.AreEqual(400, boardHeight);
        }
    }
}
