
using Data;
using System;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static int _boardWidth = 750;
        public static int _boardHeight = 400;

        public static int BoardWidth { get; }
        public static int BoardHeight { get; }

        public static DataAbstractAPI CreateDataAPI()
        {
            return new DataLayer();
        }

        public abstract int GetBallAmount();
        public abstract BallInterface GetBallByID(int index);
        public abstract void CreateBalls(int count);

        //public abstract BallData GetBallData(Vector2 position, Vector2 velocity, float radius, float weight);

        public static DataAbstractAPI CreateAPI()
        {
            return new DataLayer();
        }


        internal class DataLayer : DataAbstractAPI
        {
            private List<BallInterface> _balls;
            private readonly Random _random = new Random();

            public DataLayer()
            {
                _balls = new List<BallInterface>();
            }

            public override int GetBallAmount()
            {
                return _balls.Count;
            }

            public override BallInterface GetBallByID(int index)
            {
                return _balls[index];
            }


            public override void CreateBalls(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    float velX = (float)((_random.NextDouble() - 0.5) / 2);
                    float velY = (float)((_random.NextDouble() - 0.5) / 2);
                    while (velX == 0 & velY == 0)
                    {
                        velX = _random.Next(-2, 2);
                        velY = _random.Next(-2, 2);
                    }

                    Vector2 vel = new Vector2(velX, velY);
                    int diameter = _random.Next(15, 30);
                    int ballMass = diameter * 2;
                    float ballX = (float)(_random.Next(20 + diameter, _boardWidth - diameter - 20) + _random.NextDouble());
                    float ballY = (float)(_random.Next(20 + diameter, _boardHeight - diameter - 20) + _random.NextDouble());

                    BallData ball = new BallData(ballX, ballY, ballMass, vel, diameter, i);
                    _balls.Add(ball);
                }
            }
        }
    }
}