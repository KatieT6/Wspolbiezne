﻿
using Data;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        private static int boardWidth = 750;
        private static int _boardHeight = 400;

        public static int BoardWidth { get => boardWidth; }a
        public static int BoardHeight { get => _boardHeight; }

        public static DataAbstractAPI CreateDataAPI()
        {
            return new DataLayer();
        }

        public abstract BallData GetBallData(Vector2 position, Vector2 velocity, float radius, float weight);



        //public abstract BoardData GetBoardData(int width, int height);

        public class DataLayer : DataAbstractAPI
        {




            public DataLayer()
            {

            }

            public override BallData GetBallData(Vector2 position, Vector2 velocity, float radious, float mass)
            {
                return new BallData(position, velocity, radious, mass);
            }

           /* public override BoardData GetBoardData(int width, int height)
            {
                return new BoardData(width, height);
            }*/
        }
    }
}