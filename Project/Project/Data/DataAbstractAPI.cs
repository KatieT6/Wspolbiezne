﻿
using Data;
using System;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Data
{
    public abstract class DataAbstractAPI
    {
/*        public static int _boardWidth = 750;
        public static int _boardHeight = 400;*/

        public abstract int BoardWidth { get; }
        public abstract int BoardHeight { get; }

        public static DataAbstractAPI CreateDataAPI(int w, int h)
        {
            return new DataLayer(w, h);
        }

        public abstract int GetBallAmount();
        public abstract BallInterface GetBallByID(int index);
        public abstract void CreateBalls(int count);
        public abstract void RemoveBalls();

        //public abstract BallData GetBallData(Vector2 position, Vector2 velocity, float radius, float weight);


        internal class DataLayer : DataAbstractAPI
        {
            private List<BallInterface> _balls;
            private readonly Random _random = new Random();
            public override int BoardWidth { get; }
            public override int BoardHeight { get; }

            public DataLayer(int w, int h)
            {
                _balls = new List<BallInterface>();
                BoardWidth = w;
                BoardHeight = h;
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
                    float ballX = (float)(_random.Next(15 + diameter, BoardWidth - diameter - 15) + _random.NextDouble());
                    float ballY = (float)(_random.Next(15 + diameter, BoardHeight - diameter - 15) + _random.NextDouble());

                    BallData ball = new BallData(ballX, ballY, ballMass, vel, diameter, i);
                    _balls.Add(ball);
                }
            }

            public override void RemoveBalls()
            {
                foreach (BallInterface ball in _balls)
                {
                    ball.Dispose();
                }
                _balls.Clear();
            }
        }
    }
}