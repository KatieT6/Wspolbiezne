﻿using System;
using System.Collections.ObjectModel;
using Data;
using Logic;

namespace PresentationModel
{
    public abstract class ModelAbstractAPI
    {
        public abstract int Width { get; }
        public abstract int Height { get; }

        public static ModelAbstractAPI CreateModelAPI(LogicAbstractAPI logicAPI = default(LogicAbstractAPI))
        {
            return new ModelAPI(logicAPI);
        }
        public abstract void CallSimulation();
        public abstract void StopSimulation();
        public abstract ObservableCollection<BallService> CreateBalls(int ballsNumber);
        public abstract int GetAmountOfBalls();


    }
    public class ModelAPI : ModelAbstractAPI
    {
        private readonly LogicAbstractAPI logicAPI;
        public override int Width => logicAPI.Board.Width;
        public override int Height => logicAPI.Board.Height;

        public ModelAPI() : this(LogicAbstractAPI.CreateLogicAPI()) { }
        public ModelAPI(LogicAbstractAPI logicAPI)
        {
            logicAPI = logicAPI ?? LogicAbstractAPI.CreateLogicAPI();
        }


        public override void CallSimulation()
        {
            logicAPI.RunSimulation();
        }

        public override void StopSimulation()
        {
            logicAPI.StopSimulation();
        }

        public override ObservableCollection<BallService> CreateBalls(int ballsNumber)
        {
            logicAPI.CreateBalls(ballsNumber);
            return logicAPI.Balls;
        }

        public override int GetAmountOfBalls()
        {
            return logicAPI.Balls.Count;
        }
    }
}