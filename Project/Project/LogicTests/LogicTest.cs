using Data;
using Logic;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Numerics;

namespace PresentationModel.Tests
{
    [TestFixture]
    public class ModelAbstractAPITests
    {
        private ModelAbstractAPI model;
        private LogicAbstractAPI logicMock;

        [SetUp]
        public void Initialize()
        {
            logicMock = new LogicMock();
            model = ModelAbstractAPI.CreateModelAPI(logicMock);
        }

        [Test]
        public void Width_ReturnsExpectedValue()
        {
            int expected = 500;
            int actual = model.Width;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Height_ReturnsExpectedValue()
        {
            int expected = 500;
            int actual = model.Height;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateBalls_ReturnsNonNullObservableCollectionWithExpectedCount()
        {
            int expectedCount = 5;
            int radius = 10;
            ObservableCollection<BallService> balls = model.CreateBalls(expectedCount);
            Assert.IsNotNull(balls);
            Assert.AreEqual(expectedCount, balls.Count);
        }

        [Test]
        public void GetBallAmount_ReturnsExpectedValue()
        {
            int expectedCount = 3;
            logicMock.Balls.Add(logicMock.CreateBall(Vector2.Zero, 0));
            logicMock.Balls.Add(logicMock.CreateBall(Vector2.Zero, 0));
            logicMock.Balls.Add(logicMock.CreateBall(Vector2.Zero, 0));

            
            Assert.AreEqual(expectedCount, model.GetAmountOfBalls);
        }

        private class LogicMock : LogicAbstractAPI
        {
            public bool RunSimulationCalled { get; set; }
            public bool StopSimulationCalled { get; set; }
            public override ObservableCollection<BallService> Balls { get; } = new ObservableCollection<BallService>();

            //public override BoardData board => new BoardData(500, 500);

            public override BallService CreateBall(Vector2 pos, int radius)
            {
                throw new System.NotImplementedException();
            }

            public override void CreateBalls(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    Balls.Add(new BallService(new BallData(Vector2.Zero, Vector2.Zero, 0, 0))); ;
                }
            }

            public override void DeleteBalls()
            {
                throw new System.NotImplementedException();
            }

            public override void RunSimulation()
            {
                RunSimulationCalled = true;
            }

            public override void StopSimulation()
            {
                StopSimulationCalled = true;
            }
        }
    }
}
