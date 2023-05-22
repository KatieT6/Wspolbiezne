using Data;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DataTests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void AllConstruktorTest()
        {
            // Arrange
            var dataAPI = DataAbstractAPI.CreateDataAPI();
            var position = new Vector2(10, 20);
            var velocity = new Vector2(0, 1);
            var radius = 5;
            var weight = 2.5f;

            // Act
            var ballData = dataAPI.GetBallData(position, velocity, radius, weight);

            // Assert
            Assert.AreEqual(position, ballData.Position);
            Assert.AreEqual(velocity, ballData.Velocity);
            Assert.AreEqual(radius, ballData.Radious);
            Assert.AreEqual(1500, ballData.Speed);
        }

        public void BoardIsCurrently()
        {
            
            var dataAPI = DataAbstractAPI.CreateDataAPI();
            var width = 800;
            var height = 600;

            // Act
            var boardData = dataAPI.GetBoardData(width, height);

            // Assert
            Assert.AreEqual(width, boardData.Width);
            Assert.AreEqual(height, boardData.Height);
        }
    }
}
